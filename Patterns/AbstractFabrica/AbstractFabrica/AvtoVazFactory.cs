using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFabrica
{
    public class AvtoVazFactory : IFactory
    {
        //public string Name = "AVTOVAZ";
        public Avtomobile CreateAuto(string color, string engeneType)
        {
            if (engeneType == "Benzine")
                return new BenzineAvtomobile(color, "Lada Vesta","Benzine");
            if (engeneType == "Diesel")
                return new DieselAvtomobile(color, "NIVA","Diesel");
            return null;
        }

        public Motocycle CreateMotocycle(string color, string engineType)
        {
            if (engineType == "Benzine")
                return new BenzineMotocycle(color," AvtoVAZ","Benzine");
            if (engineType == "Diesel")
                return new DieselMotocycle(color, " AvtoVAZ","Diesel");
            return null;
        }
        public override string ToString()
        {
            return "AvtoVAZ";
        }
    }
}
