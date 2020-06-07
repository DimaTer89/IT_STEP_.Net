using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Model
{
    class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        //public int CountryId { get; set; }
        //свойство навигации
        public virtual Country Country { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
