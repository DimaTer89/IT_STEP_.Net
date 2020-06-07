using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class PriceCalcShippImpl : PriceCalcImpl
    {
        protected Dictionary<string, decimal> shppingPrice = new Dictionary<string, decimal>
        {
            ["Gomel"] = 0.5m,
            ["Minsk"] = 15,
            ["Brest"] = 23,
            ["Vitebsk"] = 20
        };
        public override decimal GetProductPrice(uint itemID)
        {
            return price[itemID];
        }

        public override decimal GetShippingPrice(string shippingTo)
        {
            return shppingPrice[shippingTo];
        }
    }
}
