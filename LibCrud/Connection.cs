using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace LibCrud
{
    public class Connection
    {
        public static SqlConnection Connect()
        {
            try
            {
                string path = Environment.CurrentDirectory + "\\App_Data\\dbRegistration.mdf";
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + path + ";Initial Catalog=dbRegistration;Integrated Security=True;Connect Timeout=30";
                conn.Open();
                return conn;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
