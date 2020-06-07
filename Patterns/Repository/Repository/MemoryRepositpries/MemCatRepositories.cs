using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.MemoryRepositpries
{
    class MemCatRepositories : IRepository<Cat>
    {
        List<Cat> cats = new List<Cat>();
        public MemCatRepositories()
        {
            cats.Add(new Cat { Id = 1, Name = "Мурка", Weight = 7.5 });
            cats.Add(new Cat { Id = 2, Name = "Борис", Weight = 8 });
        }
        public void Create(Cat item)
        {
            if (!cats.Any(c => c.Id == item.Id))
                cats.Add(item);
            else
                throw new Exception("Кот в базу уже занесён");
        }

        public void Delete(int id)
        {
            Cat cat = cats.First(num => num.Id == id);
            cats.Remove(cat);
        }

        public Cat Get(int id)
        {
            Cat cat = cats.First(num => num.Id == id);
            return cat;
        }

        public IEnumerable<Cat> GetAll()
        {
            return cats;
        }

        public void Update(Cat item)
        {
            Cat cat=cats.First(c=>c.Id==item.Id);
            cat.Id = item.Id;
            cat.Name = item.Name;
            cat.Weight = item.Weight;
        }
    }
}
