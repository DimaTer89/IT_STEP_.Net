using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class BusDriver:DecoratorDriver
    {
        public BusDriver(Driver driver):base(driver)
        {

        }
        string addBus()
        {
            return "I manage the bus. ";
        }
        public override string Drive()
        {
            return (base.Drive()+addBus());
        }
    }
}
