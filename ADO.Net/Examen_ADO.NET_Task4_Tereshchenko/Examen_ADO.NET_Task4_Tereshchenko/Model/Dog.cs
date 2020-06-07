using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_ADO.NET_Task4_Tereshchenko.Model
{
    class Dog
    {
        public int Id { get; set; }
        public int BreedId { get; set; }
        public string DogName { get; set; }
        public int Height { get; set; }
        public virtual Breed Breed { get; set; }
    }
}
