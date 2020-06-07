﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace LinqSQL
{
    public class MonkeysDataContext:DataContext
    {
        public MonkeysDataContext(string connectionString) : base(connectionString)
        {
            Monkeys = GetTable<Monkey>();
        }
        public Table<Monkey> Monkeys { get; set; }
    }
}
