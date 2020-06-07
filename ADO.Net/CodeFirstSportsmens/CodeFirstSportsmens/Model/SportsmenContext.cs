using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CodeFirstSportsmens.Model
{
    class SportsmenContext:DbContext
    {
        public SportsmenContext():base()
        { }
        public SportsmenContext(string connect):base(connect)
        { }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<SportKind> SportKinds { get; set; }
        public virtual DbSet<Sportsman> Sportsmen { get; set; }
    }
}
