using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyWeightLoss.DAL.Interfaces;
using EasyWeightLoss.DAL.Model;
using System.Data.SqlClient;
using System.Data;

namespace EasyWeightLoss.DAL.ADORepositories
{
    class ADOUserRepository : IRepositories<User>
    {
        SqlConnection connect;
        SqlDataReader dataReader;
        string connectString;
        public ADOUserRepository(string connect)
        {
            connectString = connect;
        }
        public void Create(User item)
        {
            using (connect = new SqlConnection(connectString))
            {
                try
                {
                    connect.Open();
                    using (SqlCommand cmd = connect.CreateCommand())
                    {
                        cmd.CommandText = "insert into Clients(Nickname,Password) values(@n,@p)";
                        cmd.Parameters.AddWithValue("@n", item.Login);
                        cmd.Parameters.AddWithValue("@p", item.Password);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "select ClientId from Clients where Nickname=@name";
                        cmd.Parameters.AddWithValue("@name", item.Login);
                        int id = Convert.ToInt32(cmd.ExecuteScalar());
                        cmd.CommandText = "insert into ClientProfiles (ClientId,Age,Sex,ActivityLevel) values(@c,@a,@s,@al)";
                        cmd.Parameters.AddWithValue("@c", id);
                        cmd.Parameters.AddWithValue("@a", item.Age);
                        cmd.Parameters.AddWithValue("@s", (int)item.Sex);
                        cmd.Parameters.AddWithValue("@al", (int)item.ActivityLevel);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch
                { }
            }
        }
        protected bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    connect.Close();
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(disposed);
            GC.SuppressFinalize(this);
        }

        public User FindById(int id)
        {
            User user = new User();
            using (connect = new SqlConnection(connectString))
            {
                connect.Open();
                using (SqlCommand find = connect.CreateCommand())
                {
                    find.CommandText = "select c.ClientId,c.Nickname,c.Password,cp.Age,cp.Sex,cp.ActivityLevel from Clients c left join ClientProfiles cp on cp.ClientId=c.ClientId where c.ClientId=@id";
                    find.Parameters.AddWithValue("@id", id);
                    using (dataReader = find.ExecuteReader())
                    {
                        user.ClientId = dataReader.GetInt32(0);
                        user.Login = dataReader.GetString(1);
                        user.Password = dataReader.GetString(2);
                        user.Age = dataReader.GetInt32(3);
                        user.Sex = (Sex)dataReader.GetInt32(4);
                        user.ActivityLevel = (ActivityLevel)dataReader.GetInt32(5);
                    }
                }
            }
            return user;
        }

        public IEnumerable<User> Get()
        {
            List<User> list = new List<User>();
            using (connect = new SqlConnection(connectString))
            {
                connect.Open();
                using (SqlCommand cmd = connect.CreateCommand())
                {
                    cmd.CommandText = "select c.ClientId,c.Nickname,c.Password,cp.Age,cp.Sex,cp.ActivityLevel from Clients c left join ClientProfiles cp on cp.ClientId=c.ClientId";
                    using (dataReader = cmd.ExecuteReader())
                    {
                        while(dataReader.Read())
                        {
                            list.Add(new User
                            {
                                ClientId = dataReader.GetInt32(0),
                                Login = dataReader.GetString(1),
                                Password = dataReader.GetString(2),
                                Age = dataReader.GetInt32(3),
                                Sex = (Sex)dataReader.GetInt32(4),
                                ActivityLevel = (ActivityLevel)dataReader.GetInt32(5)
                            });
                        }
                    }
                }
            }
            return list;
        }

        public IEnumerable<User> Get(Func<User, bool> predicate)
        {
            List<User> list = new List<User>();
            list = Get().ToList();
            return list.Where(predicate);
        }

        public void Remove(User item)
        {
            using (connect = new SqlConnection(connectString))
            {
                connect.Open();
                using (SqlCommand cmd = connect.CreateCommand())
                {
                    cmd.CommandText = "delete from ClientProfiles where ClientId=@id";
                    cmd.Parameters.AddWithValue("@id", item.ClientId);
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "delete from Clients where ClientId=@clientId";
                    cmd.Parameters.AddWithValue("@clientId", item.ClientId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public int ID(string name,string password)
        {
            using (connect = new SqlConnection(connectString))
            {
                connect.Open();
                using (SqlCommand cmd = connect.CreateCommand())
                {
                    cmd.CommandText = "select ClientId from Clients where Nickname=@name and Password=@password";
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@password", password);
                    return Convert.ToInt32(cmd.ExecuteNonQuery());
                }
            }
        }
        public void Update(User item)
        {
            using (connect = new SqlConnection(connectString))
            {
                connect.Open();
                using (SqlCommand cmd = connect.CreateCommand())
                {
                    cmd.CommandText = "update Clients set Nickname=@name,Password=@password where ClientId=@id";
                    cmd.Parameters.AddWithValue("@name", item.Login);
                    cmd.Parameters.AddWithValue("@password", item.Password);
                    cmd.Parameters.AddWithValue("@id", item.ClientId);
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "update ClientProfiles set Age=@age,Sex=@sex,ActivityLevel=@level where ClientId=@clientId";
                    cmd.Parameters.AddWithValue("@age", item.Age);
                    cmd.Parameters.AddWithValue("@sex", (int)item.Sex);
                    cmd.Parameters.AddWithValue("@level", (int)item.ActivityLevel);
                    cmd.Parameters.AddWithValue("@clientId", item.ClientId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}


