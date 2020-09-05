using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibCrud
{
    class JuridicalPersonFactory : PersonFactory
    {
        private int _id;
        private string _cnpj;
        private string _name;
        private string _companyName;
        private string _email;
        private string _comment;
        private bool _status;
        private DateTime _createAt;

        public JuridicalPersonFactory(int id, string cnpj, string name, string companyName, string email, string comment, bool status)
        {
            this._id = id;
            this._cnpj = cnpj;
            this._name = name;
            this._companyName = companyName;
            this._email = email;
            this._comment = comment;
            this._status = true;
            this._createAt = DateTime.Now;
        }

        public override Person GetPerson()
        {
            return new JuridicalPerson(_id, _cnpj, _name, _companyName, _email, _comment, _status, _createAt);
        }
    }
}
