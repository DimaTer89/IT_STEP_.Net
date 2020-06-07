using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Epam
{
    abstract class Client:IComparable<Client>
    {
        string name;
        ClientType client;
        int energyConsumed;
        Rate rate;
        public Client(string name,int energyConsurmed,Rate rate,ClientType client)
        {
            this.name = name;
            EnergyConsumed = energyConsurmed;
            ClientType = client;
            this.rate = rate;
        }
        public Rate Rate
        {
            get => rate;
            set
            {
                if (value is Rate)
                    rate = value;
                else
                    throw new ArgumentException("Недопустимый тип");
            }
        }
        public ClientType ClientType
        {
            get => client;
            set => client = value;
        }
        public int EnergyConsumed
        {
            get => energyConsumed;
            set
            {
                if (value > 0)
                    energyConsumed = value;
                else
                    throw new ArgumentException("Недопустимые данные");
            }
        }

        public int CompareTo(Client other)
        {
            return (this == null && other == null) ? 0 : this == null ? 1 : other == null ? -1 : EnergyConsumed>other.EnergyConsumed?-1:1;
        }

        public decimal EnergySum()
        {
            return rate.EnergyCoast(energyConsumed);
        }
        public override string ToString()
        {
            return $"║{name,30}║{client,11}║{energyConsumed,13}║{EnergySum(),16:f2}║";
        }
    }
}
