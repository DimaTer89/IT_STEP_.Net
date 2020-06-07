using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Epam
{
    class OrdinaryClient:Client
    {
        public OrdinaryClient(string name,int energyConsurmed,Rate rate, ClientType client = ClientType.Ordinary) :base(name,energyConsurmed,rate,client)
        { }
    }
}
