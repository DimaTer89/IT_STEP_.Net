using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*1)	Упорядочить имена и фамилии сотрудников по алфавиту, которые проживают в Украине. Выполнить запрос немедленно. 
  2)	Отсортировать сотрудников по возрастам, по убыванию. Вывести Id, FirstName, LastName, Age. Выполнить запрос немедленно. 
  3)	Сгруппировать студентов по возрасту. Вывести возраст и сколько раз он встречается в списке.
*/
namespace HomeWork10_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Department> departments = new List<Department>()
            {
                new Department(){ Id = 1, Country = "Ukraine", City = "Donetsk" },
                new Department(){ Id = 2, Country = "Ukraine", City = "Kyiv" },
                new Department(){ Id = 3, Country = "France", City = "Paris" },
                new Department(){ Id = 4, Country = "Russia", City = "Moscow" }
            };
            List<Employee> employees = new List<Employee>()
            {
                new Employee()
                {
                      Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2
                },
                new Employee()
                {
                      Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1
                },
                new Employee()
                {
                      Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3
                },
                new Employee()
                {
                      Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2
                },
                new Employee()
                {
                      Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4
                },
                new Employee()
                {
                      Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2
                },
                new Employee()
                {
                      Id = 7, FirstName = "Nikita", LastName = "Krotov", Age = 27, DepId = 4
                }
            };
            //foreach (Department item in departments)
            //{
            //    Console.WriteLine(item.Id+" : "+item.Country+" : "+item.City);
            //}
            //foreach (Employee item in employees)
            //{
            //    Console.WriteLine(item.Id+" : "+item.FirstName+" : "+item.LastName+" : "+item.DepId+" : "+item.Age);
            //}
            //Упорядочить имена и фамилии сотрудников по алфавиту, которые проживают в Украине. Выполнить запрос немедленно.
            Console.WriteLine("Упорядочить имена и фамилии сотрудников по алфавиту, которые проживают в Украине.");
            employees
                .Join(departments, name => name.DepId, dept => dept.Id, (name, dept) => new { name.FirstName, name.LastName, dept.Country })
                .Where(country => country.Country == "Ukraine").Select(list => new { list.FirstName, list.LastName, list.Country })
                .OrderBy(list => list.FirstName).ToList().ForEach(list => Console.WriteLine(list.FirstName + " : " + list.LastName + " : " + list.Country));
           Console.WriteLine("******************************");
            //Отсортировать сотрудников по возрастам, по убыванию. Вывести Id, FirstName, LastName, Age. Выполнить запрос немедленно.
            Console.WriteLine("Отсортировать сотрудников по возрастам, по убыванию. Вывести Id, FirstName, LastName, Age.");
            employees.OrderByDescending(age => age.Age)
                .Select(newList => new { newList.Id, newList.FirstName, newList.LastName, newList.Age })
                .ToList().ForEach(list => Console.WriteLine(list.Id + " : " + list.FirstName + " : " + list.LastName + " : " + list.Age));
            //Сгруппировать студентов по возрасту. Вывести возраст и сколько раз он встречается в списке.
            Console.WriteLine("******************************");
            Console.WriteLine("Сгруппировать студентов по возрасту. Вывести возраст и сколько раз он встречается");
            employees.GroupBy(age => age.Age).Select(group => new { group.Key, Count = group.Count() }).ToList().ForEach(list => Console.WriteLine(list.Key + " : " + list.Count));
            Console.ReadKey();
        }
    }
}
