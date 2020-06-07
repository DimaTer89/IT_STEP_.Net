using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Epam
{
    class ClientTypeSort : IComparer<Client>
    {
        public int Compare(Client x, Client y)
        {
            return (x==null&&y==null)?0:x==null?-1:y==null?1:x.ClientType>y.ClientType?1:-1;
        }
    }
}
