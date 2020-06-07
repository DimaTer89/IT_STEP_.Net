using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*int[] values1 = new int[5] { 1, 10, 5, 13, 4 }; 
int[] values2 = new int[5] { 19, 1, 4, 9, 8 };
 1) Посчитать среднее значение четных элементов, которые больше 10. 
 2) Выбрать только уникальные элементы из массивов values1 и values2. 
 3) Найти максимальный элемент массива values2, который есть в массиве values1. 
 4) Посчитать сумму элементов массивов values1 и values2, которые попадают в диапазон от 5 до 15.
 5) Отсортировать элементы массивов values1 и values2 по убыванию.
*/
namespace HomeWork10_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] values1 = new int[5] { 1, 10, 5, 13, 4 };
            int[] values2 = new int[5] { 19, 1, 4, 9, 8 };
            var unickQuery = values1.Except(values2);
            var sortValues1Query = values1.OrderByDescending(list => list);
            var sortValues2Query = values2.OrderByDescending(list => list);
            //Посчитать среднее значение четных элементов, которые больше 10.
            Console.WriteLine("*****************");
            Console.WriteLine("1 - Среднее значение четных элементов, которые больше 10");
            Console.WriteLine($"{values1.Concat(values2).Where(list => list < 10 && (list % 2 == 0)).Average(list => list):f2}");
            //Выбрать только уникальные элементы из массивов values1 и values2. 
            Console.WriteLine("*****************");
            Console.WriteLine("2 - Только уникальные элементы из массивов values1 и values2");
            foreach (var item in unickQuery)
            {
                Console.Write(item + "  ");
            }
            Console.WriteLine();
            //Найти максимальный элемент массива values2, который есть в массиве values1. 
            Console.WriteLine("*****************");
            Console.WriteLine("3 - Максимальный элемент массива values2, который есть в массиве values1");
            Console.WriteLine(values2.Join(values1, list => list, list2 => list2, (list, list2) => list).Max(list => list));
            //Посчитать сумму элементов массивов values1 и values2, которые попадают в диапазон от 5 до 15.
            Console.WriteLine("*****************");
            Console.WriteLine("4 - Сумма элементов массивов values1 и values2, которые попадают в диапазон от 5 до 15");
            Console.WriteLine(values1.Concat(values2).Where(list => list >= 5 && list <= 15).Sum(list => list));
            //Отсортировать элементы массивов values1 и values2 по убыванию.
            Console.WriteLine("*****************");
            Console.WriteLine("5 - Отсортированные элементы values1");
            foreach (var item in sortValues1Query)
            {
                Console.Write(item + "  ");
            }
            Console.WriteLine();
            Console.WriteLine("5 - Отсортированные элементы values2");
            foreach (var item in sortValues2Query)
            {
                Console.Write(item + "  ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
