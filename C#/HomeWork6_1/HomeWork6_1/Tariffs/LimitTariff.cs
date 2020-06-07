using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6_1.Tariffs
{
    class LimitTariff:Tariff
    {
        int limit;
        public int Limit
        {
            get
            {
                return limit;
            }
            set
            {
                if (value >= 0)
                    limit = value;
                else
                    throw new Exception("Лимит не может быть отрицательным!!!");
            }
        }
        double koeff;
        public double Koeff
        {
            get
            {
                return koeff;
            }
            set
            {
                if (value >= 0)
                    koeff = value;
                else
                    throw new Exception("Коэффициент не может быть отрицательным!!!");
            }
        }
        public LimitTariff(decimal energyPrice=0.15m,int limit=150,double koeff=1/3d):base(energyPrice)
        {
            Limit = limit;
            Koeff = koeff;
        }
        public override decimal GetTotalCoast(int energyCount)
        {
            decimal newPrice = EnergyPrice *(decimal)(1 + koeff);
            return (energyCount<limit)?(base.GetTotalCoast(energyCount)):(base.GetTotalCoast(limit) + (energyCount - limit) * newPrice);
        }
    }
}
