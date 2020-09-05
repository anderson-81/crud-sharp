using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibCrud
{
    class JuridicalPerson : Person
    {
        private int _id;
        private string _cnpj;
        private string _name;
        private string _companyName;
        private string _email;
        private string _comment;
        private bool _status;
        private DateTime _createAt;

        public JuridicalPerson(int id, string cnpj, string name, string companyName, string email, string comment, bool status, DateTime createAt)
        {
            this._id = id;
            this._cnpj = cnpj;
            this._name = name;
            this._companyName = companyName;
            this._email = email;
            this._comment = comment;
            this._status = status;
            this._createAt = createAt;
        }

        public override int Id
        {
            get { return _id; }
            set { _id = value; }
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

        public override DateTime CreateAt
        {
            get { return _createAt; }
            set { _createAt = value; }
        }

        public string Cnpj
        {
            get { return _cnpj; }
            set { _cnpj = value; }
        }

        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }

        public override string ToString()
        {
            return String.Format("{0} --- {1} --- {2} --- {3} --- {4} --- {5} -- {6} -- {7}", this.Id, this.Cnpj, this.Name, this.CompanyName, this.Email, this.Comment, this.Status, this.CreateAt);
        }
    }
}
