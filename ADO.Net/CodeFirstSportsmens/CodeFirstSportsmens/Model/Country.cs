﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstSportsmens.Model
{
    class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Sportsman> Sportsmen { get; set; }
    }
}