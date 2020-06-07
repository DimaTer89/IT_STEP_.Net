using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Model
{
    class UserContext:DbContext
    {
        public UserContext():base()
        {

        }
        public UserContext(string connect):base(connect)
        {

        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
    }
}
