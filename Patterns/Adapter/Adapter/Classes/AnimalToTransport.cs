using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adapter.Interfaces;

namespace Adapter.Classes
{
    class AnimalToTransport : ITransport
    {
        IAnimal animal;
        public AnimalToTransport(IAnimal animal)
        {
            this.animal = animal;
        }
        public string Drive()
        {
            return animal.Move();
        }
    }
}
