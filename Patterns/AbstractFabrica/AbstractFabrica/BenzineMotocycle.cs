using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFabrica
{
    //конкретная реализация продукта мотоцикл абстрактного продукта Motocycle
    public class BenzineMotocycle : Motocycle
    {
        public BenzineMotocycle(string color,string model,string engineType):base(color,model,engineType)
        {

        }
    }
}