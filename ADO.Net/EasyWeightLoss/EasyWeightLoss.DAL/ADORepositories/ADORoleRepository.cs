using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyWeightLoss.DAL.Interfaces;
using EasyWeightLoss.DAL.Model;
    

namespace EasyWeightLoss.DAL.ADORepositories
{
    class ADORoleRepository : IRepositories<Role>
    {
        SqlConnection connect;
        string connectString;
        public ADORoleRepository(string connectString)
        {
            this.connectString = connectString;
        }
        public void Create(Role item)
        {
            using (connect = new SqlConnection(connectString))
            {
                connect.Open();
                using (SqlCommand cmd = connect.CreateCommand())
                {
                    cmd.CommandText = "insert into Roles(NameRole) values(@name)";
                    cmd.Parameters.AddWithValue("@name", item.NameRole);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    connect.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Role FindById(int id)
        {
            Role role = new Role();
            using (connect = new SqlConnection(connectString))
            {
                connect.Open();
                using (SqlCommand cmd = connect.CreateCommand())
                {
                    cmd.CommandText = "select * from Roles where Id=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        role.Id = reader.GetInt32(0);
                        role.NameRole = reader.GetString(1);
                    }
                }
            }
            return role;
        }

        public IEnumerable<Role> Get()
        {
            List<Role> roles = new List<Role>();
            using (connect = new SqlConnection(connectString))
            {
                connect.Open();
                using (SqlCommand cmd = connect.CreateCommand())
                {
                    cmd.CommandText = "select * from Roles";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            roles.Add(new Role { Id = reader.GetInt32(0), NameRole = reader.GetString(1) });
                    }
                }
            }
            return roles;
        }

        public IEnumerable<Role> Get(Func<Role, bool> predicate)
        {
            List<Role> roles = new List<Role>();
            roles = Get().ToList();
            return roles.Where(predicate);
        }

        public void Remove(Role item)
        {
            using (connect = new SqlConnection(connectString))
            {
                connect.Open();
                using (SqlCommand cmd = connect.CreateCommand())
                {
                    cmd.CommandText = "delete from Roles where Id=@id";
                    cmd.Parameters.AddWithValue("@id", item.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Role item)
        {
            using (connect = new SqlConnection(connectString))
            {
                connect.Open();
                using (SqlCommand cmd = connect.CreateCommand())
                {
                    cmd.CommandText = "update Roles set NameRole=@name where Id=@id";
                    cmd.Parameters.AddWithValue("@id", item.Id);
                    cmd.Parameters.AddWithValue("@name", item.NameRole);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
