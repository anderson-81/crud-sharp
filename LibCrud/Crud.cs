using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibCrud
{
    public class Crud
    {
        #region Search for PhysicalPerson
        public static List<PhysicalPerson> GetPhysicalPerson_ByName(String name)
        {
            PhysicalPerson pp = new PhysicalPerson();
            pp.Name = name;
            Controller ctr = new Controller(pp);
            return ctr.GetPhysicalPerson_ByName();
        }

        public static PhysicalPerson GetPhysicalPerson_ByID(Int32 id)
        {
            PhysicalPerson pp = new PhysicalPerson();
            pp.Id = id;
            Controller ctr = new Controller(pp);
            return ctr.GetPhysicalPerson_ByID();
        }
        #endregion

        #region Reports
        public static List<PhysicalPerson> GetPhysicalPerson_SalaryAboveAVG()
        {
            Controller ctr = new Controller();
            return ctr.GetPhysicalPerson_SalaryAboveAVG();
        }

        public static List<PhysicalPerson> GetPhysicalPerson_SalaryUnderAVG()
        {
            Controller ctr = new Controller();
            return ctr.GetPhysicalPerson_SalaryUnderAVG();
        }

        public static List<PhysicalPerson> GetPhysicalPerson_SalaryEqualAVG()
        {
            Controller ctr = new Controller();
            return ctr.GetPhysicalPerson_SalaryEqualAVG();
        }

        public static PhysicalPerson GetPhysicalPerson_HigherSalary()
        {
            Controller ctr = new Controller();
            return ctr.GetPhysicalPerson_HigherSalary();
        }

        public static PhysicalPerson GetPhysicalPerson_LowerSalary()
        {
            Controller ctr = new Controller();
            return ctr.GetPhysicalPerson_LowerSalary();
        }

        public static List<PhysicalPerson> GetPhysicalPerson_ByBirthMonth(int month)
        {
            Controller ctr = new Controller();
            return ctr.GetPhysicalPerson_ByBirthMonth(month);
        }

        public static List<PhysicalPerson> GetPhysicalPerson_BySalaryRange(decimal sal1, decimal sal2)
        {
            Controller ctr = new Controller();
            return ctr.GetPhysicalPerson_BySalaryRange(sal1, sal2);
        }

        public static int GetCountPhysicalPerson_ByGenre(char genre)
        {
            Controller ctr = new Controller();
            return ctr.GetCountPhysicalPerson_ByGenre(genre);
        }
        #endregion

        #region TO LOG
        public static int ToLog_UserSys(String username, String userpass)
        {
            UserSys user = new UserSys();
            user.Username = username;
            user.Userpass = userpass;
            Controller ctr = new Controller(user);
            return ctr.ToLog_UserSys();
        }
        #endregion

        #region Transactions
        public static int Insert_PhysicalPerson(String name, String email, Decimal salary, DateTime dateBirth, Char genre)
        {
            PhysicalPerson pp = new PhysicalPerson();
            pp.Name = name;
            pp.Email = email;
            pp.Salary = salary;
            pp.DateBirth = dateBirth;
            pp.Genre = genre;
            Controller ctr = new Controller(pp);
            return ctr.Insert_PhysicalPerson_tr();
        }

        public static int Edit_PhysicalPerson(Int32 id, String name, String email, Decimal salary, DateTime dateBirth, Char genre)
        {
            PhysicalPerson pp = new PhysicalPerson();
            pp.Id = id;
            pp.Name = name;
            pp.Email = email;
            pp.Salary = salary;
            pp.DateBirth = dateBirth;
            pp.Genre = genre;
            Controller ctr = new Controller(pp);
            return ctr.Edit_PhysicalPerson_tr();
        }

        public static int Delete_PhysicalPerson(Int32 id)
        {
            PhysicalPerson pp = new PhysicalPerson();
            pp.Id = id;
            Controller ctr = new Controller(pp);
            return ctr.Delete_PhysicalPerson_tr();
        }
     
        public static int Insert_UserSys(String username, String userpass)
        {
            UserSys user = new UserSys();
            user.Username = username;
            user.Userpass = userpass;
            Controller ctr = new Controller(user);
            return ctr.Insert_UserSys_tr();
        }

        public static int Delete_UserSys(Int32 id)
        {
            UserSys user = new UserSys();
            user.Id = id;
            Controller ctr = new Controller(user);
            return ctr.Delete_UserSys_tr();
        }
        #endregion
    }
}
