using EasyWeightLoss.DAL.Interfaces;
using EasyWeightLoss.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace EasyWeightLoss.DAL.EFRepositories
{
    class CaloriesRepositiry : IRepositories<DailyCalories>
    {
        WeightLossContext db;
        public CaloriesRepositiry(WeightLossContext context)
        {
            db = context;
        }
        public CaloriesRepositiry(string connect)
        {
            db = new WeightLossContext(connect);
        }
        public void Create(DailyCalories item)
        {
            db.DailyCalories.Add(item);
            db.SaveChanges();
        }

        public DailyCalories FindById(int id)
        {
            return db.DailyCalories.Find(id);
        }

        public IEnumerable<DailyCalories> Get()
        {
            return db.DailyCalories.AsNoTracking().ToList();
        }

        public IEnumerable<DailyCalories> Get(Func<DailyCalories, bool> predicate)
        {
            return db.DailyCalories.AsNoTracking().Where(predicate).ToList();
        }

        public void Remove(DailyCalories item)
        {
            db.DailyCalories.Remove(item);
            db.SaveChanges();
        }

        public void Update(DailyCalories item)
        {
            db.Entry(item).State=EntityState.Modified;
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
