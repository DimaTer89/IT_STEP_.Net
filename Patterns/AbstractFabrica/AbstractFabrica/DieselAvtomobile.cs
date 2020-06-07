using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFabrica
{
    class DieselAvtomobile:Avtomobile
    {
        public DieselAvtomobile(string color, string model,string engineType)
            : base(color, model,engineType)
        {
           
        }
    }
}
