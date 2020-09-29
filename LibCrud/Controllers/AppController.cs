using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LibCrud
{
    class AppController
    {
        #region Attributes
        protected IDbCommand _cmd = ConnectionFactory.getInstance().getConnection().CreateCommand();
        protected Log _log = Log.GetLogInstance;
        private ConfigurationDatabase _config = null;
        #endregion

        private List<string> _statementList = null;
        private string _statement = null;

        public AppController()
        {
        }

        public AppController(string statement)
        {
            _statement = statement;
        }

        public int ExecuteSQL()
        {
            try
            {
                IDbConnection conn = _cmd.Connection;
                _cmd.Transaction = _cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted);
                IDbTransaction trans = _cmd.Transaction;
                SetLog("ExecuteSQL", "Starting transaction.", DateTime.Now);

                if (_statementList != null)
                {
                    foreach (string statement in _statementList)
                    {
                        try
                        {
                            _cmd.CommandType = CommandType.Text;
                            _cmd.CommandText = statement;
                            _cmd.ExecuteNonQuery();
                            SetLog(string.Format("SQL: {0}", statement), "Successfully executed.", DateTime.Now);
                        }
                        catch (Exception)
                        {
                            trans.Rollback();
                            conn.Close();
                            SetLog(string.Format("SQL: {0}", statement), "Error executing.", DateTime.Now);
                            return -1;
                        }
                    }
                }

                if (_statement != null)
                {
                    try
                    {
                        _cmd.CommandType = CommandType.Text;
                        _cmd.CommandText = _statement;
                        _cmd.ExecuteNonQuery();
                        SetLog(string.Format("SQL: {0}", _statement), "Successfully executed.", DateTime.Now);
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        conn.Close();
                        SetLog(string.Format("SQL: {0}", _statement), "Error executing.", DateTime.Now);
                        return -1;
                    }
                }

                trans.Commit();
                conn.Close();
                SetLog("ExecuteSQL", "Transaction successfully executed.", DateTime.Now);
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int CreateTables()
        {
            string providerName = GetProviderName();
            if (providerName == null)
            {
                return -1;
            }

            _statementList = new List<string>();
            _statementList.Clear();

            switch (providerName)
            {
                case "System.Data.SqlClient":
                    _statementList.Add("IF OBJECT_ID('\"USER\"', 'U') IS NOT NULL DROP TABLE \"USER\";");
                    _statementList.Add("IF OBJECT_ID('JURIDICALPERSON', 'U') IS NOT NULL DROP TABLE JURIDICALPERSON;");
                    _statementList.Add("IF OBJECT_ID('PHYSICALPERSON', 'U') IS NOT NULL DROP TABLE PHYSICALPERSON;");
                    _statementList.Add("IF OBJECT_ID('PERSON', 'U') IS NOT NULL DROP TABLE PERSON;");
                    _statementList.Add("CREATE TABLE PERSON (ID INTEGER NOT NULL, NAME VARCHAR(45) NOT NULL, EMAIL VARCHAR(45) NOT NULL, STATUS SMALLINT NOT NULL, COMMENT VARCHAR(200) NOT NULL, CREATEAT DATETIME NOT NULL, CONSTRAINT PK_PERSON PRIMARY KEY (ID), CONSTRAINT CHK_STATUS_PERSON CHECK((STATUS = 1) OR (STATUS = 0)), CONSTRAINT UNQ_EMAIL_PERSON UNIQUE(EMAIL) );");
                    _statementList.Add("CREATE TABLE PHYSICALPERSON (ID INTEGER NOT NULL, PERSON_ID INTEGER NOT NULL, CPF CHAR(11) NOT NULL, SALARY DECIMAL(12,2) NOT NULL, BIRTHDAY DATE NOT NULL, GENDER CHAR(1) NOT NULL, CONSTRAINT PK_PHYSICALPERSON PRIMARY KEY(ID), CONSTRAINT FK_PHYSICALPERSON_PERSON FOREIGN KEY (PERSON_ID) REFERENCES PERSON(ID), CONSTRAINT UNQ_CPF_PHYSICALPERSON UNIQUE(CPF), CONSTRAINT CHK_SALARY_PHYSICALPERSON CHECK((SALARY >= 0) AND (SALARY <= 999999999999.99)), CONSTRAINT CHK_BIRTHDAY_PHYSICALPERSON CHECK(BIRTHDAY <= DATEADD(year, -18, GETDATE())), CONSTRAINT CHK_GENDER_PHYSICALPERSON CHECK(GENDER = 'M' OR GENDER = 'F'));");
                    _statementList.Add("CREATE TABLE JURIDICALPERSON (ID INTEGER NOT NULL, PERSON_ID INTEGER NOT NULL, CNPJ CHAR(14) NOT NULL, COMPANYNAME VARCHAR(45) NOT NULL, CONSTRAINT PK_JURIDICALPERSON PRIMARY KEY(ID), CONSTRAINT FK_JURIDICALPERSON_PERSON FOREIGN KEY (PERSON_ID) REFERENCES PERSON(ID), CONSTRAINT UNQ_CNPJ_JURIDICALPERSON UNIQUE(CNPJ));");
                    _statementList.Add("CREATE TABLE \"USER\" (ID INTEGER IDENTITY(1,1) NOT NULL, NAME VARCHAR(45) NOT NULL, USERNAME VARCHAR(128) NOT NULL, PASSWORD VARCHAR(128) NOT NULL, TYPEUSER INT NOT NULL, CREATEAT DATETIME NOT NULL, CONSTRAINT PK_USER PRIMARY KEY(ID), CONSTRAINT UNQ_USERNAME_USER UNIQUE(USERNAME));");
                    _statementList.Add("INSERT \"USER\" ([NAME], [USERNAME], [PASSWORD], [TYPEUSER], [CREATEAT]) VALUES (N'Administrator', N'c7ad44cbad762a5da0a452f9e854fdc1e0e7a52a38015f23f3eab1d80b931dd472634dfac71cd34ebc35d16ab7fb8a90c81f975113d6c7538dc69dd8de9077ec', N'c7ad44cbad762a5da0a452f9e854fdc1e0e7a52a38015f23f3eab1d80b931dd472634dfac71cd34ebc35d16ab7fb8a90c81f975113d6c7538dc69dd8de9077ec', 1, GETDATE());");
                    break;
                case "Npgsql":
                    _statementList.Add("SET check_function_bodies = false;");
                    _statementList.Add("SET search_path = public, pg_catalog;");
                    _statementList.Add("DROP TABLE IF EXISTS public.physicalperson;");
                    _statementList.Add("CREATE TABLE public.physicalperson (id integer NOT NULL, person_id integer NOT NULL, cpf char(11) NOT NULL, salary numeric(12,2) NOT NULL, birthday date NOT NULL, gender char(1) NOT NULL, CONSTRAINT chk_birthday_physicalperson CHECK ((birthday <= (CURRENT_DATE + '-18 years'::interval))), CONSTRAINT chk_gender_physicalperson CHECK (((gender = 'M'::bpchar) OR (gender = 'F'::bpchar))), CONSTRAINT chk_salary_physicalperson CHECK (((salary >= (0)::numeric) AND (salary <= 999999999999.99))) ) WITH (oids = false);");
                    _statementList.Add("DROP TABLE IF EXISTS public.juridicalperson;");
                    _statementList.Add("CREATE TABLE public.juridicalperson (id integer NOT NULL, person_id integer NOT NULL, cnpj char(14) NOT NULL, companyname varchar(45) NOT NULL ) WITH (oids = false);");
                    _statementList.Add("DROP TABLE IF EXISTS public.person;");
                    _statementList.Add("CREATE TABLE public.person (id integer NOT NULL, name varchar(45) NOT NULL, email varchar(45) NOT NULL, status smallint NOT NULL, comment varchar(200) NOT NULL, createat timestamp without time zone NOT NULL, CONSTRAINT chk_status_person CHECK (((status = 1) OR (status = 0))) ) WITH (oids = false);");
                    _statementList.Add("DROP TABLE IF EXISTS public.\"user\";");
                    _statementList.Add("CREATE TABLE public.\"user\" (id serial NOT NULL, name varchar(45) NOT NULL, username varchar(128) NOT NULL, password varchar(128) NOT NULL, typeuser numeric(1,0) NOT NULL, createat timestamp without time zone NOT NULL ) WITH (oids = false);");
                    _statementList.Add("ALTER TABLE ONLY person ADD CONSTRAINT pk_person PRIMARY KEY (id);");
                    _statementList.Add("ALTER TABLE ONLY person ADD CONSTRAINT unq_email_person UNIQUE (email);");
                    _statementList.Add("ALTER TABLE ONLY physicalperson ADD CONSTRAINT pk_physicalperson PRIMARY KEY (id);");
                    _statementList.Add("ALTER TABLE ONLY physicalperson ADD CONSTRAINT unq_cpf_physicalperson UNIQUE (cpf);");
                    _statementList.Add("ALTER TABLE ONLY physicalperson ADD CONSTRAINT fk_physicalperson_person FOREIGN KEY (person_id) REFERENCES person(id);");
                    _statementList.Add("ALTER TABLE ONLY juridicalperson ADD CONSTRAINT pk_juridicalperson PRIMARY KEY (id);");
                    _statementList.Add("ALTER TABLE ONLY juridicalperson ADD CONSTRAINT unq_cnpj_juridicalperson UNIQUE (cnpj);");
                    _statementList.Add("ALTER TABLE ONLY juridicalperson ADD CONSTRAINT fk_juridicalperson_person FOREIGN KEY (person_id) REFERENCES person(id);");
                    _statementList.Add("ALTER TABLE ONLY \"user\" ADD CONSTRAINT user_pkey PRIMARY KEY (id);");
                    _statementList.Add("ALTER TABLE ONLY \"user\" ADD CONSTRAINT unq_username_user UNIQUE (username);");
                    _statementList.Add("SELECT pg_catalog.setval('user_id_seq', 1, true);");
                    _statementList.Add("COMMENT ON SCHEMA public IS 'standard public schema';");
                    _statementList.Add("INSERT INTO \"user\" (id, name, username, password, typeuser, createat) VALUES (1, 'Administrator', 'c7ad44cbad762a5da0a452f9e854fdc1e0e7a52a38015f23f3eab1d80b931dd472634dfac71cd34ebc35d16ab7fb8a90c81f975113d6c7538dc69dd8de9077ec', 'c7ad44cbad762a5da0a452f9e854fdc1e0e7a52a38015f23f3eab1d80b931dd472634dfac71cd34ebc35d16ab7fb8a90c81f975113d6c7538dc69dd8de9077ec', 1, CURRENT_DATE);");
                    break;
                case "MySql.Data.MySqlClient":
                    _statementList.Add("SET NAMES utf8mb4;");
                    _statementList.Add("SET FOREIGN_KEY_CHECKS = 0;");
                    _statementList.Add("DROP TABLE IF EXISTS `juridicalperson`;");
                    _statementList.Add("CREATE TABLE `juridicalperson` (`ID` int(0) NOT NULL,`PERSON_ID` int(0) NOT NULL,`CNPJ` char(14) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,`COMPANYNAME` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,PRIMARY KEY (`ID`) USING BTREE,UNIQUE INDEX `UNQ_CNPJ_JURIDICALPERSON`(`CNPJ`) USING BTREE,INDEX `FK_JURIDICALPERSON_PERSON`(`PERSON_ID`) USING BTREE,CONSTRAINT `FK_JURIDICALPERSON_PERSON` FOREIGN KEY (`PERSON_ID`) REFERENCES `person` (`ID`) ON DELETE RESTRICT ON UPDATE RESTRICT ) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;");
                    _statementList.Add("DROP TABLE IF EXISTS `physicalperson`;");
                    _statementList.Add("CREATE TABLE `physicalperson`  (`ID` int(0) NOT NULL,`PERSON_ID` int(0) NOT NULL,`CPF` char(11) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,`SALARY` decimal(12, 2) NOT NULL,`BIRTHDAY` date NOT NULL,`GENDER` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,PRIMARY KEY (`ID`) USING BTREE,UNIQUE INDEX `UNQ_CPF_PHYSICALPERSON`(`CPF`) USING BTREE,INDEX `FK_PHYSICALPERSON_PERSON`(`PERSON_ID`) USING BTREE,CONSTRAINT `FK_PHYSICALPERSON_PERSON` FOREIGN KEY (`PERSON_ID`) REFERENCES `person` (`ID`) ON DELETE RESTRICT ON UPDATE RESTRICT ) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;");
                    _statementList.Add("DROP TABLE IF EXISTS `person`;");
                    _statementList.Add("CREATE TABLE `person` (`ID` int(0) NOT NULL,`NAME` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,`EMAIL` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,`STATUS` smallint(0) NOT NULL,`COMMENT` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,`CREATEAT` timestamp(0) NOT NULL,PRIMARY KEY (`ID`) USING BTREE,UNIQUE INDEX `UNQ_EMAIL_PERSON`(`EMAIL`) USING BTREE ) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;");
                    _statementList.Add("DROP TABLE IF EXISTS `user`;");
                    _statementList.Add("CREATE TABLE `user` (`ID` int(0) NOT NULL AUTO_INCREMENT,`NAME` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,`USERNAME` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,`PASSWORD` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,`TYPEUSER` tinyint(1) NOT NULL,`CREATEAT` timestamp(0) NOT NULL,PRIMARY KEY (`ID`) USING BTREE,UNIQUE INDEX `UNQ_USERNAME_USER`(`USERNAME`) USING BTREE ) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;");
                    _statementList.Add("INSERT INTO `user` VALUES (1, 'Administrator', 'c7ad44cbad762a5da0a452f9e854fdc1e0e7a52a38015f23f3eab1d80b931dd472634dfac71cd34ebc35d16ab7fb8a90c81f975113d6c7538dc69dd8de9077ec', 'c7ad44cbad762a5da0a452f9e854fdc1e0e7a52a38015f23f3eab1d80b931dd472634dfac71cd34ebc35d16ab7fb8a90c81f975113d6c7538dc69dd8de9077ec', 1, NOW());");
                    _statementList.Add("SET FOREIGN_KEY_CHECKS = 1;");
                    break;
                default:
                    _statementList.Add("PRAGMA foreign_keys = off;");
                    _statementList.Add("DROP TABLE IF EXISTS PERSON;");
                    _statementList.Add("CREATE TABLE PERSON (ID INTEGER NOT NULL, NAME VARCHAR(45) NOT NULL, EMAIL VARCHAR(45) NOT NULL, STATUS TINYINT(1) NOT NULL, COMMENT VARCHAR(200) NOT NULL, CREATEAT TIMESTAMP NOT NULL, CONSTRAINT PK_PERSON PRIMARY KEY (ID), CONSTRAINT CHK_STATUS_PERSON CHECK(STATUS IN (1,0)), CONSTRAINT UNQ_EMAIL_PERSON UNIQUE(EMAIL));");
                    _statementList.Add("DROP TABLE IF EXISTS PHYSICALPERSON;");
                    _statementList.Add("CREATE TABLE PHYSICALPERSON (ID INTEGER NOT NULL, PERSON_ID INTEGER NOT NULL, CPF CHAR (11) NOT NULL, SALARY DECIMAL (12, 2) NOT NULL, BIRTHDAY DATE NOT NULL, GENDER VARCHAR (1) NOT NULL, CONSTRAINT PK_PERSON PRIMARY KEY (ID), CONSTRAINT FK_PHYSICALPERSON_PERSON FOREIGN KEY (PERSON_ID) REFERENCES PERSON (ID), CONSTRAINT UNQ_CPF_PHYSICALPERSON UNIQUE (CPF), CONSTRAINT CHK_SALARY_PHYSICALPERSON CHECK ((SALARY >= 0) AND (SALARY <= 999999999999.99)));");
                    _statementList.Add("DROP TABLE IF EXISTS JURIDICALPERSON;");
                    _statementList.Add("CREATE TABLE JURIDICALPERSON (ID INTEGER NOT NULL, PERSON_ID INTEGER NOT NULL, CNPJ CHAR(14) NOT NULL, COMPANYNAME VARCHAR(45) NOT NULL, CONSTRAINT PK_PERSON PRIMARY KEY(ID), CONSTRAINT FK_JURIDICALPERSON_PERSON FOREIGN KEY (PERSON_ID) REFERENCES PERSON(ID), CONSTRAINT UNQ_CNPJ_JURIDICALPERSON UNIQUE(CNPJ));");
                    _statementList.Add("DROP TABLE IF EXISTS USER;");
                    _statementList.Add("CREATE TABLE USER (ID INTEGER CONSTRAINT PK_USER PRIMARY KEY AUTOINCREMENT, NAME VARCHAR(45) NOT NULL, USERNAME VARCHAR(128) NOT NULL, PASSWORD VARCHAR(128) NOT NULL, TYPEUSER TINYINT(1) NOT NULL, CREATEAT TIMESTAMP NOT NULL, CONSTRAINT UNQ_USERNAME_USER UNIQUE(USERNAME));");
                    _statementList.Add("INSERT INTO USER (ID, NAME, USERNAME, PASSWORD, TYPEUSER, CREATEAT) VALUES (1, 'Administrator', 'c7ad44cbad762a5da0a452f9e854fdc1e0e7a52a38015f23f3eab1d80b931dd472634dfac71cd34ebc35d16ab7fb8a90c81f975113d6c7538dc69dd8de9077ec', 'c7ad44cbad762a5da0a452f9e854fdc1e0e7a52a38015f23f3eab1d80b931dd472634dfac71cd34ebc35d16ab7fb8a90c81f975113d6c7538dc69dd8de9077ec', 1,'2020-09-23 05:40:05.1785004');");
                    _statementList.Add("PRAGMA foreign_keys = on;");
                    break;
            }
            return this.ExecuteSQL();
        }

        private string GetProviderName()
        {
            return new ConfigurationDatabase().GetConnectionConfiguration().providerName;
        }

        #region Log
        protected void SetLog(string method, string result, DateTime datetime)
        {
            _log.SetLog(method, result, datetime);
        }
        #endregion

    }
}