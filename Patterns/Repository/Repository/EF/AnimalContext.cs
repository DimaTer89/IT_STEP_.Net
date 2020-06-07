using Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EF
{
    class AnimalContext:DbContext
    {
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Cat> Cats { get; set; }
    }
}
