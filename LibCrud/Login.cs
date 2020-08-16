using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibCrud
{
    public class Login
    {
        private Int32 id;
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime datelogin;
        public DateTime Datelogin
        {
            get { return datelogin; }
        }
    }
}
