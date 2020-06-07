using ExamPatterns.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPatterns
{
    class PriceList:IPriceListObserver
    {
        decimal pizza = 18;
        decimal barbecue = 20;
        List<IPriceCafe> cafePrices;
        public PriceList()
        {
            cafePrices = new List<IPriceCafe>();
        }
        public string GetPriceCafePizza(string nameCafe)
        {
            string pricePizza="0";
            foreach (var item in cafePrices)
            {
                if (item.ToString().CompareTo(nameCafe) == 0)
                    pricePizza =Convert.ToString(item.Pizza());
            }
            return pricePizza;
        }
        public string GetPriceCafeBabrbecue(string nameCafe)
        {
            string priceBarbecue="0";
            foreach (var item in cafePrices)
            {
                if (item.ToString().CompareTo(nameCafe) == 0)
                    priceBarbecue = Convert.ToString(item.Barbecue());
            }
            return priceBarbecue;
        }
        public void GetPizza(decimal price)
        { pizza = price; }
        public void GetBarbecue(decimal price)
        { barbecue = price; }
        public void AlertObserveble()
        {
            if (cafePrices.Count > 0)
            {
                for (int i = 0; i < cafePrices.Count; i++)
                    cafePrices[i].Update(pizza, barbecue);
            }
        }

        public void DeleteObserverble(IPriceCafe cafeFactory)
        {
            cafePrices.Remove(cafeFactory);
        }

        public void RegisterObserverble(IPriceCafe cafeFactory)
        {
            cafePrices.Add(cafeFactory);
        }

        public decimal GetTotalPizzaPrice(string nameCafe,int weight)
        {
            decimal price = 0;
            foreach (var item in cafePrices)
            {
                if (item.ToString().CompareTo(nameCafe) == 0)
                    price=item.GetPricePizza(weight);
            }
            return price;
        }

        public decimal GetTotalBarbecuePrice(string nameCafe,int weight)
        {
            foreach (var item in cafePrices)
            {
                if (item.ToString().CompareTo(nameCafe) == 0)
                    return item.GetPriceBarbecue(weight);
            }
            return 0;
        }
    }
}
