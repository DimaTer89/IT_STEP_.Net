using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CodeFirstMigrationManyToMany.Model
{
   public class FootballContext:DbContext
    {
        static FootballContext()
        {
            //Database.SetInitializer<FootballContext>(new ContextInitializer());
        }
        public FootballContext():base("Football")
        { }
        public FootballContext(string connect):base(connect)
        { }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Player> Players { get; set; }
    }
}
