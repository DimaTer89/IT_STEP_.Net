using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_ADO.NET_Task4_Tereshchenko.Model
{
    class Breed
    {
        public int BreedId { get; set; }
        public string Breedname { get; set; }
        public virtual ICollection<Dog> Dogs { get; set; }
        public Breed()
        {
            Dogs = new List<Dog>();
        }
    }
}
