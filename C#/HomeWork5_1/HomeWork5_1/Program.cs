using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*1 Создать массив из шести объектов (2 – базового класса, по 2 – каждого производного класса).
  2 Вывести массив на консоль.
  3 Вывести покупку с максимальной стоимостью.
  4 Определить, являются ли все покупки равными.
  Задачи 2–4 реализовать в одном общем цикле.
*/
namespace HomeWork5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            PurchaseOfGoods[] arr =
            {
                new PurchaseOfGoods("Мука", 54.2m, 202),
                new PurchaseOfGoods("Картофель", 54.8m, 500),
                new FixesDiscount("Мясо", 99.88m, 800),
                new FixesDiscount("Сахар", 14.2m, 202),
                new PriceDiscount("Сигареты", 4.8m, 250),
                new PriceDiscount("Водка", 29.88m, 800),
            };
            decimal max = arr[0].GetCost;
            int index = 0;
            for (int i = 0; i < arr.Length; i++)
            {

                Console.WriteLine(arr[i]);
                if(i>=1)
                {
                    if (arr[i].GetCost > max)
                    {
                        max = arr[i].GetCost;
                        index = i;
                    }
                    if (!arr[i].Equals(arr[0]))
                        flag = false;
                }
                Console.WriteLine("=================");
            }
            Console.WriteLine("Товар с максимальной покупкой \n" + arr[index]);
            Console.WriteLine("=================");
            if (!flag)
                Console.WriteLine("Все покупки разные");
            else
                Console.WriteLine("Покупки одинаковые");
            Console.ReadKey();
        }
    }
}
