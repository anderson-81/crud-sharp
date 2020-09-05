using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibCrud
{
    public class PersonFacade
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public bool Status { get; set; }
        public DateTime CreateAt { get; set; }
        public decimal Salary { get; set; }
        public DateTime Birthday { get; set; }
        public char Gender { get; set; }
    }
}
