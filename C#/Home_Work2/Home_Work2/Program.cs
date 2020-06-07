using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Написать игру со следующим сценарием.
В игре 2 участника:
- компьютер
- игрок
У игрока есть некоторая сумма денег  - задается случайным образом в диапазоне от 100 до 500 рублей в начале игры. Компьютер загадывает число в диапазоне от  1 до 100.
Игрок сообщает, за сколько попыток (N) он берется отгадать это число. 
Если игрок угадал число за N или менее попыток, сумма на его счету увеличивается. Увеличение суммы (P) должно быть тем больше, чем меньше число N. 
Если игрок не угадал число за N попыток, сумма на его счету уменьшается. Уменьшение суммы (M) должно быть тем больше, чем больше число N.
Игра завершается, когда игрок выиграет 1000 рублей или когда он все проиграет.

Подумайте, какие зависимости P и М от N надо задать, чтобы в выигрыше в основном был игровой клуб (компьютер).
Для генерирования случайных чисел используйте класс Random.*/

namespace Home_Work2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            int komp_number;
            int number_gamer;
            double gamer;
            double cashGamer;
            int number_of_attempts;
            Random rand = new Random();
            cashGamer = Convert.ToDouble(rand.Next(100, 501));
            gamer = cashGamer;
            komp_number = Convert.ToInt32(rand.Next(1, 101));
            Console.WriteLine("У вас на счету {0:f2} рублей",cashGamer);
            Console.Write("Введите за сколько попыток вы угадаете число :");
            number_of_attempts = Convert.ToInt32(Console.ReadLine());
            int count = 1;
            Console.WriteLine("Вы собираетесь угадать число за {0} попыток, давайте начнём игру ",number_of_attempts);
            while(cashGamer>0&&cashGamer<1000)
            {
                
                Console.Write("Введите число : ");
                number_gamer = Convert.ToInt32(Console.ReadLine());
                if((number_gamer==komp_number)&&cashGamer>0&&cashGamer < 1000)
                {
                    cashGamer += cashGamer/2/count;
                    komp_number = Convert.ToInt32(rand.Next(1, 101));
                    Console.WriteLine($"Вы угадали число с {count} попытки ");
                    Console.WriteLine("Ваш баланс составляет {0:f2} рублей",cashGamer);
                    Console.Write("Введите за сколько попыток вы угадаете число :");
                    number_of_attempts = Convert.ToInt32(Console.ReadLine());
                    count = 1;
                    continue;
                   
                }
                if((count == number_of_attempts)&&cashGamer > 0 && cashGamer < 1000)
                {
                    if (cashGamer < 10)
                        cashGamer -= cashGamer;
                    if (cashGamer <= 0)
                    {
                        Console.WriteLine($"Вы не угадали число с {number_of_attempts} попыток, загаданное число было {komp_number}");
                        Console.WriteLine("Вы проиграли, спасибо за игру !");
                        break;
                    }
                    if(cashGamer>1000)
                    {
                        Console.WriteLine("Вы выиграли. спасибо за игру !");
                        break;
                    }
                    double tmp_cash;
                    if (number_of_attempts >= 10)
                    {
                        tmp_cash = cashGamer / 2 / number_of_attempts;
                        cashGamer -= tmp_cash * count;
                    }
                   if(number_of_attempts<10)
                    {
                        tmp_cash = cashGamer / 2 / number_of_attempts;
                        cashGamer -= tmp_cash;
                    }
                    count = 1;
                    Console.WriteLine($"Вы не угадали число с {number_of_attempts} попыток, загаданное число было {komp_number}");
                    komp_number = Convert.ToInt32(rand.Next(1, 101));
                    Console.WriteLine("Ваш баланс составляет {0:f2} рублей", cashGamer);
                    Console.Write("Введите за сколько попыток вы угадаете число :");
                    number_of_attempts = Convert.ToInt32(Console.ReadLine());
                    continue;
                 
                }
                else
                    count++;
            }
            Console.ReadKey();
        }
    }
}

