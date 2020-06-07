﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class Menu
    {
        string[] menu;
        const int stand = 0;
        int current;
        int last;
        public Menu(string[] menu)
        {
            this.menu = menu;
            current = 0;
            last = 0;
        }
        void MenuList(int position, string nameSick)
        {
            Console.SetCursorPosition(stand, position);
            Console.WriteLine(nameSick);
        }
        public int ShowMenu()
        {
            ConsoleKeyInfo key;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.CursorVisible = false;
            for (int i = 0; i < menu.Length; i++)
            {
                MenuList(i, menu[i]);
            }
            bool IsNoEnter = true;
            while (IsNoEnter)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                MenuList(last, menu[last]);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                MenuList(current, menu[current]);
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
            return current;
        }
    }
}
