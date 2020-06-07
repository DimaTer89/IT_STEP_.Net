using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Epam
{
    abstract class Rate
    {
        protected decimal bet=0.15m;
        protected double ratio;
        public Rate(double ratio)
        {
           Ratio = ratio;    
        }
        public decimal Bet
        {
            get => bet;
            set
            {
                if (value > 0)
                    bet = value;
                else
                    throw new ArgumentException("Недопустимые данные");
            }
        }
        public double Ratio
        {
            get => ratio;
            set
            {
                if (value > 0 && value <= 1)
                    ratio = value;
                else
                    throw new ArgumentException("Недопустимое значение");
            }

        }
        public abstract decimal EnergyCoast(int energyValue);
    }
}
