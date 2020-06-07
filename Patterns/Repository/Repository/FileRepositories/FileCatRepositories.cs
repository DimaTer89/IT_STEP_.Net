using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;
using Repository.Interfaces;
using System.IO;

namespace Repository.FileRepositories
{
    class FileCatRepositories : IRepository<Cat>
    {
        List<Cat> cats = new List<Cat>();
        public FileCatRepositories()
        {
            string[] tmp;
            using (StreamReader reader = new StreamReader("catList.txt", Encoding.Default))
            {
                while (!reader.EndOfStream)
                {
                    tmp = reader.ReadLine().Split(';');
                    cats.Add(new Cat { Id = Convert.ToInt32(tmp[0]), Name = tmp[1], Weight = Convert.ToDouble(tmp[2]) });
                }
            }
        }

        public void Create(Cat item)
        {
            if (!cats.Any(d => d.Id == item.Id))
            {
                cats.Add(item);
                using (StreamWriter writer = new StreamWriter("catList.txt", true, Encoding.Default))
                {
                    writer.WriteLine(item.Id + ";" + item.Name + ";" + item.Weight);
                }
            }
            else
                throw new Exception("Кот есть в базе");

        }

        public void Delete(int id)
        {
            Cat cat = cats.First(d => d.Id == id);
            cats.Remove(cat);
            using (StreamWriter writer = new StreamWriter("catList.txt", false, Encoding.Default))
            {
                foreach (var Cat in cats)
                {
                    writer.WriteLine(Cat.Id + ";" + Cat.Name + ";" + Cat.Weight);
                }
            }
        }

        public Cat Get(int id)
        {
            Cat cat = cats.First(d => d.Id == id);
            return cat;
        }

        public IEnumerable<Cat> GetAll()
        {
            return cats;
        }

        public void Update(Cat item)
        {
            Cat cat = cats.First(d => d.Id == item.Id);
            cat.Id = item.Id;
            cat.Name = item.Name;
            cat.Weight = item.Weight;
            using (StreamWriter writer = new StreamWriter("dogList.txt", false, Encoding.Default))
            {
                foreach (var Cat in cats)
                {
                    writer.WriteLine(Cat.Id + ";" + Cat.Name + ";" + Cat.Weight);
                }
            }
        }
    }
}
