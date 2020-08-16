using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LibCrud
{
    public class Controller
    {
        #region Attributes
        private PhysicalPerson pp;
        private UserSys user;
        private Login login;
        private SqlConnection conn;
        private SqlCommand cmd;
        #endregion

        #region Constructors
        public Controller()
        {
            this.conn = Connection.Connect();
        }

        public Controller(PhysicalPerson pp)
        {
            this.conn = Connection.Connect();
            this.pp = pp;
        }

        public Controller(UserSys user)
        {
            this.conn = Connection.Connect();
            this.user = user;
            this.login = new Login();
        }
        #endregion

        #region PERSON
        private int Insert_Person(Int32 id, String name, String email)
        {
            try
            {
                String cmd_string = "INSERT INTO PERSON VALUES(@ID, @NAME, @EMAIL);";
                this.cmd.Parameters.Add("@ID", System.Data.SqlDbType.Int);
                this.cmd.Parameters["@ID"].Value = id;
                this.cmd.Parameters.Add("@NAME", System.Data.SqlDbType.VarChar);
                this.cmd.Parameters["@NAME"].Value = name;
                this.cmd.Parameters.Add("@EMAIL", System.Data.SqlDbType.VarChar);
                this.cmd.Parameters["@EMAIL"].Value = email;
                this.cmd.CommandText = cmd_string;
                this.cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private int Edit_Person(Int32 id, String name, String email)
        {
            try
            {
                String cmd_string = "UPDATE PERSON SET NAME = @NAME, EMAIL = @EMAIL WHERE ID = @ID;";
                
                this.cmd.Parameters.Add("@ID", System.Data.SqlDbType.Int);
                this.cmd.Parameters["@ID"].Value = id;
                this.cmd.Parameters.Add("@NAME", System.Data.SqlDbType.VarChar);
                this.cmd.Parameters["@NAME"].Value = name;
                this.cmd.Parameters.Add("@EMAIL", System.Data.SqlDbType.VarChar);
                this.cmd.Parameters["@EMAIL"].Value = email;
                this.cmd.CommandText = cmd_string;
                this.cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        
        private int Delete_Person()
        {
            try
            {
                String cmd_string = "DELETE FROM PERSON WHERE ID = @ID;";
                
                this.cmd.CommandText = cmd_string;
                this.cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        #endregion

        #region PHYSICAL_PERSON
        private int Insert_PhysicalPerson()
        {
            try
            {
                String cmd_string = "INSERT INTO PHYSICALPERSON VALUES(@ID, @ID, @SALARY, @DATEBIRTH, @GENRE);";
                
                this.cmd.Parameters.Add("@SALARY", System.Data.SqlDbType.Decimal);
                this.cmd.Parameters["@SALARY"].Value = this.pp.Salary;
                this.cmd.Parameters.Add("@DATEBIRTH", System.Data.SqlDbType.Date);
                this.cmd.Parameters["@DATEBIRTH"].Value = this.pp.DateBirth;
                this.cmd.Parameters.Add("@GENRE", System.Data.SqlDbType.Char);
                this.cmd.Parameters["@GENRE"].Value = this.pp.Genre;
                this.cmd.CommandText = cmd_string;
                this.cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private int Edit_PhysicalPerson()
        {
            try
            {
                String cmd_string = "UPDATE PHYSICALPERSON SET DATEBIRTH = @DATEBIRTH, SALARY = @SALARY, GENRE = @GENRE WHERE ID = @ID;";
                
                this.cmd.Parameters.Add("@DATEBIRTH", System.Data.SqlDbType.Date);
                this.cmd.Parameters["@DATEBIRTH"].Value = this.pp.DateBirth;
                this.cmd.Parameters.Add("@SALARY", System.Data.SqlDbType.Decimal);
                this.cmd.Parameters["@SALARY"].Value = this.pp.Salary;
                this.cmd.Parameters.Add("@GENRE", System.Data.SqlDbType.Char);
                this.cmd.Parameters["@GENRE"].Value = this.pp.Genre;
                this.cmd.CommandText = cmd_string;
                this.cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private int Delete_PhysicalPerson()
        {
            try
            {
                String cmd_string = "DELETE FROM PHYSICALPERSON WHERE ID = @ID;";
                this.cmd.Parameters.Add("@ID", System.Data.SqlDbType.Int);
                this.cmd.Parameters["@ID"].Value = this.pp.Id;
                this.cmd.CommandText = cmd_string;
                this.cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        #endregion

        #region UserSys
        private int Insert_UserSys()
        {
            try
            {
                String cmd_string = "INSERT INTO USERSYS VALUES(@ID, @USERNAME, HASHBYTES('SHA2_512',@USERPASS));";
                
                this.cmd.Parameters.Add("@ID", System.Data.SqlDbType.Int);
                this.cmd.Parameters["@ID"].Value = this.user.Id;
                this.cmd.Parameters.Add("@USERNAME", System.Data.SqlDbType.VarChar);
                this.cmd.Parameters["@USERNAME"].Value = this.user.Username;
                this.cmd.Parameters.Add("@USERPASS", System.Data.SqlDbType.VarChar);
                this.cmd.Parameters["@USERPASS"].Value = this.user.Userpass;
                this.cmd.CommandText = cmd_string;
                this.cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private int Delete_UserSys()
        {
            try
            {
                String cmd_string = "DELETE FROM USERSYS WHERE ID = @ID;";
                
                this.cmd.Parameters.Add("@ID", System.Data.SqlDbType.Int);
                this.cmd.Parameters["@ID"].Value = this.user.Id;
                this.cmd.CommandText = cmd_string;
                this.cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        #endregion

        #region LOGIN
        private int Insert_Login(int user_id)
        {
            try
            {
                String cmd_string = "INSERT INTO USERSYS_LOGIN VALUES(@ID, @USERSYS_ID, @DATE_NOW);";
                this.cmd.Parameters.Add("@ID", System.Data.SqlDbType.Int);
                this.cmd.Parameters["@ID"].Value = this.login.Id;
                this.cmd.Parameters.Add("@USERSYS_ID", System.Data.SqlDbType.Int);
                this.cmd.Parameters["@USERSYS_ID"].Value = user_id;
                this.cmd.Parameters.Add("@DATE_NOW", System.Data.SqlDbType.DateTime);
                this.cmd.Parameters["@DATE_NOW"].Value = DateTime.Now;
                this.cmd.CommandText = cmd_string;
                this.cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        #endregion

        #region Generate ID for insertion
        private int Generate_InsertIDPhysicalPerson()
        {
            try
            {
                String cmd_string = "SELECT ISNULL(MAX(ID)+1, 1) FROM PERSON;";
                this.cmd.CommandText = cmd_string;
                return (int)this.cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private int Generate_InsertIDUserSys()
        {
            try
            {
                String cmd_string = "SELECT ISNULL(MAX(ID)+1, 1) FROM USERSYS;";
                this.cmd.CommandText = cmd_string;
                return (int)this.cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private int Generate_InsertIDLogin()
        {
            try
            {
                String cmd_string = "SELECT ISNULL(MAX(ID)+1, 1) FROM USERSYS_LOGIN;";
                this.cmd.CommandText = cmd_string;
                return (int)this.cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                return -1;
            }
        }
        #endregion

        #region Search for PhysicalPerson
        public List<PhysicalPerson> GetPhysicalPerson_ByName()
        {
            try
            {
                String cmd_string = "SELECT * FROM PERSON INNER JOIN PHYSICALPERSON ON PERSON.ID = PHYSICALPERSON.PERSON_ID WHERE NAME LIKE @NAME + '%';";
                this.cmd = new SqlCommand();
                this.cmd.Connection = this.conn;
                this.cmd.CommandText = cmd_string;
                this.cmd.Parameters.Add("@NAME", System.Data.SqlDbType.VarChar);
                this.cmd.Parameters["@NAME"].Value = this.pp.Name;
                SqlDataReader sqr = this.cmd.ExecuteReader();
                if (sqr.HasRows)
                {
                    List<PhysicalPerson> list = new List<PhysicalPerson>();
                    while (sqr.Read())
                    {
                        PhysicalPerson p = new PhysicalPerson();
                        p.Id = sqr.GetInt32(0);
                        p.Name = sqr.GetString(1);
                        p.Email = sqr.GetString(2);
                        p.Salary = sqr.GetDecimal(5);
                        p.DateBirth = sqr.GetDateTime(6);
                        p.Genre = sqr.GetString(7)[0];
                        list.Add(p);
                    }
                    return list;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PhysicalPerson GetPhysicalPerson_ByID()
        {
            try
            {
                String cmd_string = "SELECT * FROM PERSON INNER JOIN PHYSICALPERSON ON PERSON.ID = PHYSICALPERSON.PERSON_ID WHERE PERSON.ID = @ID;";
                this.cmd = new SqlCommand();
                this.cmd.Connection = this.conn;
                this.cmd.CommandText = cmd_string;
                this.cmd.Parameters.Add("@ID", System.Data.SqlDbType.Int);
                this.cmd.Parameters["@ID"].Value = this.pp.Id;
                SqlDataReader sqr = this.cmd.ExecuteReader();
                if (sqr.HasRows)
                {
                    PhysicalPerson p = new PhysicalPerson();
                    sqr.Read();
                    p.Id = sqr.GetInt32(0);
                    p.Name = sqr.GetString(1);
                    p.Email = sqr.GetString(2);
                    p.Salary = sqr.GetDecimal(5);
                    p.DateBirth = sqr.GetDateTime(6);
                    p.Genre = sqr.GetString(7)[0];
                    return p;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Reports
        public List<PhysicalPerson> GetPhysicalPerson_SalaryAboveAVG()
        {
            try
            {
                String cmd_string = "SELECT * FROM PERSON INNER JOIN PHYSICALPERSON ON PERSON.ID = PHYSICALPERSON.PERSON_ID WHERE SALARY > (SELECT AVG(SALARY) FROM PHYSICALPERSON);";
                this.cmd = new SqlCommand();
                this.cmd.Connection = this.conn;
                this.cmd.CommandText = cmd_string;
                SqlDataReader sqr = this.cmd.ExecuteReader();
                if (sqr.HasRows)
                {
                    List<PhysicalPerson> list = new List<PhysicalPerson>();
                    while (sqr.Read())
                    {
                        PhysicalPerson p = new PhysicalPerson();
                        p.Id = sqr.GetInt32(0);
                        p.Name = sqr.GetString(1);
                        p.Email = sqr.GetString(2);
                        p.Salary = sqr.GetDecimal(5);
                        p.DateBirth = sqr.GetDateTime(6);
                        p.Genre = sqr.GetString(7)[0];
                        list.Add(p);
                        sqr.NextResult();
                    }
                    return list;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PhysicalPerson> GetPhysicalPerson_SalaryUnderAVG()
        {
            try
            {
                String cmd_string = "SELECT * FROM PERSON INNER JOIN PHYSICALPERSON ON PERSON.ID = PHYSICALPERSON.PERSON_ID WHERE SALARY < (SELECT AVG(SALARY) FROM PHYSICALPERSON);";
                this.cmd = new SqlCommand();
                this.cmd.Connection = this.conn;
                this.cmd.CommandText = cmd_string;
                SqlDataReader sqr = this.cmd.ExecuteReader();
                if (sqr.HasRows)
                {
                    List<PhysicalPerson> list = new List<PhysicalPerson>();
                    while (sqr.Read())
                    {
                        PhysicalPerson p = new PhysicalPerson();
                        p.Id = sqr.GetInt32(0);
                        p.Name = sqr.GetString(1);
                        p.Email = sqr.GetString(2);
                        p.Salary = sqr.GetDecimal(5);
                        p.DateBirth = sqr.GetDateTime(6);
                        p.Genre = sqr.GetString(7)[0];
                        list.Add(p);
                        sqr.NextResult();
                    }
                    return list;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PhysicalPerson> GetPhysicalPerson_SalaryEqualAVG()
        {
            try
            {
                String cmd_string = "SELECT * FROM PERSON INNER JOIN PHYSICALPERSON ON PERSON.ID = PHYSICALPERSON.PERSON_ID WHERE SALARY = (SELECT AVG(SALARY) FROM PHYSICALPERSON);";
                this.cmd = new SqlCommand();
                this.cmd.Connection = this.conn;
                this.cmd.CommandText = cmd_string;
                SqlDataReader sqr = this.cmd.ExecuteReader();
                if (sqr.HasRows)
                {
                    List<PhysicalPerson> list = new List<PhysicalPerson>();
                    while (sqr.Read())
                    {
                        PhysicalPerson p = new PhysicalPerson();
                        p.Id = sqr.GetInt32(0);
                        p.Name = sqr.GetString(1);
                        p.Email = sqr.GetString(2);
                        p.Salary = sqr.GetDecimal(5);
                        p.DateBirth = sqr.GetDateTime(6);
                        p.Genre = sqr.GetString(7)[0];
                        list.Add(p);
                        sqr.NextResult();
                    }
                    return list;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PhysicalPerson GetPhysicalPerson_HigherSalary()
        {
            try
            {
                String cmd_string = "SELECT * FROM PERSON INNER JOIN PHYSICALPERSON ON PERSON.ID = PHYSICALPERSON.PERSON_ID WHERE SALARY = (SELECT MAX(SALARY) FROM PHYSICALPERSON);";
                this.cmd = new SqlCommand();
                this.cmd.Connection = this.conn;
                this.cmd.CommandText = cmd_string;
                SqlDataReader sqr = this.cmd.ExecuteReader();
                if (sqr.HasRows)
                {
                    PhysicalPerson p = new PhysicalPerson();
                    sqr.Read();
                    p.Id = sqr.GetInt32(0);
                    p.Name = sqr.GetString(1);
                    p.Email = sqr.GetString(2);
                    p.Salary = sqr.GetDecimal(5);
                    p.DateBirth = sqr.GetDateTime(6);
                    p.Genre = sqr.GetString(7)[0];
                    return p;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PhysicalPerson GetPhysicalPerson_LowerSalary()
        {
            try
            {
                String cmd_string = "SELECT * FROM PERSON INNER JOIN PHYSICALPERSON ON PERSON.ID = PHYSICALPERSON.PERSON_ID WHERE SALARY = (SELECT MIN(SALARY) FROM PHYSICALPERSON);";
                this.cmd = new SqlCommand();
                this.cmd.Connection = this.conn;
                this.cmd.CommandText = cmd_string;
                SqlDataReader sqr = this.cmd.ExecuteReader();
                if (sqr.HasRows)
                {
                    PhysicalPerson p = new PhysicalPerson();
                    sqr.Read();
                    p.Id = sqr.GetInt32(0);
                    p.Name = sqr.GetString(1);
                    p.Email = sqr.GetString(2);
                    p.Salary = sqr.GetDecimal(5);
                    p.DateBirth = sqr.GetDateTime(6);
                    p.Genre = sqr.GetString(7)[0];
                    return p;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PhysicalPerson> GetPhysicalPerson_ByBirthMonth(int month)
        {
            try
            {
                String cmd_string = "SELECT * FROM PERSON INNER JOIN PHYSICALPERSON ON PERSON.ID = PHYSICALPERSON.PERSON_ID WHERE DATEPART(MONTH, DATEBIRTH) = @MONTH";
                this.cmd = new SqlCommand();
                this.cmd.Connection = this.conn;
                this.cmd.CommandText = cmd_string;
                this.cmd.Parameters.Add("@MONTH", System.Data.SqlDbType.Int);
                this.cmd.Parameters["@MONTH"].Value = month;
                SqlDataReader sqr = this.cmd.ExecuteReader();
                if (sqr.HasRows)
                {
                    List<PhysicalPerson> list = new List<PhysicalPerson>();
                    while (sqr.Read())
                    {
                        PhysicalPerson p = new PhysicalPerson();
                        p.Id = sqr.GetInt32(0);
                        p.Name = sqr.GetString(1);
                        p.Email = sqr.GetString(2);
                        p.Salary = sqr.GetDecimal(5);
                        p.DateBirth = sqr.GetDateTime(6);
                        p.Genre = sqr.GetString(7)[0];
                        list.Add(p);
                    }
                    return list;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PhysicalPerson> GetPhysicalPerson_BySalaryRange(decimal sal1, decimal sal2)
        {
            try
            {
                String cmd_string = "SELECT * FROM PERSON INNER JOIN PHYSICALPERSON ON PERSON.ID = PHYSICALPERSON.PERSON_ID WHERE SALARY BETWEEN @SAL1 AND @SAL2";
                this.cmd = new SqlCommand();
                this.cmd.Connection = this.conn;
                this.cmd.CommandText = cmd_string;
                this.cmd.Parameters.Add("@SAL1", System.Data.SqlDbType.Decimal);
                this.cmd.Parameters["@SAL1"].Value = sal1;
                this.cmd.Parameters.Add("@SAL2", System.Data.SqlDbType.Decimal);
                this.cmd.Parameters["@SAL2"].Value = sal2;
                SqlDataReader sqr = this.cmd.ExecuteReader();
                if (sqr.HasRows)
                {
                    List<PhysicalPerson> list = new List<PhysicalPerson>();
                    while (sqr.Read())
                    {
                        PhysicalPerson p = new PhysicalPerson();
                        p.Id = sqr.GetInt32(0);
                        p.Name = sqr.GetString(1);
                        p.Email = sqr.GetString(2);
                        p.Salary = sqr.GetDecimal(5);
                        p.DateBirth = sqr.GetDateTime(6);
                        p.Genre = sqr.GetString(7)[0];
                        list.Add(p);
                    }
                    return list;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GetCountPhysicalPerson_ByGenre(char genre)
        {
            try
            {
                String cmd_string = "SELECT COUNT(*) FROM PERSON INNER JOIN PHYSICALPERSON ON PERSON.ID = PHYSICALPERSON.PERSON_ID WHERE GENRE = @GENRE";
                this.cmd = new SqlCommand();
                this.cmd.Connection = this.conn;
                this.cmd.CommandText = cmd_string;
                this.cmd.Parameters.Add("@GENRE", System.Data.SqlDbType.Char);
                this.cmd.Parameters["@GENRE"].Value = genre;
                return (int)this.cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region TO LOG
        public int ToLog_UserSys()
        {
            try
            {
                String cmd_string = "SELECT * FROM USERSYS WHERE CAST(USERNAME AS varbinary(100)) = CAST(@USERNAME as varbinary(100)) AND CAST(USERPASS AS varbinary(200)) = CAST(HASHBYTES('SHA2_512', @USERPASS) as varbinary(200))";
                this.cmd = new SqlCommand();
                this.cmd.Connection = this.conn;
                this.cmd.CommandText = cmd_string;
                this.cmd.Parameters.Add("@USERNAME", System.Data.SqlDbType.VarChar);
                this.cmd.Parameters["@USERNAME"].Value = this.user.Username;
                this.cmd.Parameters.Add("@USERPASS", System.Data.SqlDbType.VarChar);
                this.cmd.Parameters["@USERPASS"].Value = this.user.Userpass;
                SqlDataReader sqr = this.cmd.ExecuteReader();
                if (sqr.HasRows)
                {
                    sqr.Read();
                    Int32 user_id = sqr.GetInt32(0);
                    sqr.Close();
                    this.Insert_Login_tr(user_id);
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        
        #region Transactions
        public int Insert_PhysicalPerson_tr()
        {
            this.cmd = new SqlCommand();
            this.cmd.Connection = this.conn;
            this.cmd.Transaction = this.conn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            SqlTransaction  trans = this.cmd.Transaction;

            int id = this.Generate_InsertIDPhysicalPerson();
            if (id > 0)
            {
                this.pp.Id = id;
                if (this.Insert_Person(this.pp.Id, this.pp.Name, this.pp.Email) == 1)
                {
                    if(this.Insert_PhysicalPerson() == 1)
                    {
                        trans.Commit();
                        this.conn.Close();
                        return 1;
                    }
                    else
                    {
                        trans.Rollback();
                        this.conn.Close();
                        return -1;
                    }
                }
                else
                {
                    trans.Rollback();
                    this.conn.Close();
                    return -1;
                }
            }
            else
            {
                this.conn.Close();
                return -1;
            }
        }

        public int Edit_PhysicalPerson_tr()
        {
            this.cmd = new SqlCommand();
            this.cmd.Connection = this.conn;
            this.cmd.Transaction = this.conn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            SqlTransaction trans = this.cmd.Transaction;

           if (this.Edit_Person(this.pp.Id, this.pp.Name, this.pp.Email) == 1)
           {
                if (this.Edit_PhysicalPerson() == 1)
                {
                    trans.Commit();
                    this.conn.Close();
                    return 1;
                }
                else
                {
                    trans.Rollback();
                    this.conn.Close();
                    return -1;
                }
           }
           else
           {
               trans.Rollback();
               this.conn.Close();
               return -1;
           }
        }

        public int Delete_PhysicalPerson_tr()
        {
            this.cmd = new SqlCommand();
            this.cmd.Connection = this.conn;
            this.cmd.Transaction = this.conn.BeginTransaction(System.Data.IsolationLevel.Serializable);
            SqlTransaction trans = this.cmd.Transaction;

            if (this.Delete_PhysicalPerson() == 1)
            {
                if (this.Delete_Person() == 1)
                {
                    trans.Commit();
                    this.conn.Close();
                    return 1;
                }
                else
                {
                    trans.Rollback();
                    this.conn.Close();
                    return -1;
                }
            }
            else
            {
                trans.Rollback();
                this.conn.Close();
                return -1;
            }
        }

        private int Insert_Login_tr(Int32 user_id)
        {
            this.cmd = new SqlCommand();
            this.cmd.Connection = this.conn;
            this.cmd.Transaction = this.conn.BeginTransaction(System.Data.IsolationLevel.Serializable);
            SqlTransaction trans = this.cmd.Transaction;
            int id = this.Generate_InsertIDLogin();
            if (id > 0)
            {
                this.login.Id = id;
                if (this.Insert_Login(user_id) == 1)
                {
                    trans.Commit();
                    this.conn.Close();
                    return 1;
                }
                else
                {
                    trans.Rollback();
                    this.conn.Close();
                    return -1;
                }
            }
            else
            {
                trans.Rollback();
                this.conn.Close();
                return -1;
            }
        }

        public int Insert_UserSys_tr()
        {
            this.cmd = new SqlCommand();
            this.cmd.Connection = this.conn;
            this.cmd.Transaction = this.conn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            SqlTransaction trans = this.cmd.Transaction;

            int id = this.Generate_InsertIDUserSys();
            if (id > 0)
            {
                this.user.Id = id;
                if (this.Insert_UserSys() == 1)
                {
                    trans.Commit();
                    this.conn.Close();
                    return 1;
                }
                else
                {
                    trans.Rollback();
                    this.conn.Close();
                    return -1;
                }
            }
            else
            {
                trans.Rollback();
                this.conn.Close();
                return -1;
            }
        }

        public int Delete_UserSys_tr()
        {
            this.cmd = new SqlCommand();
            this.cmd.Connection = this.conn;
            this.cmd.Transaction = this.conn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            SqlTransaction trans = this.cmd.Transaction;

            if (this.Delete_UserSys() == 1)
            {
                trans.Commit();
                this.conn.Close();
                return 1;
            }
            else
            {
                trans.Rollback();
                this.conn.Close();
                return -1;
            }
        }
        #endregion
    }
}