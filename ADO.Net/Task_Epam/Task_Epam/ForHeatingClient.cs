﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Epam
{
    class ForHeatingClient:Client
    {
        public ForHeatingClient(string name,int energyConsurmed,Rate rate,ClientType client=ClientType.ForHeating):base(name,energyConsurmed,rate,client)
        { }
    }
}