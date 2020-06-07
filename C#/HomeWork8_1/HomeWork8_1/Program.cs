using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Написать  статический метод, возвращающий количество элементов одномерного массива целых чисел, удовлетворяющих заданному условию.  Параметры:  массив целых чисел, заданный критерий – объект, содержащий ссылку на метод. Тип этого параметра – делегат  с одним параметром, с логическим типом возвращаемого результата (написать свой делегат). */
//Используя написанный метод, найти: 
/*•	количество элементов массива, квадрат которых не превышает 12.6 (написать метод, ссылку на который передавать в качестве аргумента-критерия отбора);
•	количество отрицательных элементов массива, стоящих на местах кратных 3 ( в качестве аргумента-критерия отбора использовать анонимный метод);
•	количество элементов массива, не принадлежащих интервалу [-3,2.5) (в качестве аргумента-критерия отбора использовать лямбда-выражение);
*/
//Заменить тип параметра-критерия на стандартный делегат Predicate. Предыдущий вариант закомментировать.
//Заменить тип этого параметра на  стандартный делегат Func. Предыдущий вариант закомментировать.
namespace HomeWork8_1
{
    class Program
    {
        const double crit = 12.6;
        delegate bool MyDelegate(int num);
        static void Main(string[] args)
        {
            int[] arr = { 3, 6, 9, 8, 5, -2, 9, -3,-6 };
            Console.WriteLine("Исходный массив");
            foreach (int item in arr)
            {
                Console.Write(item + "  ");
            }
            int i = 1;
            Console.WriteLine();
            MyDelegate myDelegate = FindElem;
            Predicate<int> func = FindElem;
            Func<int[],Predicate<int>,int> func2 = AmountOfElements;
            
            //Console.WriteLine("Количество элементов, квадрат которых не превышает 12.6 : "+AmountOfElements(arr,myDelegate));
            //Console.WriteLine("Количество отрицательных элементов, стоящих на местах кратных трем : "+AmountOfElements(arr,delegate(int num) 
            //{
            //    bool result = ((num < 0) && (i % 3 == 0));
            //    i++;
            //    return result;
            //}));
            //Console.WriteLine("Количество элементов массива, не принадлежащих интервалу [-3,2.5] : "+AmountOfElements(arr,x=>x<-3||x>2.5));
            //Console.WriteLine("Количество элементов, квадрат которых не превышает 12.6 : "+AmountOfElements(arr,func));
            func = delegate (int num)
                  {
                      bool result = ((num < 0) && (i % 3 == 0));
                      i++;
                      return result;
                  };
            //Console.WriteLine("Количество отрицательных элементов, стоящих на местах кратных трем : " + AmountOfElements(arr, func));
            //Console.WriteLine("Количество элементов массива, не принадлежащих интервалу [-3,2.5] : "+AmountOfElements(arr,x=>x<-3||x>2.5));
            func = FindElem;
            Console.WriteLine("Количество элементов, квадрат которых не превышает 12.6 : " + func2(arr,func));
            func= delegate (int num)
            {
                bool result = ((num < 0) && (i % 3 == 0));
                i++;
                return result;
            };
            Console.WriteLine("Количество отрицательных элементов, стоящих на местах кратных трем : " + func2(arr,func));
            Console.WriteLine("Количество элементов массива, не принадлежащих интервалу [-3,2.5] : " + func2(arr,x=>x<3||x>2.5));
            Console.ReadKey();
        }
        static bool FindElem(int num)
        {
            return ((num * num) < crit);
        }
        //static int AmountOfElements(int[] arr, MyDelegate obj)
        //{
        //    int count = 0;
        //    for(int i=0;i<arr.Length;i++)
        //    {
        //        if (obj(arr[i]))
        //            count++;
        //    }
        //    return count;
        //}
        static int AmountOfElements(int[] arr, Predicate<int> obj)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (obj(arr[i]))
                    count++;
            }
            return count;
        }
    }
}
