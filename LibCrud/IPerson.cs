using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibCrud
{
    interface IPerson
    {
        Int32 Id
        {
            get;
            set;
        }

        String Name
        {
            get;
            set;
        }

        String Email
        {
            get;
            set;
        }
    }
}
