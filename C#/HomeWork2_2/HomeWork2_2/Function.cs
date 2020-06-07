using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Создать класс «Функция», описывающий объекты - функции из семейства функций заданного вида  . Класс должен содержать следующие элементы: 
­	+Закрытые поля для хранения значения параметров функции a и b.
­	+Свойства для доступа к параметрам функции.
­	+Метод для вычисления значения функции (входной параметр – значение аргумента х).
­	-+Метод для табулирования функции (входные параметры - хнач, хкон, шаг ∆х). При хнач <= хкон шаг прибавлять, при хнач > хкон шаг вычитать (использовать тернарную операцию ? :).
­	+Метод ToString(), результатом которого является строковое представление функции.
­	+Статический метод для ввода начального значения аргумента, конечного значения аргумента и шага изменения аргумента функции (выходные параметры - хнач, хкон, шаг ∆х) Ввод продолжать до тех пор пока не будет введен шаг ∆х>= 0.
*/
namespace HomeWork2_2
{
    class Function
    {
        double a;
        double b;
        public double A
        {
            get
            {
                return a;
            }
            set
            {
                a = value;
            }
        }
        public double B
        {
            get
            {
                return b;
            }
            set
            {
                b = value;
            }
        }
        public double GetValue(double num)
        {
            return ((1 + Math.Pow((Math.Cos(num + a)), 2)) / Math.Abs(Math.Pow(num, 3) - 2 * Math.Pow(b, 2)));
        }
        public double TabFunction(double xB,double xE,double xS)
        {
            double sum=(xB <= xE ? xB+=xS : xB-=xS);
            return sum;
        }
        static public void EnterValues(out double xB,out double xE,out double xS)
        {
            Console.Write("Введите начальное значение х : ");
            xB = test();
            Console.Write("Введите конечное значение x : ");
            xE = test();
            Console.Write("Введите шаг : ");
            do
            {
                xS = test();
                if (xS < 0) Console.Write("Вы неправильно ввели данные, шаг не может быть отрицательным значением, введите снова : ");
            } while (xS < 0);
        }
        public override string ToString()
        {
            return ("f(x)=1+cos^2(x+"+a+")/|x^3-2*"+b+"^2|");
        }
        static double test()
        {
            double num;
            bool flag = false;
            do
            {
                if (!double.TryParse(Console.ReadLine(), out num))
                    Console.Write("Неприавильное число введите снова : ");
                else
                    flag = true;
            } while (!flag);
            return num;
        }
    }
}
 