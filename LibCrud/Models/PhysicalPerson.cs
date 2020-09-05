using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibCrud
{
    class PhysicalPerson : Person
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

        public PhysicalPerson(int id, string cpf, string name, string email, decimal salary, DateTime birthday, char gender, string comment, bool status, DateTime createAt)
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
            this._createAt = createAt;
        }

        public override int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Cpf
        {
            get { return _cpf; }
            set { _cpf = value; }
        }

        public override string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public override string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public decimal Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        public override bool Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public override string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        public char Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public override DateTime CreateAt
        {
            get { return _createAt; }
            set { _createAt = value; }
        }

        public override string ToString()
        {
            return String.Format("{0} --- {1} --- {2} --- {3} --- {4} --- {5} -- {6} -- {7} -- {8} -- {9}", this.Id, this.Cpf, this.Name, this.Email, this.Salary, this.Comment, this.Birthday, this.Gender, this.Status, this.CreateAt);
        }
    }
}
