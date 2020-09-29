using MySql.Data.MySqlClient;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Data;
using System.Data.SQLite;

namespace LibCrud
{
    class ConnectionFactory
    {
        #region Attributes and Enums
        private static volatile DbConnection _conn = null;
        private static ConnectionFactory _instance = null;
        private Log _log = Log.GetLogInstance;

        private enum DatabaseName
        {
            SQLServer,
            PostgreSQL,
            SQLite,
            MySQL
        }
        #endregion

        #region Singleton and Connection Initialization
        public static ConnectionFactory getInstance()
        {
            if (_instance == null)
            {
                _instance = new ConnectionFactory();
            }
            return _instance;
        }

        private ConnectionFactory()
        {
            ConfigurationDatabase config = new ConfigurationDatabase();
            _log.SetLog("ConnectionFactory", "Getting connection configuration.", DateTime.Now);
            config = config.GetConnectionConfiguration();

            try
            {
                switch ((DatabaseName)config.name)
                {
                    case DatabaseName.SQLServer:
                        _conn = new SqlConnection();
                        _conn.ConnectionString = String.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", config.hostname, config.database, config.username, config.password);
                        break;
                    case DatabaseName.PostgreSQL:
                        _conn = new NpgsqlConnection();
                        _conn.ConnectionString = String.Format("Server={0};Port={1};Database={2};User Id={3};Password={4};", config.hostname, config.port, config.database, config.username, config.password);
                        break;
                    case DatabaseName.SQLite:
                        _conn = new SQLiteConnection();
                        _conn.ConnectionString = String.Format("Data Source={0};Version=3;Pooling=True;Max Pool Size=100;;Synchronous=Off;", config.database);

                        #region PROVISORY
                        if (!File.Exists(config.database))
                        {
                            SQLiteConnection.CreateFile(config.database);
                        }
                        #endregion

                        break;
                    case DatabaseName.MySQL:
                        _conn = new MySqlConnection();
                        _conn.ConnectionString = String.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4};", config.hostname, config.port, config.database, config.username, config.password);
                        break;
                    default:
                        _conn = null;
                        break;
                }
            }
            catch (Exception)
            {
                _log.SetLog("ConnectionFactory", "Error getting connection configuration.", DateTime.Now);
                Environment.Exit(0);
            }
        }
        #endregion

        #region GetConnection
        public DbConnection getConnection()
        {
            try
            {
                _log.SetLog("getConnection", "Openning connection.", DateTime.Now);
                ConnectionFactory._conn.Open();
                _log.SetLog("getConnection", "Getting connection.", DateTime.Now);
                return ConnectionFactory._conn;
            }
            catch (Exception)
            {
                _log.SetLog("getConnection", "Error getting connection configuration.", DateTime.Now);
                return null;
            }
        }
        #endregion
    }
}
