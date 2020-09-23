using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibCrud
{
    class FacadeValidationData
    {
        #region Singleton
        FacadeValidationData()
        {
        }
        static FacadeValidationData()
        {
        }
        static readonly FacadeValidationData validationInstance = new FacadeValidationData();
        public static FacadeValidationData GetInstance
        {
            get { return validationInstance; }
        }
        #endregion

        #region General validation
        public bool CheckIfNotIsNullOrEmpty(object data)
        {
            return (string.IsNullOrEmpty(data.ToString()) || data != null);
        }

        public bool CheckStringSize(string data, int initial, int final)
        {
            return ((data.Length >= initial) && (data.Length <= final));
        }

        public bool CheckRegex(string data, string regex)
        {
            Regex rx = new Regex(@regex, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return rx.IsMatch(data);
        }

        public bool CheckNumericRange<T>(T value, T initial, T final) where T : IComparable<T>
        {
            return (value.CompareTo(initial) >= 0) && (value.CompareTo(final) <= decimal.MaxValue);
        }

        public bool CheckYear(DateTime date, int day, int month, int year)
        {
            return date <= DateTime.Now.AddDays(day).AddMonths(month).AddYears(year);
        }

        public bool CheckIfExistInDatabase<T>(string table, string column, T value)
        {
            try
            {
                DbCommand cmd = ConnectionFactory.getInstance().getConnection().CreateCommand();
                IDbDataParameter p = cmd.CreateParameter();
                p.ParameterName = "@" + column;
                p.Value = value;
                cmd.Parameters.Add(p);
                cmd.CommandText = String.Format("SELECT * FROM {0} WHERE {1} = '{2}';", table, column, value);
                IDataReader reader = cmd.ExecuteReader();
                bool result = (((System.Data.Common.DbDataReader)reader).HasRows);
                reader.Close();
                cmd.Connection.Close();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Validations (Specific Fields)
        // Font: http://www.macoratti.net/11/09/c_val1.htm
        internal bool ValidateCPF(string cpf)
        {
            int[] m1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] m2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digit;
            int sum;
            int rest;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * m1[i];
            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = rest.ToString();
            tempCpf = tempCpf + digit;
            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * m2[i];
            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = digit + rest.ToString();
            return cpf.EndsWith(digit);
        }
        internal bool ValidateCNPJ(string cnpj)
        {
            int[] m1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] m2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int sum;
            int rest;
            string digit;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            sum = 0;
            for (int i = 0; i < 12; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * m1[i];
            rest = (sum % 11);
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = rest.ToString();
            tempCnpj = tempCnpj + digit;
            sum = 0;
            for (int i = 0; i < 13; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * m2[i];
            rest = (sum % 11);
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = digit + rest.ToString();
            return cnpj.EndsWith(digit);
        }
        #endregion
    }
}
