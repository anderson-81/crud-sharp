using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibCrud
{
    class User
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string username = "";
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string password = "";
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private DateTime createAt;
        public DateTime CreateAt
        {
            get { return createAt; }
            set { createAt = value; }
        }

        public User(int id, string username, string password, DateTime createAt)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.createAt = createAt;
        }

        public User() { }
    }
}
