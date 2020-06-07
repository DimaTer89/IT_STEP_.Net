using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork6_1.Tariffs;

namespace HomeWork6_1.Clients
{
    class ClientPrivilegiosTariffTwo:Client
    {
        public ClientPrivilegiosTariffTwo(string adress,Tariff tar,int energyCount):base(adress,tar,energyCount)
        {
            Type = ClientType.ConcessionTwo;
        }

        protected override void SetTariff(Tariff t)
        {
            Type type = t.GetType();
            if (type.Name == "PrivilegiosTariffTwo")
                tariff = t;
            else
                throw new Exception("Не тот тариф");
        }
    }
}
