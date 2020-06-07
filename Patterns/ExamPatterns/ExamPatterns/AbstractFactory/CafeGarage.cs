using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPatterns.Observer;

namespace ExamPatterns.AbstractFactory
{
    class CafeGarage : ICafeFactory,IPriceCafe
    {
        decimal pizza, barbecue;
        const decimal mark_Price = 1.15m;
        public decimal Pizza()=> pizza*mark_Price;
        public decimal Barbecue() => barbecue * mark_Price;
        public IBarbecue CreateBarbecue()
        {
            return new Barbekue();
        }

        public IPizza CreatePizza()
        {
            return new PizzaWithChickenMushroomsPepper();
        }
        public override string ToString()
        {
            return "Кафе Гараж";
        }
        public decimal GetPriceBarbecue(int weight)
        {
            return ((barbecue*mark_Price)* ((decimal)weight / 100));
        }

        public decimal GetPricePizza(int weight)
        {
            return ((pizza*mark_Price)*((decimal)weight / 100));
        }

        public void Update(decimal pizza, decimal barbecue)
        {
            this.pizza = pizza;
            this.barbecue = barbecue;
        }
    }
}
