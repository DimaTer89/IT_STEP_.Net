using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Epam
{
    class WithLimitClient:Client
    {
        public WithLimitClient(string name,int energyConsurmed,Rate rate,ClientType client=ClientType.WithLimit):base(name,energyConsurmed,rate,client)
        { }
    }
}
