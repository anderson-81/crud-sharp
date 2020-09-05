using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibCrud
{
    abstract class Person
    {
        public abstract int Id { get; set; }
        public abstract string Name { get; set; }
        public abstract string Email { get; set; }
        public abstract bool Status { get; set; }
        public abstract string Comment { get; set; }
        public abstract DateTime CreateAt { get; set; }
    }
}
