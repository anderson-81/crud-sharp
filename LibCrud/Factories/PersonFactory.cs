using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibCrud
{
    abstract class PersonFactory
    {
        public abstract Person GetPerson();
    }
}
