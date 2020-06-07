using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSQL
{
[Table(Name="Malpy")]
    public class Monkey
    {
        [Column(IsPrimaryKey =true,IsDbGenerated =true)]
        public int Id { get; set; }
        [Column]
        public string Name { get; set; }
        [Column(Name="Kind")]
        public string Vid { get; set; }
        [Column]
        public int Age { get; set; }
    }
}
