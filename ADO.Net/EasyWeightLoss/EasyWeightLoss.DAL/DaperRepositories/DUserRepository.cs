using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using EasyWeightLoss.DAL.Interfaces;
using EasyWeightLoss.DAL.Model;


namespace EasyWeightLoss.DAL.DaperRepositories
{
    class DUserRepository : IRepositories<User>
    {
        IDbConnection connect;
        string connectString;
        public DUserRepository(IDbConnection connect)
        {
            this.connect = connect;
        }
        public DUserRepository(string connect)
        {
            connectString=connect;
        }
        public void Create(User item)
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

        public User FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Get()
        {
            List<User> users;
            using (connect = new SqlConnection(connectString))
            {
                users = connect.Query<User>("select c.ClientId,c.Nickname Login,c.Password,cp.Age,cp.Sex,cp.ActivityLevel from Clients c left join ClientProfiles cp on cp.ClientId=c.ClientId", splitOn: "Login").Select(us => new { us.Login, us.Password, us.Age, us.Sex, us.ActivityLevel }).ToList();
            }
            return users;  
        }

        public IEnumerable<User> Get(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Remove(User item)
        {
            throw new NotImplementedException();
        }

        public void Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
