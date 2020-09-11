using System;
using System.Collections.Generic;
using System.Data;
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
        private Log log = Log.GetLogInstance;
        #endregion

        #region Constructor
        public UserController(User user)
        {
            this._user = user;
        }
        #endregion

        #region Format
        private String GenerateHASH(string source)
        {
            using (SHA512 sha512Hash = SHA512.Create())
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
                byte[] hashBytes = sha512Hash.ComputeHash(sourceBytes);
                log.SetLog("GenerateHASH", "Hash generated successfully.", DateTime.Now);
                return BitConverter.ToString(hashBytes).Replace("-", String.Empty).ToLower();
            }
        }
        #endregion

        #region CreateParameters
        private void CreateParameters()
        {
            List<string> parameters = new List<string>() { "@ID", "@USERNAME", "@PASSWORD", "@CREATEAT" };

            Dictionary<string, object> values = new Dictionary<string, object>()
            {
                { "@ID", this._user.Id },
                { "@USERNAME", GenerateHASH(this._user.Username) },
                { "@PASSWORD", GenerateHASH(this._user.Password) },
                { "@CREATEAT", DateTime.Now }
            };

            foreach (var item in values)
            {
                var p = this._cmd.CreateParameter();
                p.ParameterName = item.Key;
                p.Value = item.Value;
                this._cmd.Parameters.Add(p);
            }

            log.SetLog("CreateParameters", "", DateTime.Now);
        }
        #endregion

        #region Login and Transactions
        public int Login()
        {
            IDbConnection conn = this._cmd.Connection;
            try
            {
                String cmdStr = "SELECT * FROM USER WHERE USERNAME = @USERNAME AND PASSWORD = @PASSWORD;";
                this._cmd.CommandText = cmdStr;
                this.CreateParameters();

                using (System.Data.IDataReader IReader = this._cmd.ExecuteReader())
                {
                    if (((System.Data.Common.DbDataReader)IReader).HasRows)
                    {
                        conn.Close();
                        log.SetLog("Login", "Successfully Login.", DateTime.Now);
                        return 1;
                    }
                    else
                    {
                        conn.Close();
                        log.SetLog("Login", "Invalid username and password.", DateTime.Now);
                        return 0;
                    }
                }
            }
            catch (Exception)
            {
                log.SetLog("Login", "Error logging in.", DateTime.Now);
                return -1;
            }
        }

        public int InsertUser()
        {
            IDbConnection conn = this._cmd.Connection;
            this._cmd.Transaction = this._cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted);
            IDbTransaction trans = this._cmd.Transaction;
            log.SetLog("InsertUser", "Starting transaction.", DateTime.Now);

            try
            {
                String cmdStr = "INSERT INTO \"USER\" (USERNAME, PASSWORD, CREATEAT) VALUES(@USERNAME, @PASSWORD, @CREATEAT);";
                this.CreateParameters();
                this._cmd.CommandText = cmdStr;
                this._cmd.ExecuteNonQuery();
                trans.Commit();
                log.SetLog("InsertUser", "Commit transaction.", DateTime.Now);
                conn.Close();
                log.SetLog("InsertUser", "Successfully inserted.", DateTime.Now);
                return 1;
            }
            catch (Exception)
            {
                trans.Rollback();
                log.SetLog("InsertUser", "Rollback transaction.", DateTime.Now);
                return -1;
            }
        }

        public int DeletetUser()
        {
            IDbConnection conn = this._cmd.Connection;
            this._cmd.Transaction = this._cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted);
            IDbTransaction trans = this._cmd.Transaction;
            log.SetLog("DeletetUser", "Starting transaction.", DateTime.Now);

            try
            {
                String cmdStr = "DELETE FROM \"USER\" WHERE ID = @ID;";
                this.CreateParameters();
                this._cmd.CommandText = cmdStr;
                this._cmd.ExecuteNonQuery();
                trans.Commit();
                log.SetLog("DeletetUser", "Commit transaction.", DateTime.Now);
                conn.Close();
                log.SetLog("DeletetUser", "Successfully deleted.", DateTime.Now);
                return 1;
            }
            catch (Exception)
            {
                trans.Rollback();
                conn.Close();
                log.SetLog("DeletetUser", "Error deleting.", DateTime.Now);
                return -1;
            }
        }
        #endregion
    }
}
