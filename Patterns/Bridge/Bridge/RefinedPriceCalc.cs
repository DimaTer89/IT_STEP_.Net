using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class RefinedPriceCalc : PriceCalc
    {
        public RefinedPriceCalc(PriceCalcImpl priceCalcImpl):base(priceCalcImpl)
        {
        }
        public override void AddProduct(uint itemID, uint itemQuantity)
        {
            decimal price=priceCalcImpl.GetProductPrice(itemID);
            products.Add(new ProductInCard { ID = itemID, Price = price, Quatity = itemQuantity });
        }

        public override decimal GetTotalPrice(string shippingTo)
        {
            return (products.Sum(p => p.Price*p.Quatity)+ priceCalcImpl.GetShippingPrice(shippingTo));
        }
    }
}
