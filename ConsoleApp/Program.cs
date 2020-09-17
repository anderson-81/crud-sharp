using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibCrud;
using System.Xml;
using System.Security.Cryptography;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("(t) - TesteConfiguration()");
            Console.WriteLine("(p) - PhysicalPersonOperations()");
            Console.WriteLine("(r) - Reports()");
            Console.Write("Response: ");
            string opc = Console.ReadLine();

            if(opc == "t")
            {
                TestConfiguration();
            }

            if (opc == "p")
            {
                PhysicalPersonOperations();
            }

            if (opc == "j")
            {
                JuridicalPersonOperations();
            }

            if (opc == "s")
            {
                Searches();
            }

            if (opc == "r")
            {
                Reports();
            }
            */

            //TestConfiguration();
            //TestLogin();
            Test();

    

            Console.ReadKey();

        }

        public static void TestLogin()
        {
            Facade fc = Facade.FacadeInstance;
            //Console.WriteLine(fc.InsertUser("anderson", "121181"));
            //Console.WriteLine(fc.Login("anderson", "121181"));
            Console.WriteLine(fc.DeleteUser(2));
        }

        public static void Test()
        {
            Facade fc = Facade.FacadeInstance;

            Console.WriteLine("PHYSICAL-PERSON");
            Console.WriteLine("INSERTION");

            Console.WriteLine(fc.InsertPhysicalPerson("96227163180", "John", "testando@teste.com", 3000, new DateTime(1981, 11, 12), 'M', "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", true));
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(fc.InsertPhysicalPerson("96227163180", "", "gsdgs@sgfds", -4000, new DateTime(1983, 11, 15), 'A', "", false));
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(fc.InsertPhysicalPerson("15153066312", "Mary", "twretwew@teste.com", 4000, new DateTime(1983, 10, 11), 'F', "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", false));
            Console.WriteLine("-----------------------------------");


            Console.WriteLine("EDITION");

            Console.WriteLine(fc.EditPhysicalPerson(1, "Anne", "anne@teste.com", 2000, new DateTime(1981, 11, 12), 'F', "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", true));
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(fc.EditPhysicalPerson(2, "Carmen", "anne@teste.com", 3000, new DateTime(1970, 01, 15), 'F', "jhdsag djhsg djsd dhgs dasdashg hje s fhgfdhg ashg czxnc zxncvzxnbcx.", false));
            Console.WriteLine("-----------------------------------");
            
            
            Console.WriteLine("JURIDICAL-PERSON");
            Console.WriteLine("INSERTION");

            Console.WriteLine(fc.InsertJuridicalPerson("06911171000159", "Empresa 01", "Companhia S.A 01", "empresa01@teste.com", "Comentario da empresa 01.", true));
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(fc.InsertJuridicalPerson("06911171000159", "Empresa 02", "Companhia S.A 02", "empresa02@teste.com", "Comentario da empresa 02.", false));
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(fc.InsertJuridicalPerson("10780540000199", "Empresa 02", "Companhia S.A 02", "empresa01@teste.com", "Comentario da empresa 02.", false));
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(fc.InsertJuridicalPerson("10780540000199", "Empresa 02", "Companhia S.A 02", "empresa02@teste.com", "Comentario da empresa 02.", false));

            Console.WriteLine("EDITION");

            Console.WriteLine(fc.EditJuridicalPerson(3, "Enterprise Lux", "Company S.A. 100", "email1@test.com", "Enterprise 01.", true));
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(fc.EditJuridicalPerson(4, "Enterprise Spider", "Company S.A. 200", "email1@test.com", "Enterprise 02.", false));
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(fc.EditJuridicalPerson(4, "Enterprise Spider", "Company S.A. 200", "segundo@test.com", "Enterprise 02.", false));
          
            
            Console.WriteLine("SEARCHES");
             
            Console.WriteLine(fc.GetPersonByName("A", Facade.OptionPerson.PhysicalPersonOption));
            Console.WriteLine(fc.GetPersonByName("E", Facade.OptionPerson.JuridicalPersonOption));
            Console.WriteLine(fc.GetPhysicalPersonByCPF("96227163180"));
            Console.WriteLine(fc.GetJuridicalPersonByCNPJ("10780540000199"));
            

            Console.WriteLine("REPORTS");

            Console.WriteLine(fc.GetPhysicalPersonByGender(Facade.OptionGender.Male).Count);
            Console.WriteLine(fc.GetPhysicalPersonByGender(Facade.OptionGender.Female).Count);
            Console.WriteLine(fc.GetPhysicalPersonByAVGSalary(Facade.OptionAVGSalary.Under));
            Console.WriteLine(fc.GetPhysicalPersonByAVGSalary(Facade.OptionAVGSalary.Equal));
            Console.WriteLine(fc.GetPhysicalPersonByAVGSalary(Facade.OptionAVGSalary.Above));
            

            Console.WriteLine(fc.GetPhysicalPersonByBirthMonth(11));
            Console.WriteLine(fc.GetPhysicalPersonBySalary(Facade.OptionSalary.Lower).ToString());
            Console.WriteLine(fc.GetPhysicalPersonBySalary(Facade.OptionSalary.Higher).ToString());
            Console.WriteLine(fc.GetPhysicalPersonBySalaryRange(1000, 3000));
            
            /*
            Console.WriteLine("DELETE");

            Console.WriteLine(fc.DeletePhysicalPerson(1));
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(fc.DeletePhysicalPerson(2));
            Console.WriteLine("-----------------------------------");

            Console.WriteLine("DELETE");

            Console.WriteLine(fc.DeleteJuridicalPerson(3));
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(fc.DeleteJuridicalPerson(4));
            */
        }

        public static void PhysicalPersonOperations()
        {
            Console.WriteLine("PhysicalPersonOperations");

            Facade fc = Facade.FacadeInstance;


            string opc = Console.ReadLine();

            if (opc == "i")
            {
                Console.WriteLine("INSERTION");
                Console.WriteLine(fc.InsertPhysicalPerson("96227163180", "John", "testando@teste.com", 3000, new DateTime(1981, 11, 12), 'M', "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", true));
                Console.WriteLine("-----------------------------------");
                Console.WriteLine(fc.InsertPhysicalPerson("96227163180", "", "gsdgs@sgfds", -4000, new DateTime(1983, 11, 15), 'A', "", false));
                Console.WriteLine("-----------------------------------");
                Console.WriteLine(fc.InsertPhysicalPerson("15153066312", "Mary", "twretwew@teste.com", 4000, new DateTime(1983, 10, 11), 'F', "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", false));
                Console.WriteLine("-----------------------------------");
            }

            if (opc == "e")
            {
                Console.WriteLine("EDITION");
                Console.WriteLine(fc.EditPhysicalPerson(1, "Anne", "anne@teste.com", 2000, new DateTime(1981, 11, 12), 'F', "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", true));
                Console.WriteLine("-----------------------------------");
                Console.WriteLine(fc.EditPhysicalPerson(2, "Carmen", "anne@teste.com", 3000, new DateTime(1970, 01, 15), 'F', "jhdsag djhsg djsd dhgs dasdashg hje s fhgfdhg ashg czxnc zxncvzxnbcx.", false));
                Console.WriteLine("-----------------------------------");
            }


            if (opc == "d")
            {
                Console.WriteLine("DELETE");
                Console.WriteLine(fc.DeletePhysicalPerson(1));
                Console.WriteLine("-----------------------------------");
                Console.WriteLine(fc.DeletePhysicalPerson(2));
                Console.WriteLine("-----------------------------------");
            }
        }

        public static void JuridicalPersonOperations()
        {
            Console.WriteLine("JuridicalPersonOperations");


            Facade fc = Facade.FacadeInstance;

            string opc = Console.ReadLine();

            if (opc == "i")
            {
                Console.WriteLine("INSERTION");
                Console.WriteLine(fc.InsertJuridicalPerson("06911171000159", "Empresa 01", "Companhia S.A 01", "empresa01@teste.com", "Comentario da empresa 01.", true));
                Console.WriteLine("-----------------------------------");
                Console.WriteLine(fc.InsertJuridicalPerson("06911171000159", "Empresa 02", "Companhia S.A 02", "empresa02@teste.com", "Comentario da empresa 02.", false));
                Console.WriteLine("-----------------------------------");
                Console.WriteLine(fc.InsertJuridicalPerson("10780540000199", "Empresa 02", "Companhia S.A 02", "empresa01@teste.com", "Comentario da empresa 02.", false));
                Console.WriteLine("-----------------------------------");
                Console.WriteLine(fc.InsertJuridicalPerson("10780540000199", "Empresa 02", "Companhia S.A 02", "empresa02@teste.com", "Comentario da empresa 02.", false));
            }

            if (opc == "e")
            {
                Console.WriteLine("EDITION");
                Console.WriteLine(fc.EditJuridicalPerson(1, "Enterprise Lux", "Company S.A. 100", "email1@test.com", "Enterprise 01.", true));
                Console.WriteLine("-----------------------------------");
                Console.WriteLine(fc.EditJuridicalPerson(2, "Enterprise Spider", "Company S.A. 200", "email1@test.com", "Enterprise 02.", false));
                Console.WriteLine("-----------------------------------");
                Console.WriteLine(fc.EditJuridicalPerson(2, "Enterprise Spider", "Company S.A. 200", "segundo@test.com", "Enterprise 02.", false));
            }


            if (opc == "d")
            {
                Console.WriteLine("DELETE");
                Console.WriteLine(fc.DeleteJuridicalPerson(1));
                Console.WriteLine("-----------------------------------");
                Console.WriteLine(fc.DeleteJuridicalPerson(2));
            }
        }

        public static void Searches()
        {
            Facade fc = Facade.FacadeInstance;
            Console.WriteLine(fc.GetPersonByName("A", Facade.OptionPerson.PhysicalPersonOption));
            Console.WriteLine(fc.GetPersonByName("E", Facade.OptionPerson.JuridicalPersonOption));
            Console.WriteLine(fc.GetPhysicalPersonByCPF("96227163180"));
            Console.WriteLine(fc.GetJuridicalPersonByCNPJ("10780540000199"));
        }

        public static void Reports()
        {
            Facade fc = Facade.FacadeInstance;

            /*
            Console.WriteLine(fc.GetPhysicalPersonByGender(Facade.OptionGender.Male).Count);
            Console.WriteLine(fc.GetPhysicalPersonByGender(Facade.OptionGender.Female).Count);
            
            Console.WriteLine(fc.GetPhysicalPersonByAVGSalary(Facade.OptionAVGSalary.Under));
            Console.WriteLine(fc.GetPhysicalPersonByAVGSalary(Facade.OptionAVGSalary.Equal));
            Console.WriteLine(fc.GetPhysicalPersonByAVGSalary(Facade.OptionAVGSalary.Above));
            */

            Console.WriteLine(fc.GetPhysicalPersonByBirthMonth(11));

            /*
            Console.WriteLine(fc.GetPhysicalPersonBySalary(Facade.OptionSalary.Lower).ToString());
            Console.WriteLine(fc.GetPhysicalPersonBySalary(Facade.OptionSalary.Higher).ToString());
            Console.WriteLine(fc.GetPhysicalPersonBySalaryRange(1000,3000));
            */
        }

        public static void TestConfiguration()
        {
            ConfigurationDatabase config = new ConfigurationDatabase();
            if (config.GetConnectionConfiguration() == null)
            {
                //config = new ConfigurationDatabase(ConfigurationDatabase.DatabaseName.MySQL, "DbRegistration", "192.168.74.137", 3306, "anderson", "121181", "");
                config = new ConfigurationDatabase(ConfigurationDatabase.DatabaseName.SQLite, "DbRegistration.db", "", 0, "", "", "");
                //config = new ConfigurationDatabase(ConfigurationDatabase.DatabaseName.PostgreSQL, "DbRegistration", "192.168.74.137", 5432, "postgres", "121181", "");
                //config = new ConfigurationDatabase(ConfigurationDatabase.DatabaseName.SQLServer, "DbRegistration", "192.168.74.137", 1433, "anderson", "121181", "");



                Console.WriteLine(config.CreateConfiguration());

                Console.WriteLine("Successfully created.");
            }
            else
            {
                config = config.GetConnectionConfiguration();
                Console.WriteLine("Successfully loaded.");
            }
        }

    }
}
