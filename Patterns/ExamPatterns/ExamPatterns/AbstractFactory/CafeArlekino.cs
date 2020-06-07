using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPatterns.Observer;

namespace ExamPatterns.AbstractFactory
{
    class CafeArlekino : ICafeFactory,IPriceCafe
    {
        decimal pizza, barbecue;
        const decimal mark_Price = 1.20m;
        public decimal Pizza() => pizza * mark_Price;
        public decimal Barbecue() => barbecue * mark_Price;
        public IBarbecue CreateBarbecue()
        {
            return new Barbekue();
        }

        public IPizza CreatePizza()
        {
            return new PizzaWithSeafoodCheese();
        }
        public override string ToString()
        {
            return "Кафе Арлекино";
        }
        public decimal GetPriceBarbecue(int weight)
        {
            return ((barbecue*mark_Price) * ((decimal)weight / 100));
        }

        public decimal GetPricePizza(int weight)
        {
            return ((pizza*mark_Price) * ((decimal)weight / 100));
        }

        public void Update(decimal pizza, decimal barbecue)
        {
            this.pizza = pizza;
            this.barbecue = barbecue;
        }
    }
}
