using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace independentWork
{
    [Table(Name ="Herd")]
    public class Cow
    {
        [Column(IsPrimaryKey = true,IsDbGenerated = true)]
        public int Id { get; set; }
        [Column]
        public string cowName { get; set; }
        [Column(Name ="milkFeeds")]
        public int Nadoi { get; set; }

    }
}
