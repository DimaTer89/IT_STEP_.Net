using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Написать программу для решения следующей задачи.
В первый день пловец проплыл 3 км. В каждый следующий день он проплывал на 10% больше, чем в предыдущий. 
а) В какой по счету день пловец начнет проплывать более 5 км? 
б) К какому дню он суммарно проплывет более 30 км? 
*/

namespace HomeWork1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double day_tmp = 3;
            double tmp = 0;
            double sum_day = 3;
            int day_count = 1;
            swimmer_1(day_tmp, tmp, day_count);
            day_count = 1;
            day_tmp = 3;
            swimmer_2(day_tmp, sum_day, tmp, day_count);
            Console.ReadKey();
        }
        static void swimmer_1(double day_tmp,double tmp,int count_day)
        {
            while (day_tmp <= 5)
            {
                tmp = day_tmp + (day_tmp * 0.1);
                day_tmp = tmp;
                count_day++;
            }
            Console.WriteLine("Пловец проплывет более 5 км на " + count_day + " день");
        }
        static void swimmer_2(double day_tmp,double sum_day,double tmp,int count_day)
        {
            while (sum_day <= 30)
            {
                tmp = day_tmp + (day_tmp * 0.1);
                day_tmp = tmp;
                sum_day += tmp;
                count_day++;
            }
            Console.WriteLine("Пловец проплывёт суммарно более 30 км к " + count_day + " дню");
        }
    }
}
