using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7_5
{
    class Menu
    {
        string[] menu;
        CaseReport[] patients;
        const int stand = 0;
        int current;
        int last;
        public Menu(string[] menu,CaseReport[] patients)
        {
            this.menu = menu;
            this.patients = patients;
            current = 0;
            last = 0;
        }
        void down_Tablica(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.End)
                Console.WriteLine("╚═══╩════════════════╩═══════════════════════╩════════════════╝");
            if (key.Key == ConsoleKey.Home)
                Console.WriteLine("╚═══╩════════════════╩═══════════╝");
            if (key.Key == ConsoleKey.Insert)
                Console.WriteLine("╚═══╩════════════════╩════════════════════╩═════════╝");
        }
        bool Disease(string sick)
        {
            bool flag = false;
            for (int i = 0; i < patients.Length; i++)
            {
                if (patients[i].bolezn.ToString() == sick)
                    flag = true;
            }
            return flag;
        }
        void Patientlist(string sick, ConsoleKeyInfo key)
        {
            if (Disease(sick))
            {
                int j = 0;
                Tablica(key);
                for (int i = 0; i < patients.Length; i++)
                {
                    if (patients[i].bolezn.ToString() == sick)
                    {
                        patients[i].Show(j + 1, key);
                        j++;
                    }
                }
                down_Tablica(key);
            }
            else
               Console.WriteLine("Пациенты с таким диазнозом не зарегестрированы");
        }
        void Tablica(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.End)
            {
                Console.WriteLine("╔═══╦════════════════╦═══════════════════════╦════════════════╗");
                Console.WriteLine("║ № ║    Фамилия     ║    Дата поступления   ║  Дата рождения ║");
            }
            if (key.Key == ConsoleKey.Home)
            {
                Console.WriteLine("╔═══╦════════════════╦═══════════╗");
                Console.WriteLine("║ № ║    Фамилия     ║  Возраст  ║");
            }
            if (key.Key == ConsoleKey.Insert)
            {
                Console.WriteLine("╔═══╦════════════════╦════════════════════╦═════════╗");
                Console.WriteLine("║ № ║    Фамилия     ║ Продолжительность  ║ Возраст ║");
                Console.WriteLine("║   ║                ║ пребывания в       ║         ║");
                Console.WriteLine("║   ║                ║ больнице           ║         ║");
            }
        }
        void ListOfDiseases(int position,string nameSick)
        {
            Console.SetCursorPosition(stand,position);
            Console.WriteLine(nameSick);
        }
        public void ShowMenu()
        {
            ConsoleKeyInfo keyInfo;
            ConsoleKeyInfo key;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("Home - Вывод таблицы в виде (фамилия и возраст)");
                Console.WriteLine("End - Вывод таблицы в виде (фамилия, дата поступления, год рождения)");
                Console.WriteLine("Insert - Вывод таблицы в виде (фамилия, дней в больницу, возраст)");
                Console.WriteLine("Escape - Выход");
                Console.WriteLine("Данные в каждой таблице отсортированы по количеству дней в больнице");
                Console.WriteLine("Ваш выбор : ");
                keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Escape)
                    break;
                bool isRun = true;
                while (isRun)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    Console.CursorVisible = false;
                    for (int i = 0; i < menu.Length; i++)
                    {
                        ListOfDiseases(i, menu[i]);
                    }
                    bool IsNoEnter = true;
                    while (IsNoEnter)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        ListOfDiseases(last, menu[last]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Red;
                        ListOfDiseases(current, menu[current]);
                        key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Enter)
                            IsNoEnter = false;
                        else
                        if (key.Key == ConsoleKey.DownArrow)
                        {
                            last = current;
                            current = (current == menu.Length - 1) ? 0 : current + 1;
                        }
                        else
                        if (key.Key == ConsoleKey.UpArrow)
                        {
                            last = current;
                            current = (current == 0) ? menu.Length - 1 : current - 1;
                        }
                    }
                    switch (current)
                    {
                        case 0:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(stand,menu.Length);
                            Patientlist(menu[0], keyInfo);
                            Console.WriteLine("Нажмите любую клавишу для продолжения ...");
                            Console.ReadKey();
                            break;
                        case 1:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(stand, menu.Length);
                            Patientlist(menu[1], keyInfo);
                            Console.WriteLine("Нажмите любую клавишу для продолжения ...");
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(stand, menu.Length);
                            Patientlist(menu[2], keyInfo);
                            Console.WriteLine("Нажмите любую клавишу для продолжения ...");
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(stand, menu.Length);
                            Patientlist(menu[3], keyInfo);
                            Console.WriteLine("Нажмите любую клавишу для продолжения ...");
                            Console.ReadKey();
                            break;
                        case 4:
                            isRun = false;
                            break;
                    }
                }
            } while (true);
            Console.Clear();
            Console.WriteLine("До свидания, больше не болейте");
        }
    }
}
