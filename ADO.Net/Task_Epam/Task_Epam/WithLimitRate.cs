using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Epam
{
    class WithLimitRate : Rate
    {
        int limitEnergy = 250;
        public WithLimitRate(double ratio=1/3.0):base(ratio)
        { }
        public override decimal EnergyCoast(int energyValue)
        {
            return energyValue < limitEnergy ? bet * energyValue : (bet * limitEnergy) + ((energyValue - limitEnergy) * ((bet * (decimal)ratio)+bet));
        }
    }
}
