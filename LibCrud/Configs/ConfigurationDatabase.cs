using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LibCrud
{
    [Serializable()]
    public class ConfigurationDatabase
    {
        #region Attributes, Enums and XML Fields
        internal Log log = Log.GetLogInstance;

        public enum DatabaseName
        {
            SQLServer,
            PostgreSQL,
            SQLite,
            MySQL
        }

        #region XML Fields
        [XmlElement("Name")]
        public DatabaseName name;

        [XmlElement("ProviderName")]
        public string providerName;

        [XmlElement("Database")]
        public string database;

        [XmlElement("Hostname")]
        public string hostname;

        [XmlElement("Port")]
        public ushort port;

        [XmlElement("Username")]
        public string username;

        [XmlElement("Password")]
        public string password;

        [XmlElement("DefaultSchema")]
        public string defaultSchema;
        #endregion

        #endregion

        #region ConfigurationDatabase
        public ConfigurationDatabase() { }

        public ConfigurationDatabase(DatabaseName databaseName, string database, string hostname, ushort port, string username, string password, string defaultSchema)
        {
            switch (databaseName)
            {
                case DatabaseName.SQLServer:
                    this.name = DatabaseName.SQLServer;
                    this.providerName = "System.Data.SqlClient";
                    break;
                case DatabaseName.PostgreSQL:
                    this.name = DatabaseName.PostgreSQL;
                    this.providerName = "Npgsql";
                    break;
                case DatabaseName.SQLite:
                    this.name = DatabaseName.SQLite;
                    this.providerName = "System.Data.SQLite";
                    break;
                case DatabaseName.MySQL:
                    this.name = DatabaseName.MySQL;
                    this.providerName = "MySql.Data.MySqlClient";
                    break;
                default:
                    this.providerName = null;
                    break;
            }

            this.database = database;
            this.hostname = hostname;
            this.port = port;
            this.username = username;
            this.password = password;
            this.defaultSchema = defaultSchema;
        }

        public bool CreateConfiguration()
        {
            log.SetLog("ValidateConfiguration", "Starting database configuration.", DateTime.Now);

            if (this.ValidateConfiguration())
            {
                if (File.Exists("database.xml"))
                {
                    File.Delete("database.xml");
                }

                TextWriter file = new StreamWriter("database.xml");

                XmlSerializer xmlSerial = new XmlSerializer(typeof(ConfigurationDatabase));

                xmlSerial.Serialize(file, this);

                file.Close();

                log.SetLog("CreateConfiguration", "Successfully created.", DateTime.Now);

                return true;
            }

            return false;
        }

        private bool ValidateConfiguration()
        {
            bool result = true;

            Regex regex = new Regex(@"^\S+\w{0,45}\S{1,}");

            #region PROVISORY
            if (string.IsNullOrEmpty(this.providerName))
            {
                result = false;
            }

            if (string.IsNullOrEmpty(this.database))
            {
                result = false;
            }
            else
            {
                if (!regex.IsMatch(this.database))
                {
                    result = false;
                }
            }

            if (this.providerName != "System.Data.SQLite")
            {
                if (string.IsNullOrEmpty(this.username))
                {
                    result = false;
                }
                else
                {
                    if (!regex.IsMatch(this.username))
                    {
                        result = false;
                    }
                }

                if (string.IsNullOrEmpty(this.password))
                {
                    result = false;
                }
                else
                {
                    if (!regex.IsMatch(this.password))
                    {
                        result = false;
                    }
                }

                if (string.IsNullOrEmpty(this.port.ToString()))
                {
                    result = false;
                }
                else
                {
                    try
                    {
                        ushort.Parse(this.port.ToString());

                        if (this.port <= 0)
                        {
                            result = false;
                        }
                    }
                    catch (Exception)
                    {
                        result = false;
                    }
                }

                if (string.IsNullOrEmpty(this.hostname))
                {
                    result = false;
                }
                else
                {
                    // Font: https://stackoverflow.com/questions/106179/regular-expression-to-match-dns-hostname-or-ip-address
                    regex = new Regex(@"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$");
                    if (!regex.IsMatch(this.hostname))
                    {
                        regex = new Regex(@"^(([a-zA-Z0-9]|[a-zA-Z0-9][a-zA-Z0-9\-]*[a-zA-Z0-9])\.)*([A-Za-z0-9]|[A-Za-z0-9][A-Za-z0-9\-]*[A-Za-z0-9])$");
                        if (!regex.IsMatch(this.hostname))
                        {
                            result = false;
                        }
                    }

                    result = Uri.CheckHostName(this.hostname) != UriHostNameType.Basic;
                }

                if (!string.IsNullOrEmpty(this.defaultSchema))
                {
                    if (!regex.IsMatch(this.defaultSchema))
                    {
                        result = false;
                    }
                }
            }

            if (result)
            {
                log.SetLog("ValidateConfiguration", "Successfully validated.", DateTime.Now);
            }
            else
            {
                log.SetLog("ValidateConfiguration", "Invalid configuration.", DateTime.Now);
            }

            #endregion
            return result;
        }

        public ConfigurationDatabase GetConnectionConfiguration()
        {
            if (File.Exists("database.xml"))
            {
                Stream stream = new FileStream("database.xml", FileMode.Open);

                XmlSerializer xmlSerial = new XmlSerializer(typeof(ConfigurationDatabase));

                ConfigurationDatabase config = (ConfigurationDatabase)xmlSerial.Deserialize(stream);

                stream.Close();

                log.SetLog("GetConnectionConfiguration", "Configuration loaded successfully.", DateTime.Now);

                return config;
            }

            log.SetLog("GetConnectionConfiguration", "Error configuration loading.", DateTime.Now);

            return null;
        }

        public override string ToString()
        {
            return String.Format("{0} -- {1} -- {2} -- {3} -- {4} -- {5}",
                this.database,
                this.hostname,
                this.port,
                this.username,
                this.password,
                this.defaultSchema
               );
        }
        #endregion
    }
}
