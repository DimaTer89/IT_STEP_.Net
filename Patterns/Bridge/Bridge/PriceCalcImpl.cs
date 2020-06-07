using System;
using System.Collections.Generic;

namespace Bridge
{
    abstract class PriceCalcImpl
    {
        static protected Dictionary<uint, decimal> price = new Dictionary<uint, decimal>
        //{
        //    {3,56 },
        //    {4,72.5m }
        //};раньше и сейчас
        {
            [3] = 56,
            [4] = 72.5m
        };//начиная с C# 6
        static PriceCalcImpl()
        {
            price.Add(0, 234);
            price.Add(1, 178);
            price.Add(2, 23);
        }
        public abstract decimal GetProductPrice(uint itemID);
        public abstract decimal GetShippingPrice(string shippingTo);
    }
}