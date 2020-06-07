using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPatterns.Observer
{
    interface IPriceListObserver
    {
        void GetPizza(decimal price);
        void GetBarbecue(decimal price);
        string GetPriceCafePizza(string nameCafe);
        string GetPriceCafeBabrbecue(string nameCafe);
        decimal GetTotalPizzaPrice(string nameCafe,int weight);
        decimal GetTotalBarbecuePrice(string nameCafe,int weight);
        void RegisterObserverble(IPriceCafe cafeFactory);
        void DeleteObserverble(IPriceCafe cafeFactory);
        void AlertObserveble();
    }
}
