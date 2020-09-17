using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibCrud
{
    class JuridicalPersonController : PersonController
    {
        #region Attributes and Enums
        private JuridicalPerson _jp;

        public enum OptionIdentity
        {
            ID,
            CNPJ
        }
        #endregion

        #region Constructors
        public JuridicalPersonController(Person p)
        {
            this._jp = (JuridicalPerson)p;
            this.P = p;
        }
        #endregion
        
        #region CreatePersonFacade
        private void CreateParameters()
        {
            this.cmd.Parameters.Clear();

            List<string> parameters = new List<string>() { "@ID", "@CNPJ", "@COMPANYNAME" };

            Dictionary<string, object> values = new Dictionary<string, object>()
            {
                { "@ID", this._jp.Id },
                { "@CNPJ",  this._jp.Cnpj },
                { "@COMPANYNAME",this._jp.CompanyName }
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

        protected override List<PersonFacade> CreatePersonFacadeList(IDataReader reader)
        {
            List<PersonFacade> lpf = new List<PersonFacade>();
            try
            {
                while (reader.Read())
                {
                    PersonFacade pf = new PersonFacade();

                    pf.Id = reader.GetInt32(0);
                    pf.Name = reader.GetString(1);
                    pf.Email = reader.GetString(2);
                    pf.Status = Convert.ToInt32(reader.GetValue(3)) == 1 ? true : false;
                    pf.Comment = reader.GetString(4);
                    pf.CreateAt = reader.GetDateTime(5);
                    pf.CNPJ = reader.GetString(8);
                    pf.CompanyName = reader.GetString(9);

                    lpf.Add(pf);
                }
                SetLog("CreatePersonFacadeList", "Successfully created.", DateTime.Now);
            }
            catch (Exception)
            {
                SetLog("CreatePersonFacadeList", "Error creating.", DateTime.Now);
                return null;
            }
            return lpf;
        }
        #endregion

        #region JuridicalPerson
        private int InsertJuridicalPerson()
        {
            try
            {
                String cmdStr = "INSERT INTO JURIDICALPERSON VALUES(@ID, @ID, @CNPJ, @COMPANYNAME)";
                this.cmd.CommandType = CommandType.Text;
                this.CreateParameters();
                this.cmd.CommandText = cmdStr;
                this.cmd.ExecuteNonQuery();
                SetLog("InsertJuridicalPerson", "Successfully executed.", DateTime.Now);
                return 1;
            }
            catch (Exception)
            {
                SetLog("InsertJuridicalPerson", "Error while running.", DateTime.Now);
                return -1;
            }
        }

        private int EditJuridicalPerson()
        {
            try
            {
                String cmdStr = "UPDATE JURIDICALPERSON SET COMPANYNAME = @COMPANYNAME WHERE ID = @ID;";
                this.cmd.CommandType = CommandType.Text;
                this.CreateParameters();
                this.cmd.CommandText = cmdStr;
                this.cmd.ExecuteNonQuery();
                SetLog("EditJuridicalPerson", "Successfully executed.", DateTime.Now);
                return 1;
            }
            catch (Exception)
            {
                SetLog("EditJuridicalPerson", "Error while running.", DateTime.Now);
                return -1;
            }
        }

        private int DeleteJuridicalPerson()
        {
            try
            {
                String cmdStr = "DELETE FROM JURIDICALPERSON WHERE ID = @ID;";
                this.CreateUniqueParameter<int>("ID", this._jp.Id);
                this.cmd.CommandText = cmdStr;
                this.cmd.ExecuteNonQuery();
                SetLog("DeleteJuridicalPerson", "Successfully executed.", DateTime.Now);
                return 1;
            }
            catch (Exception)
            {
                SetLog("DeleteJuridicalPerson", "Error while running.", DateTime.Now);
                return -1;
            }
        }
        #endregion

        #region Search
        public PersonFacade GetJuridicalPersonByIdentity(OptionIdentity optionIdentity)
        {
            try
            {
                String cmdStr = "";
                PersonFacade pf = null;

                switch (optionIdentity)
                {
                    case OptionIdentity.ID:
                        cmdStr = "SELECT * FROM PERSON INNER JOIN JURIDICALPERSON ON PERSON.ID = JURIDICALPERSON.PERSON_ID WHERE JURIDICALPERSON.ID = @ID;";
                        this.CreateUniqueParameter<int>("ID", this._jp.Id);
                        SetLog("GetJuridicalPersonByIdentity", "Get JuridicalPerson By Identity (ID).", DateTime.Now);
                        break;
                    case OptionIdentity.CNPJ:
                        cmdStr = "SELECT * FROM PERSON INNER JOIN JURIDICALPERSON ON PERSON.ID = JURIDICALPERSON.PERSON_ID WHERE JURIDICALPERSON.CNPJ = @CNPJ;";
                        this.CreateUniqueParameter<string>("CNPJ", this._jp.Cnpj);
                        SetLog("GetJuridicalPersonByIdentity", "Get JuridicalPerson By Identity (CNPJ).", DateTime.Now);
                        break;
                }

                this.cmd.CommandType = CommandType.Text;
                this.cmd.CommandText = cmdStr;
                IDataReader reader = this.cmd.ExecuteReader();

                try
                {
                    pf = this.CreatePersonFacadeList(reader)[0];
                }
                catch (Exception)
                {
                    pf = null;
                }
                
                reader.Close();
                this.cmd.Connection.Close();
                SetLog("GetJuridicalPersonByIdentity", "Search performed successfully.", DateTime.Now);
                return pf;
            }
            catch (Exception)
            {
                SetLog("GetJuridicalPersonByIdentity", "Error performing search.", DateTime.Now);
                return null;
            }
        }

        public override List<PersonFacade> GetPersonByName()
        {
            try
            {
                String cmdStr = "SELECT * FROM PERSON INNER JOIN JURIDICALPERSON ON PERSON.ID = JURIDICALPERSON.PERSON_ID WHERE NAME LIKE @NAME;";
                this.cmd.CommandText = cmdStr;
                this.CreateUniqueParameter<string>("NAME", this._jp.Name + '%');
                IDataReader reader = this.cmd.ExecuteReader();
                List<PersonFacade> list = this.CreatePersonFacadeList(reader);
                reader.Close();
                this.cmd.Connection.Close();
                SetLog("GetPersonByName", "Search performed successfully. (JuridicalPerson)", DateTime.Now);
                return list;
            }
            catch (Exception)
            {
                SetLog("GetPersonByName", "Error performing search. (JuridicalPerson)", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region Transactions
        public int Insert_JuridicalPerson()
        {
            IDbConnection conn = this.cmd.Connection;
            this.cmd.Transaction = this.cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted);
            IDbTransaction trans = this.cmd.Transaction;
            SetLog("Insert_JuridicalPerson", "Starting transaction.", DateTime.Now);

            int id = this.GenerateID();
            if (id > 0)
            {
                this._jp.Id = id;
                if (this.InsertPerson() == 1)
                {
                    if (this.InsertJuridicalPerson() == 1)
                    {
                        trans.Commit();
                        conn.Close();
                        SetLog("Insert_JuridicalPerson", "Successfully created.", DateTime.Now);
                        return 1;
                    }
                    else
                    {
                        trans.Rollback();
                        conn.Close();
                        SetLog("Insert_JuridicalPerson", "Rollback transaction.", DateTime.Now);
                        return -1;
                    }
                }
                else
                {
                    trans.Rollback();
                    conn.Close();
                    SetLog("Insert_JuridicalPerson", "Rollback transaction.", DateTime.Now);
                    return -1;
                }
            }
            else
            {
                conn.Close();
                SetLog("Insert_JuridicalPerson", "Error generating the ID.", DateTime.Now);
                return -1;
            }
        }

        public int Edit_JuridicalPerson()
        {
            IDbConnection conn = this.cmd.Connection;
            this.cmd.Transaction = this.cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted);
            IDbTransaction trans = this.cmd.Transaction;
            SetLog("Edit_JuridicalPerson", "Starting transaction.", DateTime.Now);

            if (this.EditPerson() == 1)
            {
                if (this.EditJuridicalPerson() == 1)
                {
                    trans.Commit();
                    conn.Close();
                    SetLog("Edit_JuridicalPerson", "Successfully edited.", DateTime.Now);
                    return 1;
                }
                else
                {
                    trans.Rollback();
                    conn.Close();
                    SetLog("Edit_JuridicalPerson", "Rollback transaction.", DateTime.Now);
                    return -1;
                }
            }
            else
            {
                trans.Rollback();
                conn.Close();
                SetLog("Edit_JuridicalPerson", "Rollback transaction.", DateTime.Now);
                return -1;
            }
        }

        public int Delete_JuridicalPerson()
        {
            IDbConnection conn = this.cmd.Connection;
            this.cmd.Transaction = this.cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted);
            IDbTransaction trans = this.cmd.Transaction;
            SetLog("Delete_JuridicalPerson", "Starting transaction.", DateTime.Now);

            if (this.DeleteJuridicalPerson() == 1)
            {
                if (this.DeletePerson() == 1)
                {
                    trans.Commit();
                    conn.Close();
                    SetLog("Delete_JuridicalPerson", "Successfully deleted.", DateTime.Now);
                    return 1;
                }
                else
                {
                    trans.Rollback();
                    conn.Close();
                    SetLog("Delete_JuridicalPerson", "Rollback transaction.", DateTime.Now);
                    return -1;
                }
            }
            else
            {
                trans.Rollback();
                conn.Close();
                SetLog("Delete_JuridicalPerson", "Rollback transaction.", DateTime.Now);
                return -1;
            }
        }

        #endregion
    }
}
