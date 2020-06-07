using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*	Создает два объекта класса «Функция» (параметры функций вводятся с клавиатуры).
	Для каждого объекта вычисляет значения для трех различных значений аргумента.
	Для каждого объекта–функции выполняет табулирование для ряда значений аргумента. Результат выводить в виде таблицы, в заголовке таблицы приводить вид функции.
*/

namespace HomeWork2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            double xb, xe, xs;
            Function function1 = new Function();
            Function function2 = new Function();
            double a1, b1, x1, a2, b2, x2, a3, b3, x3;
            Input2(out a1, out b1, out x1, out a2, out b2, out x2, out a3, out b3, out x3);
            vyvod(function1, a1, b1, x1, a2, b2, x2, a3, b3, x3);
            Tablica tablica1 = new Tablica("x", "f(x)");
            tablica1.up_frame();
            vyvodTablica(tablica1, function1, x1, x2, x3);
            tablica1.down_frame();
            Input2(out a1, out b1, out x1, out a2, out b2, out x2, out a3, out b3, out x3);
            vyvod(function2, a1, b1, x1, a2, b2, x2, a3, b3, x3);
            tablica1.up_frame();
            vyvodTablica(tablica1, function2, x1, x2, x3);
            tablica1.down_frame();
            Console.WriteLine("Табуляция для первого объекта функции ");
            Input(function1);
            Function.EnterValues(out xb, out xe, out xs);
            Tablica tablica2 = new Tablica("x", "f(x)", name: function1.ToString());
            tablica2.up_frame();
            PrintString(tablica2, function1, xb, xe, xs);
            tablica2.down_frame();
            Console.WriteLine("Табуляция для второго объекта функции ");
            Input(function2);
            Function.EnterValues(out xb, out xe, out xs);
            Tablica tablica3 = new Tablica("x", "f(x)", name: function2.ToString());
            tablica3.up_frame();
            PrintString(tablica3, function1, xb, xe, xs);
            tablica3.down_frame();
            Console.ReadKey();
        }
        static void vyvodTablica(Tablica tablica,Function function,double x1,double x2,double x3)
        {
            tablica.middle_frame(function, x1, function.GetValue(x1));
            tablica.middle_frame(function, x2, function.GetValue(x2));
            tablica.middle_frame(function, x3, function.GetValue(x3));
        }
        static void vyvod(Function function,double a1,double b1,double x1,double a2,double b2,double x2,double a3,double b3,double x3)
        {
            function.A = a1;
            function.B = b1;
            Console.WriteLine("f("+x1+")="+function.GetValue(x1));
            function.A = a2;
            function.B = b2;
            Console.WriteLine("f(" + x2 + ")=" + function.GetValue(x2));
            function.A = a3;
            function.B = b3;
            Console.WriteLine("f(" + x3 + ")=" + function.GetValue(x3));
        }
        static void Input(Function function)
        {
            Console.Write("Введите значение a : ");
            function.A = test();
            Console.Write("Введите значение b : ");
            function.B = test();
        }
        static void Input2(out double a1,out double b1,out double x1,out double a2,out double b2,out double x2,out double a3,out double b3,out double x3, string str = "Введите значение ")
        {
            Console.Write(str+"a1 : ");
            a1 = test();
            Console.Write(str + "b1 : ");
            b1 = test();
            Console.Write(str + "x1 : ");
            x1 = test();
            Console.Write(str + "a2 : ");
            a2 = test();
            Console.Write(str + "b2 : ");
            b2 = test();
            Console.Write(str + "x2 : ");
            x2 = test();
            Console.Write(str + "a3 : ");
            a3 = test();
            Console.Write(str + "b3 : ");
            b3 = test();
            Console.Write(str + "x3 : ");
            x3 = test();
        }
        static double test()
        {
            double num;
            bool flag = false;
            do
            {
                if (!double.TryParse(Console.ReadLine(), out num))
                    Console.Write("Неправильное число, повторите ввод : ");
                else
                    flag = true;
            } while (!flag);
            return num;
        }
        static void PrintString(Tablica tablica,Function function,double xB,double xE,double xS)
        {
            if(xB<=xE)
            {
                while(xB<=xE)
                {
                    tablica.middle_frame(function, xB, function.GetValue(xB));
                    xB = function.TabFunction(xB, xE, xS);
                }
                return ;
            }
            if(xB>xE)
            {
                while(xB>xE)
                {
                    tablica.middle_frame(function, xB, function.GetValue(xB));
                    xB = function.TabFunction(xB, xE, xS);
                }
                return;
            }
        }
    }
}
