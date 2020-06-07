using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Model
{
    class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //свойство навигации
        public virtual ICollection<User> Users { get; set; }
    }
}
