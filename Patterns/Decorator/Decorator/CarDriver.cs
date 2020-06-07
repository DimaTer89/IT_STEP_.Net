using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class CarDriver : Driver
    {
        public override string Drive()
        {
            return ("My name is "+Name+" I am a good Driver. ");
        }
    }
}
