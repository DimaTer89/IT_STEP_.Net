using EasyWeightLoss.DAL.Interfaces;
using EasyWeightLoss.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyWeightLoss.DAL.ADORepositories
{
    class ADOCaloriesRepository : IRepositories<DailyCalories>
    {
        SqlConnection connect;
        string connectString;
        public ADOCaloriesRepository(string connectString)
        {
            this.connectString = connectString;
        }
        public void Create(DailyCalories item)
        {
            using (connect = new SqlConnection(connectString))
            {
                connect.Open();
                using (SqlCommand insert = connect.CreateCommand())
                {
                    insert.CommandText = "insert into CalorieNorms (Sex,MinAge,MaxAge,Level,CalorieRange_Min,CalorieRange_Max) values (@s,@min,@max,@l,@cmin,@cmax)";
                    insert.Parameters.AddWithValue("@s", (int)item.Sex);
                    insert.Parameters.AddWithValue("@min", item.MinAge);
                    insert.Parameters.AddWithValue("@max", item.MaxAge);
                    insert.Parameters.AddWithValue("@l", (int)item.ActivityLevel);
                    insert.Parameters.AddWithValue("@cmin", item.CalorieRange.Min);
                    insert.Parameters.AddWithValue("@cmax", item.CalorieRange.Max);
                    insert.ExecuteNonQuery();
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
        public DailyCalories FindById(int id)
        {
            DailyCalories calorie = new DailyCalories();
            using (connect = new SqlConnection(connectString))
            {
                connect.Open();
                using (SqlCommand cmd = connect.CreateCommand())
                {
                    cmd.CommandText = "select Sex,MinAge,MaxAge,Level,CalorieRange_Min,CalorieRange_Max from CalorieNorms where Id=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        calorie.Sex = (Sex)dataReader.GetInt32(0);
                        calorie.MinAge = dataReader.GetInt32(1);
                        calorie.MaxAge = dataReader.GetInt32(2);
                        calorie.ActivityLevel = (ActivityLevel)dataReader.GetInt32(3);
                        calorie.CalorieRange = new CalorieRange { Min = dataReader.GetInt32(4), Max = dataReader.GetInt32(5) };
                    }
                }
            }
            return calorie;

        }

        public IEnumerable<DailyCalories> Get()
        {
            List<DailyCalories> list = new List<DailyCalories>();
            using (connect = new SqlConnection(connectString))
            {
                connect.Open();
                using (SqlCommand cmd = connect.CreateCommand())
                {
                    cmd.CommandText = "select Sex,MinAge,MaxAge,Level,CalorieRange_Min,CalorieRange_Max from CalorieNorms";
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while(dataReader.Read())
                        {
                            list.Add(new DailyCalories
                            {
                                Sex = (Sex)dataReader.GetInt32(0),
                                MinAge = dataReader.GetInt32(1),
                                MaxAge = dataReader.GetInt32(2),
                                ActivityLevel = (ActivityLevel)dataReader.GetInt32(3),
                                CalorieRange = new CalorieRange { Min = dataReader.GetInt32(4), Max = dataReader.GetInt32(5) }
                            });
                        }
                    }
                }
                return list;
            }
        }

        public IEnumerable<DailyCalories> Get(Func<DailyCalories, bool> predicate)
        {
            List<DailyCalories> list = Get().ToList();
            return list.Where(predicate);
        }

        public void Remove(DailyCalories item)
        {
            using (connect = new SqlConnection(connectString))
            {
                connect.Open();
                using (SqlCommand delete = connect.CreateCommand())
                {
                    delete.CommandText = "delete from CalorieNorms where Id=@id";
                    delete.Parameters.AddWithValue("@id", item.Id);
                    delete.ExecuteNonQuery();
                }
            }
        }

        public void Update(DailyCalories item)
        {
            using (connect = new SqlConnection(connectString))
            {
                connect.Open();
                using (SqlCommand update = connect.CreateCommand())
                {
                    update.CommandText = "update CalorieNorms set Sex=@s,MinAge=@min,MaxAge=@max,Level=@l,CalorieRange_Min=@cmin,CalorieRange_Max=@cmax where Id=@id";
                    update.Parameters.AddWithValue("@s", (int)item.Sex);
                    update.Parameters.AddWithValue("@min", item.MinAge);
                    update.Parameters.AddWithValue("@max", item.MaxAge);
                    update.Parameters.AddWithValue("@l", (int)item.ActivityLevel);
                    update.Parameters.AddWithValue("@cmin", item.CalorieRange.Min);
                    update.Parameters.AddWithValue("@cmax", item.CalorieRange.Max);
                    update.ExecuteNonQuery();
                }
            }
        }
    }
}
