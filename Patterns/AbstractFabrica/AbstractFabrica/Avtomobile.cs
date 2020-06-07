using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFabrica
{
    public abstract class  Avtomobile//AbstractProductB
    {
        string color;
        string model;
        protected string engineType;
        public Avtomobile(string color,string model, string engineType)
        {
            this.color = color;
            this.model = model;
            this.engineType=engineType;
        }

        public override string ToString()
        {
            return (model+" "+color+" "+engineType);
        }
    }
}
