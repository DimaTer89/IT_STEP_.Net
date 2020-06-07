﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adapter.Interfaces;

namespace Adapter.Classes
{
    class Car : ITransport
    {
        public string Drive()
        {
            return "We are driving";
        }
    }
}
