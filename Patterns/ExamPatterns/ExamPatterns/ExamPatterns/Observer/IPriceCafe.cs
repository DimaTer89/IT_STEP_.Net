using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPatterns.Observer
{
    interface IPriceCafe
    {
        void Update(decimal pizza, decimal barbecue);
        decimal GetPricePizza(int weight);
        decimal GetPriceBarbecue(int weight);
        decimal Pizza();
        decimal Barbecue();
    }
}
