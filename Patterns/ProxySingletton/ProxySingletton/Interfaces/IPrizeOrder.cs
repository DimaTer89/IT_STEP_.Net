using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxySingletton.Interfaces
{
    interface IPrizeOrder
    {
        string Name { get; }

        string CreatePrizeOrder(string Name,decimal bonusPrecenge);
        
    }
}
