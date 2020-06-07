using Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Driver
    {
        public Driver()
        { }
        public string Travel(ITransport transport)
        {
            return transport.Drive();
        }
    }
}
