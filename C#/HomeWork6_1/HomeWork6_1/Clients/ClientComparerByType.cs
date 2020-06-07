using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6_1.Clients
{
    class ClientComparerByType : IComparer
    {
        public int Compare(object x, object y)
        {
            Client c1 = x as Client;
            Client c2 = y as Client;
            ///вариант 1
            //return (c1 == null && c2 == null) ? 0 : (c1 == null ? -1 : (c2 == null) ? 1 : (c1.Type.CompareTo(c2.Type)));
            ///вариант 2
            if (c1 == null && c2 == null)
                return 0;
            if (c1 == null)
                return -1;
            if (c2 == null)
                return 1;
            //if (c1.Type > c2.Type)
            //    return 1;
            //if (c1.Type < c2.Type)
            //    return -1;
            //return 0;
            return (c1.Type.CompareTo(c2.Type));
        }
    }
}
