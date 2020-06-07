using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6_1.Tariffs
{
    class PrivilegiosTariffOne:Tariff
    {
        double koeff;
        public double Koeff
        {
            get
            {
                return koeff;
            }
            set
            {
                if (value >=0 && value < 1)
                    koeff = value;
                else
                    throw new Exception("Ошибка!!!");
            }
        }
        public PrivilegiosTariffOne(decimal energyPrice=0.15m,double koeff=2/3d):base(energyPrice)
        {
            Koeff = koeff;
        }
        public override decimal GetTotalCoast(int energyCount)
        {
            return (energyCount*EnergyPrice*(decimal)koeff);
        }
    }
}
