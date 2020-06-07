using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    abstract class DecoratorDriver:Driver
    {
        protected Driver driver;
        public DecoratorDriver(Driver driver)
        {
            this.driver = driver;
        }
        public override string Drive()
        {
            return driver.Drive();
        }
    }
}
