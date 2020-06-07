using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork6_1.Tariffs;

namespace HomeWork6_1.Clients
{
    class ClientOrdinary : Client
    {
        public ClientOrdinary(string addres, Tariff tar, int energyCount):base(addres,tar,energyCount)
        {
            Type = ClientType.Ordinary;
        }
        protected override void SetTariff(Tariff t)
        {
            Type type = t.GetType();
            if (type.Name == "Tariff")
                tariff = t;
            else
                throw new Exception("Не тот тариф!!!");
        }
    }
}
