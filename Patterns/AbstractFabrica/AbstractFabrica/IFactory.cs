using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFabrica
{
    public interface IFactory
    {
        Motocycle CreateMotocycle(string color, string engineType);
        Avtomobile CreateAuto(string color,string engeneType);
    }
}
