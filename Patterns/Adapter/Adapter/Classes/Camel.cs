using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adapter.Interfaces;

namespace Adapter.Classes
{
    class Camel : IAnimal
    {
        public string Move()
        {
            return "We are riding a camel";
        }
    }
}
