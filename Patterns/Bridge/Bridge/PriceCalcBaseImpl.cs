using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class PriceCalcBaseImpl : PriceCalcImpl
    {
        public override decimal GetProductPrice(uint itemID)
        {
            return price[itemID];
        }

        public override decimal GetShippingPrice(string shippingTo)
        {
            return 0;
        }
    }
}
