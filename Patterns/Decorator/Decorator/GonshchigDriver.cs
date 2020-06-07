using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class GonshchigDriver:DecoratorDriver
    {
        public GonshchigDriver(Driver driver):base(driver)
        {

        }
        string AddGonshchig()
        {
            return "Speeding up. ";
        }
        public override string Drive()
        {
            return (base.Drive()+AddGonshchig());
        }
    }
}
