using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFabrica
{
    public class VWFactory : IFactory
    {
        //public string Name = "Volkswagen";
        public Avtomobile CreateAuto(string color, string engeneType)
        {
            if (engeneType == "Benzine")
                return new BenzineAvtomobile(color, "VW Golf GT1","Benzine");
            if (engeneType == "Diesel")
                return new DieselAvtomobile(color, "VW Passat","Diesel");
            return null;
        }

        public Motocycle CreateMotocycle(string color, string engineType)
        {
            if (engineType == "Benzine")
                return new BenzineMotocycle(color, "Кубельваген","Benzine");
            //if (engineType == "Diesel")
            //    return new DieselMotocycle("match","No","found");
            return null;
        }
        public override string ToString()
        {
            return "Volkswagen";
        }
    }
}
