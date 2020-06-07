using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyWeightLoss.DAL.Interfaces;
using EasyWeightLoss.DAL.Model;
using System.Data.SqlClient;
using Dapper;

namespace EasyWeightLoss.DAL.DaperRepositories
{
    class DProductRepositiry : IRepositories<Product>
    {
        IDbConnection connect;
        public DProductRepositiry(IDbConnection connect)
        {
            this.connect = connect;
        }
        public DProductRepositiry(string connect)
        {
            this.connect = new SqlConnection(connect);
        }
        public void Create(Product item)
        {
            throw new NotImplementedException();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    connect.Dispose();
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Product FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Get()
        {
            List<Product> products = connect.Query<Product>("select * from Products").ToList();
            return products;
        }

        public IEnumerable<Product> Get(Func<Product, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Remove(Product item)
        {
            throw new NotImplementedException();
        }

        public void Update(Product item)
        {
            throw new NotImplementedException();
        }
    }
}
