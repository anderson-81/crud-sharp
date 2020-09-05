using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LibCrud
{
    abstract class PersonController
    {
        #region Attributes
        protected Person P { get; set; }
        protected IDbCommand cmd = ConnectionFactory.getInstance().getConnection().CreateCommand();
        protected Log log = Log.GetLogInstance;
        #endregion

        #region CreateParameters
        private void CreateParameters()
        {
            List<string> parameters = new List<string>() { "@ID", "@NAME", "@EMAIL", "@COMMENT", "@STATUS", "@CREATEAT" };

            Dictionary<string, object> values = new Dictionary<string, object>()
            {
                { "@ID", this.P.Id },
                { "@NAME",  this.P.Name },
                { "@EMAIL",this.P.Email  },
                { "@COMMENT",this.P.Comment },
                { "@STATUS", this.P.Status == true ? 1 : 0 },
                { "@CREATEAT", DateTime.Now }
            };

            foreach (var item in values)
            {
                var p = this.cmd.CreateParameter();
                p.ParameterName = item.Key;
                p.Value = item.Value;
                this.cmd.Parameters.Add(p);
            }

            SetLog("CreateParameters", "", DateTime.Now);
        }
        protected void CreateUniqueParameter<T>(string parameterName, T parameterValue)
        {
            this.cmd.Parameters.Clear();
            IDbDataParameter p = this.cmd.CreateParameter();
            p.ParameterName = "@" + parameterName;
            p.Value = parameterValue;
            this.cmd.Parameters.Add(p);

            SetLog("CreateUniqueParameter", "", DateTime.Now);
        }
        #endregion

        #region PERSON
        protected int InsertPerson()
        {
            try
            {
                String cmdStr = "INSERT INTO PERSON VALUES(@ID, @NAME, @EMAIL, @STATUS, @COMMENT, @CREATEAT);";
                this.cmd.CommandType = CommandType.Text;
                this.CreateParameters();
                this.cmd.CommandText = cmdStr;
                this.cmd.ExecuteNonQuery();
                SetLog("InsertPerson", "Successfully executed.", DateTime.Now);
                return 1;
            }
            catch (Exception)
            {
                SetLog("InsertPerson", "Error while running.", DateTime.Now);
                return -1;
            }
        }

        protected int EditPerson()
        {
            try
            {
                String cmdStr = "UPDATE PERSON SET NAME = @NAME, EMAIL = @EMAIL, COMMENT = @COMMENT, STATUS = @STATUS WHERE ID = @ID;";
                this.cmd.CommandType = CommandType.Text;
                this.CreateParameters();
                this.cmd.CommandText = cmdStr;
                this.cmd.ExecuteNonQuery();
                SetLog("EditPerson", "Successfully executed.", DateTime.Now);
                return 1;
            }
            catch (Exception)
            {
                SetLog("EditPerson", "Error while running.", DateTime.Now);
                return -1;
            }
        }

        protected int DeletePerson()
        {
            try
            {
                String cmdStr = "DELETE FROM PERSON WHERE ID = @ID;";
                this.cmd.CommandType = CommandType.Text;
                this.cmd.CommandText = cmdStr;
                this.CreateUniqueParameter<int>("ID", this.P.Id);
                this.cmd.ExecuteNonQuery();
                SetLog("DeletePerson", "Successfully executed.", DateTime.Now);
                return 1;
            }
            catch (Exception)
            {
                SetLog("DeletePerson", "Error while running.", DateTime.Now);
                return -1;
            }
        }
        #endregion

        #region Generate ID for insertion

        protected int GenerateID()
        {
            try
            {
                String cmdStr = "SELECT MAX(ID) + 1 AS max_id FROM PERSON;";
                this.cmd.CommandText = cmdStr;
                int id =  Convert.ToInt32(this.cmd.ExecuteScalar());
                SetLog("GenerateID", "Successfully executed.", DateTime.Now);
                return id;
            }
            catch (InvalidCastException)
            {
                SetLog("GenerateID", "First id created.", DateTime.Now);
                return 1;
            }
            catch (Exception)
            {
                SetLog("GenerateID", "Error while running.", DateTime.Now);
                return -1;
            }
        }
        #endregion

        #region Search
        protected abstract List<PersonFacade> CreatePersonFacadeList(IDataReader dr);
        public abstract List<PersonFacade> GetPersonByName();
        #endregion

        #region Log
        protected void SetLog(string method, string result, DateTime datetime)
        {
            this.log.SetLog(method, result, datetime);
        }
        #endregion
    }
}