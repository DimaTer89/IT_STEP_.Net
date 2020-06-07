using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Epam
{
    class OrdinaryRate : Rate
    {
        public OrdinaryRate(double ratio=1):base(ratio)
        { }
        public override decimal EnergyCoast(int energyValue)
        {
            return (bet * (decimal)ratio) * energyValue;
        }
    }
}
