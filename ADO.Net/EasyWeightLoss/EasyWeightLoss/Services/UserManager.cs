using EasyWeightLoss.DAL.Interfaces;
using EasyWeightLoss.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyWeightLoss.Services
{
    class UserManager:IDisposable
    {
        IRepositories<User> repository;
        IRepositories<DailyCalories> calorieRepo;
        public UserManager(IRepositories<User> repository,IRepositories<DailyCalories> calorieRepo)
        {
            this.repository = repository;
            this.calorieRepo = calorieRepo;
        }
        public bool IsExist(string login)
        {
            return repository.Get().Any(log => log.Login == login);
        }
        public bool Validate(string login,string password)
        {
            List<User> list = repository.Get().ToList();
            User us = list.FirstOrDefault(u => u.Login == login && u.Password == password);
            return us != null;
        }
        public void Create(User user)
        {
            if(user!=null)
            {
                if (user.Password.Length < 6)
                    throw new Exception("В пароле меньше 6 символов");
                if (user.Age < 17)
                    throw new Exception("Это приложение не для детей");
                repository.Create(user);
            }
        }
        public IEnumerable<User> GetAll()
        {
            return repository.Get();
        }
        public User FindByLogin(string login)
        {
            return repository.Get().FirstOrDefault(log => log.Login == login);
        }
        public void Update(User user)
        {
            repository.Update(user);
        }
        public CalorieRange GetNorm(User user)
        {
            return calorieRepo.Get(c =>
            c.ActivityLevel == user.ActivityLevel
            && user.Age >= c.MinAge
            && user.Age <= c.MaxAge
            && c.Sex == user.Sex).FirstOrDefault().CalorieRange;
        }
        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            repository.Dispose();
            calorieRepo.Dispose();
        }
    }
}
