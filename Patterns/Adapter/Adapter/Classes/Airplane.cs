using Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Classes
{
    class Airplane : IAirplane
    {
        public string Fly()
        {
            return "Fly on a plane";
        }
    }
}
