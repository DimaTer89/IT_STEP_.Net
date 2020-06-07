using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    //Abstraction
    abstract class PriceCalc
    {
        static protected List<ProductInCard> products = new List<ProductInCard>();
        protected PriceCalcImpl priceCalcImpl;//мост-агрегация абстракции реализатора
        public PriceCalc(PriceCalcImpl priceCalcImpl)
        {
            this.priceCalcImpl = priceCalcImpl;
        }
        public PriceCalcImpl GetPriceCalcImpl(PriceCalcImpl priceCalc)=>priceCalcImpl = priceCalc;
        public abstract void AddProduct(uint itemID, uint itemQuantity);
        public abstract decimal GetTotalPrice(string shippingTo);
    }
}
