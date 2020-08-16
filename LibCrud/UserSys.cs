using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibCrud
{
    public class UserSys
    {
        private Int32 id;
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }
        
        private String username;
        public String Username
        {
            get { return username; }
            set { username = value; }
        }
        
        private String userpass;
        public String Userpass
        {
            get { return userpass; }
            set { userpass = value; }
        }
    }
}
