using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPatterns.Observer;

namespace ExamPatterns.AbstractFactory
{
    class PizzaWithSeafoodCheese:IPizza
    {
        public string CreatePizza(int weight)
        {
            return ("Пицца с морепродуктами и сыром " + weight + " гр.");
        }
    }
}
