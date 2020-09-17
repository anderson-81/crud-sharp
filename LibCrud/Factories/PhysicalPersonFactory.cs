using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibCrud
{
    class PhysicalPersonFactory : PersonFactory
    {
        private int _id;
        private string _cpf;
        private string _name;
        private string _email;
        private decimal _salary;
        private DateTime _birthday;
        private char _gender;
        private string _comment;
        private bool _status;
        private DateTime _createAt;

        public PhysicalPersonFactory(int id, string cpf, string name, string email, decimal salary, DateTime birthday, char gender, string comment, bool status)
        {
            this._id = id;
            this._cpf = cpf;
            this._name = name;
            this._email = email;
            this._salary = salary;
            this._birthday = birthday;
            this._gender = gender;
            this._comment = comment;
            this._status = status;
            this._createAt = DateTime.Now;
        }

        public override Person GetPerson()
        {
            return new PhysicalPerson(_id, _cpf, _name, _email, _salary, _birthday, _gender, _comment, _status, _createAt);
        }
    }
}
