using Repository.EF;
using Repository.Interfaces;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DBRepositories
{
    class DbDogRepository : IRepository<Dog>
    {
        AnimalContext context = new AnimalContext();
        public void Create(Dog item)
        {
            context.Dogs.Add(item);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Dog Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dog> GetAll()
        {
            return context.Dogs;
        }

        public void Update(Dog item)
        {
            throw new NotImplementedException();
        }
    }
}
