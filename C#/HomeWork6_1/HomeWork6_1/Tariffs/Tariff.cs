using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6_1.Tariffs
{
    class Tariff
    {
        //единица потреблённой энергии 15 коп.
        decimal energyPrice;
        public decimal EnergyPrice
        {
            get
            {
                return energyPrice;
            }
            set
            {
                if (value >= 0)
                    energyPrice = value;
                else
                    throw new Exception("Цена не может быть отрицательной!!!");
            }
        }
        public Tariff(decimal energyPrice=0.15m)
        {
            EnergyPrice = energyPrice;
        }
        //метод расчёта стоимости электроэнергии
        public virtual decimal GetTotalCoast(int energyCount)
        {
            return (energyCount * energyPrice);
        }
    }
}
