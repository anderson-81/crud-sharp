using LibCrud.Configs;
using LibCrud.Facades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LibCrud
{
    class UserController
    {
        #region Attributes
        private User _user;
        protected IDbCommand _cmd = ConnectionFactory.getInstance().getConnection().CreateCommand();
        private Log _log = Log.GetLogInstance;
        private Format format = new Format();
        private string _table = "";
        #endregion

        #region Constructor
        public UserController(User user)
        {
            this._user = user;
            SetTableNameByDatabase();
        }
        #endregion

        #region CreateParameters
        private void CreateParameters()
        {
            this._cmd.Parameters.Clear();
            List<string> parameters = new List<string>() { "@ID", "@NAME", "@USERNAME", "@PASSWORD", "@TYPEUSER", "@CREATEAT" };
            Dictionary<string, object> values = null;

            if (new StackTrace().GetFrame(1).GetMethod().Name == "GetUserByName")
            {
                values = new Dictionary<string, object>()
                {
                    { "@ID", this._user.Id },
                    { "@NAME", this._user.Name },
                    { "@USERNAME", this._user.Username },
                    { "@PASSWORD", this._user.Password },
                    { "@TYPEUSER", (this._user.UserType == User.UserTypeOption.Administrator) ? 1 : 0 },
                    { "@CREATEAT", DateTime.Now }
                };
            }
            else
            {
                values = new Dictionary<string, object>()
                {
                    { "@ID", this._user.Id },
                    { "@NAME", this._user.Name },
                    { "@USERNAME", format.GenerateHASH(this._user.Username) },
                    { "@PASSWORD", format.GenerateHASH(this._user.Password) },
                    { "@TYPEUSER", (this._user.UserType == User.UserTypeOption.Administrator) ? 1 : 0 },
                    { "@CREATEAT", DateTime.Now }
                };
            }

            foreach (var item in values)
            {
                var p = this._cmd.CreateParameter();
                p.ParameterName = item.Key;
                p.Value = item.Value;
                this._cmd.Parameters.Add(p);
            }

            SetLog("CreateParameters", "", DateTime.Now);
        }

        private void CreateUniqueParameter<T>(string parameterName, T parameterValue)
        {
            this._cmd.Parameters.Clear();
            IDbDataParameter p = this._cmd.CreateParameter();
            p.ParameterName = "@" + parameterName;
            p.Value = parameterValue;
            this._cmd.Parameters.Add(p);
            SetLog("CreateUniqueParameter", "", DateTime.Now);
        }
        #endregion

        protected List<UserFacade> CreateUserFacadeList(IDataReader reader)
        {
            List<UserFacade> listUser = new List<UserFacade>();
            try
            {
                while (reader.Read())
                {
                    UserFacade user = new UserFacade();
                    user.Id = reader.GetInt32(0);
                    user.Name = reader.GetString(1);
                    user.Username = reader.GetString(2);
                    user.Password = reader.GetString(3);
                    user.UserType = reader.GetInt32(4);
                    user.CreateAt = reader.GetDateTime(5);
                    listUser.Add(user);
                }
                SetLog("CreateUserFacadeList", "Successfully executed.", DateTime.Now);
                return listUser;
            }
            catch (Exception)
            {
                SetLog("CreateUserFacadeList", "Error creating.", DateTime.Now);
                return null;
            }
        }

        #region Login and Transactions
        public int Login()
        {
            IDbConnection conn = this._cmd.Connection;
            try
            {
                String cmdStr = string.Format("SELECT * FROM {0} WHERE USERNAME = @USERNAME AND PASSWORD = @PASSWORD AND TYPEUSER = @TYPEUSER;", _table);
                this._cmd.CommandText = cmdStr;
                this.CreateParameters();

                using (System.Data.IDataReader IReader = this._cmd.ExecuteReader())
                {
                    if (((System.Data.Common.DbDataReader)IReader).HasRows)
                    {
                        conn.Close();
                        SetLog("Login", "Successfully Login.", DateTime.Now);
                        return 1;
                    }
                    else
                    {
                        conn.Close();
                        SetLog("Login", "Invalid username and password.", DateTime.Now);
                        return 0;
                    }
                }
            }
            catch (Exception)
            {
                SetLog("Login", "Error logging in.", DateTime.Now);
                return -1;
            }
        }

        public int InsertUser()
        {
            IDbConnection conn = this._cmd.Connection;
            this._cmd.Transaction = this._cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted);
            IDbTransaction trans = this._cmd.Transaction;
            SetLog("InsertUser", "Starting transaction.", DateTime.Now);

            try
            {
                String cmdStr = string.Format("INSERT INTO {0} (NAME, USERNAME, PASSWORD, TYPEUSER, CREATEAT) VALUES(@NAME, @USERNAME, @PASSWORD, @TYPEUSER, @CREATEAT);", _table);
                this.CreateParameters();
                this._cmd.CommandText = cmdStr;
                this._cmd.ExecuteNonQuery();
                trans.Commit();
                SetLog("InsertUser", "Commit transaction.", DateTime.Now);
                conn.Close();
                SetLog("InsertUser", "Successfully inserted.", DateTime.Now);
                return 1;
            }
            catch (Exception)
            {
                trans.Rollback();
                SetLog("InsertUser", "Rollback transaction.", DateTime.Now);
                return -1;
            }
        }

        public int EditUser()
        {
            this._cmd.Connection = ConnectionFactory.getInstance().getConnection();
            IDbConnection conn = this._cmd.Connection;
            this._cmd.Transaction = this._cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted);
            IDbTransaction trans = this._cmd.Transaction;
            SetLog("EditUser", "Starting transaction.", DateTime.Now);

            try
            {
                String cmdStr = string.Format("UPDATE {0} SET NAME = @NAME, USERNAME = @USERNAME, PASSWORD = @PASSWORD, TYPEUSER = @TYPEUSER WHERE ID = @ID;", _table);
                this.CreateParameters();
                this._cmd.CommandText = cmdStr;
                this._cmd.ExecuteNonQuery();
                trans.Commit();
                SetLog("EditUser", "Commit transaction.", DateTime.Now);
                conn.Close();
                SetLog("EditUser", "Successfully edited.", DateTime.Now);
                return 1;
            }
            catch (Exception)
            {
                trans.Rollback();
                SetLog("EditUser", "Rollback transaction.", DateTime.Now);
                return -1;
            }
        }

        public int DeletetUser()
        {
            IDbConnection conn = this._cmd.Connection;
            this._cmd.Transaction = this._cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted);
            IDbTransaction trans = this._cmd.Transaction;
            SetLog("DeletetUser", "Starting transaction.", DateTime.Now);

            try
            {
                String cmdStr = string.Format("DELETE FROM {0} WHERE ID = @ID;", _table);
                this.CreateUniqueParameter<int>("ID", _user.Id);
                this._cmd.CommandText = cmdStr;
                this._cmd.ExecuteNonQuery();
                trans.Commit();
                SetLog("DeletetUser", "Commit transaction.", DateTime.Now);
                conn.Close();
                SetLog("DeletetUser", "Successfully deleted.", DateTime.Now);
                return 1;
            }
            catch (Exception)
            {
                trans.Rollback();
                conn.Close();
                SetLog("DeletetUser", "Error deleting.", DateTime.Now);
                return -1;
            }
        }

        public UserFacade GetUserByID()
        {
            IDbConnection conn = this._cmd.Connection;
            try
            {
                UserFacade userFacade = null;
                String cmdStr = string.Format("SELECT * FROM {0} WHERE ID = @ID;", _table);
                this._cmd.CommandText = cmdStr;
                this.CreateUniqueParameter<int>("ID", _user.Id);
                IDataReader reader = this._cmd.ExecuteReader();
                try
                {
                    userFacade = this.CreateUserFacadeList(reader)[0];
                }
                catch (Exception)
                {
                    userFacade = null;
                }
                SetLog("GetUserByID", "Search performed successfully.", DateTime.Now);
                reader.Close();
                _cmd.Connection.Close();
                return userFacade;
            }
            catch (Exception)
            {
                SetLog("GetUserByID", "Error logging in.", DateTime.Now);
                return null;
            }
        }

        public List<UserFacade> GetUserByName()
        {
            IDbConnection conn = this._cmd.Connection;
            try
            {
                List<UserFacade> list = null;
                String cmdStr = string.Format("SELECT * FROM {0} WHERE USERNAME LIKE @USERNAME;", _table);
                this._cmd.CommandText = cmdStr;
                this.CreateUniqueParameter<string>("USERNAME", this._user.Username + '%');
                IDataReader reader = this._cmd.ExecuteReader();
                list = this.CreateUserFacadeList(reader);
                SetLog("GetUserByName", "Search performed successfully.", DateTime.Now);
                reader.Close();
                _cmd.Connection.Close();
                return list;
            }
            catch (Exception)
            {
                SetLog("GetUserByName", "xxxxxxxxx.", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region Log
        protected void SetLog(string method, string result, DateTime datetime)
        {
            _log.SetLog(method, result, datetime);
        }
        #endregion

        #region Configuration Database
        private void SetTableNameByDatabase()
        {
            switch (new ConfigurationDatabase().GetConnectionConfiguration().name.ToString())
            {
                case "SQLServer":
                    _table = "\"USER\"";
                    break;
                case "PostgreSQL":
                    _table = "\"user\"";
                    break;
                case "SQLite":
                    _table = "USER";
                    break;
                case "MySQL":
                    _table = "USER";
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }
        #endregion
    }
}
