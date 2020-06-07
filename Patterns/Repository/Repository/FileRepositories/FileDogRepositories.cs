using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interfaces;
using Repository.Models;
using System.IO;

namespace Repository.FileRepositories
{
    class FileDogRepositories : IRepository<Dog>
    {
        List<Dog> dogs = new List<Dog>();
        public FileDogRepositories()
        {
            string[] tmp;
            using (StreamReader reader = new StreamReader("dogList.txt", Encoding.Default))
            {
                while (!reader.EndOfStream)
                {
                    tmp = reader.ReadLine().Split(';');
                    dogs.Add(new Dog { Id = Convert.ToInt32(tmp[0]), Name = tmp[1], Age = Convert.ToInt32(tmp[2]) });
                }   
            }
        }

        public void Create(Dog item)
        {
            if (!dogs.Any(d => d.Id == item.Id))
            {
                dogs.Add(item);
                using (StreamWriter writer = new StreamWriter("dogList.txt",true,Encoding.Default))
                {
                    writer.WriteLine(item.Id + ";" + item.Name + ";" + item.Age);
                }
            }
            else
                throw new Exception("Собака есть в базе");
        }

        public void Delete(int id)
        {
            Dog dog = dogs.First(d => d.Id == id);
            dogs.Remove(dog);
            using (StreamWriter writer = new StreamWriter("dogList.txt", false, Encoding.Default))
            {
                foreach (var Dog in dogs)
                {
                    writer.WriteLine(Dog.Id + ";" + Dog.Name + ";" + Dog.Age);
                }
            }
        }

        public Dog Get(int id)
        {
            Dog dog=dogs.First(d=>d.Id==id);
            return dog;
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
            using (StreamWriter writer = new StreamWriter("dogList.txt", false, Encoding.Default))
            {
                foreach (var Dog in dogs)
                {
                    writer.WriteLine(Dog.Id + ";" + Dog.Name + ";" + Dog.Age);
                }
            }
        }
    }
}
