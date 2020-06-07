using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 38;
            try
            {
                int key;
                bool flag = true;
                int[] math1 = { 6, 8, 7, 4, 8, 9, 6 };
                int[] physics1 = { 6, 8, 7, 4, 8, 9, 6 };
                int[] history1 = { 6, 3, 8, 7, 4, 8, 9, 6 };
                int[] math2 = {  8, 7, 10, 8, 9, 6 };
                int[] physics2 = {  9, 8, 7, 8, 9 };
                int[] history2 = { 6, 8, 7, 8, 9, 6 };
                int[] math3 = { 8, 7, 10, 8, 9, 5 };
                int[] physics3 = { 6, 8, 7, 8, 9 };
                int[] history3 = { 6, 7, 8, 3, 6 };
                Human[] human =
                {
                    new Human("Сидоров",1984,"Преподаватель"),
                    new Human("Петров", 1995, "Слесарь"),
                    new Human("Иванов", 1987, "Бизнесмен"),
                    new Student("Лосев", 1997, "Cтудент", math1, physics1, history1),
                    new Human("Баталин",1981,"Преподаватель"),
                    new Student("Петров", 1998, "Студент",math2,physics2,history2),
                    new Human("Ющенко", 1985, "БизнесВумен"),
                    new Student("Кошелева", 2000, "Cтудент", math3, physics3, history3)
                };
                PrintHuman(human);
                do
                {
                    Console.Clear();
                    Console.WriteLine("1 - Сортировать по возрасту");
                    Console.WriteLine("2 - Сортировать по алфавиту");
                    Console.WriteLine("3 - Выход");
                    Console.Write("Ваш выбор : ");
                    key = Convert.ToInt32(Console.ReadLine());
                    switch (key)
                    {
                        case 1:
                            Array.Sort(human);
                            PrintHuman(human);
                            break;
                        case 2:
                            Array.Sort(human, new ClassSortByAlfavit());
                            PrintHuman(human);
                            break;
                        case 3:
                            flag = false;
                            Console.WriteLine("До свидания!");
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("Неверный ввод, внимательнее читайте меню!");
                            Console.ReadKey();
                            break;
                    }
                } while (flag);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void PrintHuman(Human[] human)
        {
            Tablica();
            foreach (Human item in human)
            {
                Console.WriteLine(item);
            }
            DownTablica();
            Console.WriteLine("Нажмите любую клавишу для продолжения ...");
            Console.ReadKey();
        }
        static void Tablica()
        {
            Console.WriteLine("╔═════════════════╦══════════════════════╦══════════════════╦═════════════════════════════════════════╗");
            Console.WriteLine("║       Фамилия   ║        Возраст       ║      Статус      ║        Дополнительная информация        ║");
            Console.WriteLine("║                 ║                      ║                  ║           (только для студентов)        ║");
        }
        static void DownTablica()
        {
            Console.WriteLine("╚═════════════════╩══════════════════════╩══════════════════╩═════════════════════════════════════════╝");
        }
    }
}
