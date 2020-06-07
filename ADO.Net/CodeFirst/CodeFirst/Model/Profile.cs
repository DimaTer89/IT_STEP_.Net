using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Model
{
    class Profile
    {
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public virtual User User { get; set; }
    }
}
