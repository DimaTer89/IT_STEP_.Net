using Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Classes
{
    class AirPlaneToTransport : ITransport
    {
        IAirplane airplane;
        public AirPlaneToTransport(IAirplane airplane)
        {
            this.airplane = airplane;
        }
        public string Drive()
        {
            return airplane.Fly();
        }
    }
}
