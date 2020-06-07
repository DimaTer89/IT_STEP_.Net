using EasyWeightLoss.DAL.Interfaces;
using EasyWeightLoss.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyWeightLoss.DAL.ADORepositories
{
    class ADOProductRepository : IRepositories<Product>
    {
        SqlConnection connect;
        SqlDataReader dataReader;
        SqlCommand cmd = new SqlCommand();
        public ADOProductRepository(SqlConnection connect)
        {
            this.connect = connect;
            
        }
        public ADOProductRepository(string connect)
        {
            this.connect = new SqlConnection(connect);
        }
        public void Create(Product item)
        {
            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "insert into Products (Name,EnergyValue) values(@name,@energy)";
            cmd.Parameters.Add("@name",SqlDbType.NVarChar);
            cmd.Parameters.Add("@energy",SqlDbType.Int);
            cmd.Parameters["@name"].Value = item.Name;
            cmd.Parameters["@energy"].Value = item.EnergyValue;
            cmd.ExecuteNonQuery();
            connect.Close();
        }
        protected bool disposed = false;
        public void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if(disposing)
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

        public Product FindById(int id)
        {
            Product prod = new Product();
            connect.Open();
            cmd.CommandText = "select * from Products";
            cmd.Connection = connect;
            using (dataReader = cmd.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    if (dataReader.GetInt32(0) == id)
                    {
                        prod.Id = dataReader.GetInt32(0);
                        prod.Name = dataReader.GetString(1);
                        prod.EnergyValue = dataReader.GetInt32(2);
                    }
                }
                connect.Close();
                return prod;
            }
        }
        public IEnumerable<Product> Get()
        {
            List<Product> list = new List<Product>();
            connect.Open();
            cmd.CommandText = "select * from Products";
            cmd.Connection = connect;
            using (dataReader = cmd.ExecuteReader())
            {
                while (dataReader.Read())
                    list.Add(new Product { Id = dataReader.GetInt32(0), Name = dataReader.GetString(1), EnergyValue = dataReader.GetInt32(2) });
            }
            connect.Close();
            return list;
        }

        public IEnumerable<Product> Get(Func<Product, bool> predicate)
        {
            List<Product> list = new List<Product>();
            connect.Open();
            cmd.CommandText = "select * from Products";
            cmd.Connection = connect;
            using (dataReader = cmd.ExecuteReader())
            {
                while (dataReader.Read())
                    list.Add(new Product { Id = dataReader.GetInt32(0), Name = dataReader.GetString(1), EnergyValue = dataReader.GetInt32(2) });
            }
            connect.Close();
            return list.Where(predicate);
        }

        public void Remove(Product item)
        {
            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "delete from  Products  where Id=@id";
            cmd.Parameters["@id"].Value = item.Id;
            cmd.ExecuteNonQuery();
            connect.Close();
        }

        public void Update(Product item)
        {
            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "update Products set Name=@name,EnergyValue=@energy where Id=@id";
            cmd.Parameters.Add("@name", SqlDbType.NVarChar);
            cmd.Parameters.Add("@energy", SqlDbType.Int);
            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters["@id"].Value = item.Id;
            cmd.Parameters["@name"].Value = item.Name;
            cmd.Parameters["@energy"].Value = item.EnergyValue;
            cmd.ExecuteNonQuery();
            connect.Close();
        }
    }
}
