using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPatterns.AbstractFactory
{
    interface ICafeFactory
    {
        IPizza CreatePizza();
        IBarbecue CreateBarbecue();
    }
}
