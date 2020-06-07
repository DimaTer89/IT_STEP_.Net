using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFabrica
{
    //абстракция продукта 1
    public abstract class Motocycle
    {
        private string color;
        private string model;
        private string engineType;
        public Motocycle(string color, string model,string eT)
        {
            this.color = color;
            this.model = model;
            engineType = eT;
        }

        public override string ToString()
        {
            return (model + " " + color + " " + engineType);
        }
    }
}