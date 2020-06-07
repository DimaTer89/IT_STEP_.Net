using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPatterns.AbstractFactory;

namespace ExamPatterns.Decorator
{
    abstract class PizzaDecorator : IPizza
    {
        protected IPizza pizza;
        public PizzaDecorator(IPizza pizza)
        {
            this.pizza = pizza;
        }
        abstract public string CreatePizza(int weight);
    }
}
