using EasyWeightLoss.DAL.Interfaces;
using EasyWeightLoss.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EasyWeightLoss.DAL.EFRepositories
{
    class UserRepository : IRepositories<User>
    {
        WeightLossContext db;
        public UserRepository(WeightLossContext context)
        {
            db = context;
        }
        public UserRepository(string connect)
        {
            db = new WeightLossContext(connect);
        }
        public void Create(User item)
        {
            db.Users.Add(item);
            db.SaveChanges();
        }
        public User FindById(int id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<User> Get()
        {
            return db.Users.AsNoTracking().ToList();
        }

        public IEnumerable<User> Get(Func<User, bool> predicate)
        {
            return db.Users.AsNoTracking().Where(predicate).ToList();
        }

        public void Remove(User item)
        {
            db.Users.Remove(item);
            db.SaveChanges();
        }

        public void Update(User item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
