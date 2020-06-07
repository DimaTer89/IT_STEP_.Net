using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPatterns.AbstractFactory;

namespace ExamPatterns.Decorator
{
    class PizzaSeaFoodCheese:PizzaDecorator
    {
        public PizzaSeaFoodCheese(IPizza pizza):base(pizza)
        { }
        public override string CreatePizza(int weight)
        {
            return (pizza.CreatePizza(weight) + " с овощами ");
        }
    }
}
