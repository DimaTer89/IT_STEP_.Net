using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstSportsmens.Model
{
    class Sportsman
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        [ForeignKey("SportKind")]
        public int KindId { get; set; }
        public virtual SportKind SportKind { get; set; }
        public virtual Country Country { get; set; }
        public int Place { get; set; }
    }
}
