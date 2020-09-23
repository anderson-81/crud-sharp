using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibCrud
{
    class User
    {
        public enum UserTypeOption
        {
            Administrator,
            User
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string username;
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

        private UserTypeOption userType;

        internal UserTypeOption UserType
        {
            get { return userType; }
            set { userType = value; }
        }

        public User(int id, string name, string username, string password, DateTime createAt, UserTypeOption userType)
        {
            this.id = id;
            this.name = name;
            this.username = username;
            this.password = password;
            this.createAt = createAt;
            this.userType = userType;
        }

        public User() { }
    }
}
