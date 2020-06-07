using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6_1.Tariffs
{
    class PrivilegiosTariffTwo:Tariff
    {
        int freelimit;
        public int Freelimit
        {
            get
            {
                return freelimit;
            }
            set
            {
                if (value > 0)
                    freelimit = value;
                else
                    throw new Exception("Должны быть бесплатные киловатты!!!");
            }
        }
        public PrivilegiosTariffTwo(decimal energyPrice=0.15m,int freelimit=50):base(energyPrice)
        {
            Freelimit = freelimit;
        }
        public override decimal GetTotalCoast(int energyCount)
        {
           
            return (energyCount<freelimit)?0:base.GetTotalCoast(energyCount-freelimit);
        }
    }
}
