using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibCrud
{
    class PhysicalPersonController : PersonController
    {
        #region Attributes
        private PhysicalPerson _pp;
        #endregion

        #region Enums
        public enum OptionAVGSalary
        {
            Above,
            Under,
            Equal
        }

        public enum OptionSalary
        {
            Lower,
            Higher
        }

        public enum OptionGender
        {
            Male,
            Female
        }

        public enum OptionIdentity
        {
            ID,
            CPF
        }
        #endregion

        #region Constructors
        public PhysicalPersonController(Person p)
        {
            this._pp = (PhysicalPerson)p;
            this.P = p;
        }
        #endregion

        #region Format
        private object FormatDateToDatabase(DateTime date)
        {
            string sdate = "";
            if ((this.cmd.ToString() == "System.Data.SQLite.SQLiteCommand") || (this.cmd.ToString() == "MySql.Data.MySqlClient.MySqlCommand"))
            {
                sdate = String.Format("{0}-{1}-{2}", date.Year, date.Month, date.Day);
                return sdate;
            }
            SetLog("FormatDateToDatabase", "", DateTime.Now);
            return date;
        }
        #endregion

        #region CreateParameters
        private void CreateParameters()
        {
            this.cmd.Parameters.Clear();

            List<string> parameters = new List<string>() { "@ID", "@CPF", "@SALARY", "@BIRTHDAY", "@GENDER" };

            Dictionary<string, object> values = new Dictionary<string, object>()
            {
                { "@ID", this._pp.Id },
                { "@CPF", this._pp.Cpf },
                { "@SALARY", this._pp.Salary },
                { "@BIRTHDAY", FormatDateToDatabase(this._pp.Birthday) },
                { "@GENDER", this._pp.Gender }
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

                    Console.WriteLine();

                    pf.Id = reader.GetInt32(0);
                    pf.Name = reader.GetString(1);
                    pf.Email = reader.GetString(2);
                    pf.Status = Convert.ToInt32(reader.GetValue(3)) == 1 ? true : false;
                    pf.Comment = reader.GetString(4);
                    pf.CreateAt = reader.GetDateTime(5);
                    pf.CPF = reader.GetString(8);
                    pf.Salary = reader.GetDecimal(9);
                    pf.Birthday = reader.GetDateTime(10);
                    pf.Gender = reader.GetString(11)[0];

                    lpf.Add(pf);
                }
                reader.Close();
                SetLog("CreatePersonFacadeList", "Successfully executed.", DateTime.Now);
            }
            catch (Exception)
            {
                SetLog("CreatePersonFacadeList", "Error creating.", DateTime.Now);
                return null;
            }
            return lpf;
        }
        #endregion

        #region PhysicalPerson
        private int InsertPhysicalPerson()
        {
            try
            {
                String cmdStr = "INSERT INTO PHYSICALPERSON VALUES(@ID, @ID, @CPF, @SALARY, @BIRTHDAY, @GENDER);";
                this.CreateParameters();
                this.cmd.CommandText = cmdStr;
                this.cmd.ExecuteNonQuery();
                SetLog("InsertPhysicalPerson", "Successfully executed.", DateTime.Now);
                return 1;
            }
            catch (Exception)
            {
                SetLog("InsertPhysicalPerson", "Error while running.", DateTime.Now);
                return -1;
            }
        }

        private int EditPhysicalPerson()
        {
            try
            {
                String cmdStr = "UPDATE PHYSICALPERSON SET BIRTHDAY = @BIRTHDAY, SALARY = @SALARY, GENDER = @GENDER WHERE ID = @ID;";
                this.cmd.CommandType = CommandType.Text;
                this.CreateParameters();
                this.cmd.CommandText = cmdStr;
                this.cmd.ExecuteNonQuery();
                SetLog("EditPhysicalPerson", "Successfully executed.", DateTime.Now);
                return 1;
            }
            catch (Exception)
            {
                SetLog("EditPhysicalPerson", "Error while running.", DateTime.Now);
                return -1;
            }
        }

        private int DeletePhysicalPerson()
        {
            try
            {

                String cmdStr = "DELETE FROM PHYSICALPERSON WHERE ID = @ID;";
                this.cmd.CommandText = cmdStr;
                this.CreateUniqueParameter<int>("ID", this._pp.Id);
                this.cmd.ExecuteNonQuery();
                SetLog("DeletePhysicalPerson", "Successfully executed.", DateTime.Now);
                return 1;
            }
            catch (Exception)
            {
                SetLog("DeletePhysicalPerson", "Error while running.", DateTime.Now);
                return -1;
            }
        }
        #endregion

        #region Transactions
        public int Insert_PhysicalPerson()
        {
            IDbConnection conn = this.cmd.Connection;
            this.cmd.Transaction = this.cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted);
            IDbTransaction trans = this.cmd.Transaction;
            SetLog("Insert_PhysicalPerson", "Starting transaction.", DateTime.Now);

            int id = this.GenerateID();
            if (id > 0)
            {
                this._pp.Id = id;
                if (this.InsertPerson() == 1)
                {
                    if (this.InsertPhysicalPerson() == 1)
                    {
                        trans.Commit();
                        conn.Close();
                        SetLog("Insert_PhysicalPerson", "Successfully inserted.", DateTime.Now);
                        return 1;
                    }
                    else
                    {
                        trans.Rollback();
                        conn.Close();
                        SetLog("Insert_PhysicalPerson", "Rollback transaction.", DateTime.Now);
                        return -1;
                    }
                }
                else
                {
                    trans.Rollback();
                    conn.Close();
                    SetLog("Insert_PhysicalPerson", "Rollback transaction.", DateTime.Now);
                    return -1;
                }
            }
            else
            {
                conn.Close();
                SetLog("Insert_PhysicalPerson", "Error generating the ID.", DateTime.Now);
                return -1;
            }
        }

        public int Edit_PhysicalPerson()
        {
            IDbConnection conn = this.cmd.Connection;
            this.cmd.Transaction = this.cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted);
            IDbTransaction trans = this.cmd.Transaction;
            SetLog("Edit_PhysicalPerson", "Starting transaction.", DateTime.Now);

            if (this.EditPerson() == 1)
            {
                if (this.EditPhysicalPerson() == 1)
                {
                    trans.Commit();
                    conn.Close();
                    SetLog("Edit_PhysicalPerson", "Successfully edited.", DateTime.Now);
                    return 1;
                }
                else
                {
                    trans.Rollback();
                    conn.Close();
                    SetLog("Edit_PhysicalPerson", "Rollback transaction.", DateTime.Now);
                    return -1;
                }
            }
            else
            {
                trans.Rollback();
                conn.Close();
                SetLog("Edit_PhysicalPerson", "Rollback transaction.", DateTime.Now);
                return -1;
            }
        }

        public int Delete_PhysicalPerson()
        {
            IDbConnection conn = this.cmd.Connection;
            this.cmd.Transaction = this.cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted);
            IDbTransaction trans = this.cmd.Transaction;
            SetLog("Delete_PhysicalPerson", "Starting transaction.", DateTime.Now);

            if (this.DeletePhysicalPerson() == 1)
            {
                if (this.DeletePerson() == 1)
                {
                    trans.Commit();
                    conn.Close();
                    SetLog("Delete_PhysicalPerson", "Successfully deleted.", DateTime.Now);
                    return 1;
                }
                else
                {
                    trans.Rollback();
                    conn.Close();
                    SetLog("Delete_PhysicalPerson", "Rollback transaction.", DateTime.Now);
                    return -1;
                }
            }
            else
            {
                trans.Rollback();
                conn.Close();
                SetLog("Delete_PhysicalPerson", "Rollback transaction.", DateTime.Now);
                return -1;
            }
        }

        #endregion

        #region Search
        public PersonFacade GetPhysicalPersonByIdentity(OptionIdentity optionIdentity)
        {
            try
            {
                String cmdStr = "";

                switch (optionIdentity)
                {
                    case OptionIdentity.ID:
                        cmdStr = "SELECT * FROM PERSON INNER JOIN PHYSICALPERSON ON PERSON.ID = PHYSICALPERSON.PERSON_ID WHERE PHYSICALPERSON.ID = @ID;";
                        SetLog("GetPhysicalPersonByIdentity", "Get PhysicalPerson By Identity (ID).", DateTime.Now);
                        this.CreateUniqueParameter<int>("ID", this._pp.Id);
                        break;
                    case OptionIdentity.CPF:
                        cmdStr = "SELECT * FROM PERSON INNER JOIN PHYSICALPERSON ON PERSON.ID = PHYSICALPERSON.PERSON_ID WHERE PHYSICALPERSON.CPF = @CPF;";
                        SetLog("GetPhysicalPersonByIdentity", "Get PhysicalPerson By Identity (CPF).", DateTime.Now);
                        this.CreateUniqueParameter<string>("CPF", this._pp.Cpf);
                        break;
                }

                this.cmd.CommandType = CommandType.Text;
                this.cmd.CommandText = cmdStr;
                IDataReader reader = this.cmd.ExecuteReader();
                PersonFacade pf = this.CreatePersonFacadeList(reader)[0];
                reader.Close();
                this.cmd.Connection.Close();
                SetLog("GetPhysicalPersonByIdentity", "Search performed successfully.", DateTime.Now);
                return pf;
            }
            catch (Exception)
            {
                SetLog("GetPhysicalPersonByIdentity", "Error performing search.", DateTime.Now);
                return null;
            }
        }

        public override List<PersonFacade> GetPersonByName()
        {
            try
            {
                String cmdStr = "SELECT * FROM PERSON INNER JOIN PHYSICALPERSON ON PERSON.ID = PHYSICALPERSON.PERSON_ID WHERE NAME LIKE @NAME;";
                this.cmd.CommandText = cmdStr;
                this.CreateUniqueParameter<string>("NAME", this._pp.Name + '%');
                IDataReader reader = this.cmd.ExecuteReader();
                List<PersonFacade> list = this.CreatePersonFacadeList(reader);
                reader.Close();
                this.cmd.Connection.Close();
                SetLog("GetPersonByName", "Search performed successfully. (PhysicalPerson)", DateTime.Now);
                return list;
            }
            catch (Exception)
            {
                SetLog("GetPersonByName", "Error performing search. (PhysicalPerson)", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region Reports
        public List<PersonFacade> GetPhysicalPersonByAVGSalary(OptionAVGSalary optionAVG)
        {
            string cmdStr = "";

            try
            {
                switch (optionAVG)
                {
                    case OptionAVGSalary.Under:
                        cmdStr = "SELECT * FROM PERSON INNER JOIN PHYSICALPERSON ON PERSON.ID = PHYSICALPERSON.PERSON_ID WHERE SALARY < (SELECT AVG(SALARY) FROM PHYSICALPERSON);";
                        break;
                    case OptionAVGSalary.Equal:
                        cmdStr = "SELECT * FROM PERSON INNER JOIN PHYSICALPERSON ON PERSON.ID = PHYSICALPERSON.PERSON_ID WHERE SALARY = (SELECT AVG(SALARY) FROM PHYSICALPERSON);";
                        break;
                    case OptionAVGSalary.Above:
                        cmdStr = "SELECT * FROM PERSON INNER JOIN PHYSICALPERSON ON PERSON.ID = PHYSICALPERSON.PERSON_ID WHERE SALARY > (SELECT AVG(SALARY) FROM PHYSICALPERSON);";
                        break;
                }

                this.cmd.CommandText = cmdStr;
                this.cmd.CommandType = CommandType.Text;
                IDataReader reader = this.cmd.ExecuteReader();
                List<PersonFacade> list = this.CreatePersonFacadeList(reader);
                reader.Close();
                this.cmd.Connection.Close();
                SetLog("GetPhysicalPersonByAVGSalary", "Search performed successfully.", DateTime.Now);
                return list;
            }
            catch (Exception)
            {
                SetLog("GetPhysicalPersonByAVGSalary", "Error performing search.", DateTime.Now);
                throw;
            }
        }

        public PersonFacade GetPhysicalPersonBySalary(OptionSalary optionSalary)
        {
            string cmdStr = "";

            try
            {
                switch (optionSalary)
                {
                    case OptionSalary.Lower:
                        cmdStr = "SELECT * FROM PERSON INNER JOIN PHYSICALPERSON ON PERSON.ID = PHYSICALPERSON.PERSON_ID WHERE SALARY = (SELECT MIN(SALARY) FROM PHYSICALPERSON);";
                        break;
                    case OptionSalary.Higher:
                        cmdStr = "SELECT * FROM PERSON INNER JOIN PHYSICALPERSON ON PERSON.ID = PHYSICALPERSON.PERSON_ID WHERE SALARY = (SELECT MAX(SALARY) FROM PHYSICALPERSON);";
                        break;
                }

                this.cmd.CommandText = cmdStr;
                this.cmd.CommandType = CommandType.Text;
                IDataReader reader = this.cmd.ExecuteReader();
                PersonFacade pf = this.CreatePersonFacadeList(reader)[0];
                reader.Close();
                this.cmd.Connection.Close();
                SetLog("GetPhysicalPersonBySalary", "Search performed successfully.", DateTime.Now);
                return pf;
            }
            catch (Exception)
            {
                SetLog("GetPhysicalPersonBySalary", "Error performing search.", DateTime.Now);
                throw;
            }
        }

        public List<PersonFacade> GetPhysicalPersonByBirthMonth(int month)
        {
            try
            {
                String cmdStr = "";
                switch (this.cmd.ToString())
                {
                    case "System.Data.SqlClient.SqlCommand":
                        cmdStr = "SELECT * FROM PERSON INNER JOIN PHYSICALPERSON ON PERSON.ID = PHYSICALPERSON.PERSON_ID WHERE DATEPART(MONTH, BIRTHDAY) = @MONTH;";
                        break;
                    case "Npgsql.NpgsqlCommand":
                        cmdStr = "SELECT * FROM PERSON INNER JOIN PHYSICALPERSON ON PERSON.ID = PHYSICALPERSON.PERSON_ID WHERE EXTRACT(MONTH FROM BIRTHDAY) = " + month;
                        break;
                    case "System.Data.SQLite.SQLiteCommand":
                        cmdStr = "SELECT * FROM PERSON INNER JOIN PHYSICALPERSON ON PERSON.ID = PHYSICALPERSON.PERSON_ID WHERE STRFTIME('%m',BIRTHDAY) = @MONTH;";
                        break;
                    case "MySql.Data.MySqlClient.MySqlCommand":
                        cmdStr = "SELECT * FROM PERSON INNER JOIN PHYSICALPERSON ON PERSON.ID = PHYSICALPERSON.PERSON_ID WHERE MONTH(BIRTHDAY) = @MONTH;";
                        break;
                }

                this.cmd.CommandText = cmdStr;
                this.CreateUniqueParameter<string>("MONTH", month.ToString());
                IDataReader reader = this.cmd.ExecuteReader();
                List<PersonFacade> list = this.CreatePersonFacadeList(reader);
                reader.Close();
                this.cmd.Connection.Close();
                SetLog("GetPhysicalPersonByBirthMonth", "Search performed successfully.", DateTime.Now);
                return list;
            }
            catch (Exception)
            {
                SetLog("GetPhysicalPersonByBirthMonth", "Error performing search.", DateTime.Now);
                return null;
            }
        }

        public List<PersonFacade> GetPhysicalPersonBySalaryRange(decimal salaryInitial, decimal salaryFinal)
        {
            try
            {
                String cmdStr = "SELECT * FROM PERSON INNER JOIN PHYSICALPERSON ON PERSON.ID = PHYSICALPERSON.PERSON_ID WHERE SALARY BETWEEN @SAL1 AND @SAL2";
                this.cmd.CommandText = cmdStr;

                // Provisório
                IDbDataParameter p = this.cmd.CreateParameter();
                p.ParameterName = "@SAL1";
                p.Value = salaryInitial;
                this.cmd.Parameters.Add(p);

                p = this.cmd.CreateParameter();
                p.ParameterName = "@SAL2";
                p.Value = salaryFinal;
                this.cmd.Parameters.Add(p);
                // Provisório

                //this.CreateUniqueParameter<decimal>("SAL1", salaryInitial);
                //this.CreateUniqueParameter<decimal>("SAL2", salaryFinal);
                IDataReader reader = this.cmd.ExecuteReader();
                List<PersonFacade> list = this.CreatePersonFacadeList(reader);
                reader.Close();
                this.cmd.Connection.Close();
                SetLog("GetPhysicalPersonBySalaryRange", "Search performed successfully.", DateTime.Now);
                return list;
            }
            catch (Exception)
            {
                SetLog("GetPhysicalPersonBySalaryRange", "Error performing search.", DateTime.Now);
                return null;
            }
        }

        public List<PersonFacade> GetPhysicalPersonByGender(OptionGender gender)
        {
            try
            {
                String cmdStr = "SELECT * FROM PERSON INNER JOIN PHYSICALPERSON ON PERSON.ID = PHYSICALPERSON.PERSON_ID WHERE GENDER = @GENDER";
                this.cmd.CommandText = cmdStr;
                this.CreateUniqueParameter<char>("GENDER", gender.ToString()[0]);
                IDataReader reader = this.cmd.ExecuteReader();
                List<PersonFacade> list = this.CreatePersonFacadeList(reader);
                reader.Close();
                this.cmd.Connection.Close();
                SetLog("GetPhysicalPersonByGender", "Search performed successfully.", DateTime.Now);
                return list;
            }
            catch (Exception)
            {
                SetLog("GetPhysicalPersonByGender", "Error performing search.", DateTime.Now);
                return null;
            }
        }
        #endregion
    }
}