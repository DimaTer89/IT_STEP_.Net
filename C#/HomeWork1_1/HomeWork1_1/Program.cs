﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1_1
{
    class Program
    {
        // ╚ 200
        // ╔ 201
        // ╩ 202
        // ╦ 203
        // ╠ 204
        // ═ 205
        // ╬ 206
        // ╝ 188
        // ║ 186
        // ╗ 187
        // ╣ 185
        static void Main(string[] args)
        {
            double xB;
            double xE;
            double step;
            double rez;
            do
            {
                xB = InputDouble(" начальное значение аргумента : ");
                xE = InputDouble(" конечное значение аргумента : ");
                step = InputDouble(" шаг измения хода : ");
                if (xB >= xE) Console.WriteLine("Начальное значение аргумента не должно превышать либо быть равному конечному");
                if (step <= 0) Console.WriteLine("Шаг измения хода не должен быть меньше либо равен нулю ");
            } while (xB >= xE||step<=0);
            Console.WriteLine("╔════════╦═════════╗");
            Console.WriteLine("║  x     ║   f(x)  ║");
            Console.WriteLine("╠════════╬═════════╣");
            while (xB <= xE)
            {
                if (xB < 0)
                {
                    rez = xB * xB;
                    Console.WriteLine($"║{xB,8:f2}║{rez,9:f3}║");
                }
                else
                {
                    Console.WriteLine($"║{xB,8:f2}║{xB,9:f3}║");
                }
                xB += step;
            }
            Console.WriteLine("╚══════════════════╝");
            Console.ReadKey();
        }
        static double InputDouble(string str)
        {
            Console.Write("Введите " + str);
            return Double.Parse(Console.ReadLine());
        }
    }
}
