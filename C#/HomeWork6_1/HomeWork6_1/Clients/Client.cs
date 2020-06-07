using HomeWork6_1.Tariffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HomeWork6_1.Clients
{
    abstract class Client:IComparable
    {
        public ClientType Type { get; protected set; }
        int energyCount;
        public string Address { get; set; }
        public int EnergyCount
        {
            get
            {
                return energyCount;
            }
            set
            {
                if (value >= 0)
                    energyCount = value;
                else
                    throw new Exception("Энергия отрицательна!!!");
            }
        }
        protected Tariff tariff;
        protected abstract void SetTariff(Tariff t);
        public Tariff Tariff
        {
            get
            {
                return tariff;
            }
            set
            {
                SetTariff(value);
                //Type type = value.GetType();
                //if (type.Name == "Tariff")
                //    tariff = value;
                //else
                //    throw new Exception("Не тот тариф!!!");
            }
        }
        public Client(string addres,Tariff tar,int energyCount)
        {
            Address = addres;
            Tariff = tar;
            EnergyCount = energyCount;
        }
        public decimal GetEnergyBill()
        {
            return tariff.GetTotalCoast(energyCount);
        }
        public int CompareTo(object obj)
        {
            Client cl = obj as Client;
            if (cl != null)
                return (-this.EnergyCount.CompareTo(cl.EnergyCount));
            return 1;
        }
        public override string ToString()
        {
            Type type = tariff.GetType();
            return ($"╠════════════════════╬══════════════════════╬════════════════════════════╬══════════════════════╣\n║{Address,20}║{type.Name,22}║{energyCount,28}║{GetEnergyBill(),22:f2}║");
        }
    }
}
