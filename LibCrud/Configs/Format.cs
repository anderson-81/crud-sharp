using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LibCrud.Configs
{
    public class Format
    {
        private Log _log = Log.GetLogInstance; 

        public String GenerateHASH(string source)
        {
            using (SHA512 sha512Hash = SHA512.Create())
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
                byte[] hashBytes = sha512Hash.ComputeHash(sourceBytes);
                SetLog("GenerateHASH", "Hash generated successfully.", DateTime.Now);
                return BitConverter.ToString(hashBytes).Replace("-", String.Empty).ToLower();
            }
        }

        protected void SetLog(string method, string result, DateTime datetime)
        {
            _log.SetLog(method, result, datetime);
        }
    }
}
