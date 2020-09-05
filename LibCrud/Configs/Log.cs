using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LibCrud
{
    class Log
    {
        #region Singleton
        Log()
        {
        }
        static Log()
        {
            Console.WriteLine();
        }
        static readonly Log logInstance = new Log();
        public static Log GetLogInstance
        {
            get { return logInstance; }
        }
        #endregion

        internal void SetLog(string method, string description, DateTime datetime)
        {
            try
            {
                StreamWriter sw = null;

                string path = @"log.txt";
                if (!File.Exists(path))
                {
                    sw = File.CreateText(path);
                    sw.WriteLine("SYSTEM LOG:");
                }
                else
                    sw = File.AppendText(path);
                
                if(description == "")
                    sw.WriteLine(String.Format("{0} ------------------------------------------------------ {1}", method, datetime));
                else
                    sw.WriteLine(String.Format("{0} ------- {1} ------------------------------------------ {2}", method, description, datetime));
               
                sw.Close();
            }
            catch (Exception)
            {
            }
        }
    }
}
