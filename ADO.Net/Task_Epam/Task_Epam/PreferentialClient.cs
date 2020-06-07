using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Epam
{
    class PreferentialClient:Client
    {
        public PreferentialClient(string name,int energyConsurmed,Rate rate,ClientType client=ClientType.Prefential):base(name,energyConsurmed,rate,client)
        { }
    }
}
