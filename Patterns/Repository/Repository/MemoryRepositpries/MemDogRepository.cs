using Repository.Interfaces;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.MemoryRepositpries
{
    class MemDogRepository : IRepository<Dog>
    {
        static List<Dog> dogs = new List<Dog>();
        static MemDogRepository()
        {
            dogs.Add(new Dog { Id = 1, Name = "Жучка", Age = 7 });
            dogs.Add(new Dog { Id = 2, Name = "Внучка", Age = 3 });
        }
        public void Create(Dog item)
        {
            if (!dogs.Any(d => d.Id == item.Id))
                dogs.Add(item);
            else
                throw new Exception("Такая собака уже есть!");
        }

        public void Delete(int id)
        {
            Dog dog = dogs.First(d => d.Id == id);
            dogs.Remove(dog);
        }
    

        public Dog Get(int id)
        {
            return dogs.First(d => d.Id == id); 
        }

        public IEnumerable<Dog> GetAll()
        {
            return dogs;
        }

        public void Update(Dog item)
        {
            Dog dog = dogs.First(d => d.Id == item.Id);
            dog.Id = item.Id;
            dog.Name = item.Name;
            dog.Age = item.Age;
        }
    }
}
