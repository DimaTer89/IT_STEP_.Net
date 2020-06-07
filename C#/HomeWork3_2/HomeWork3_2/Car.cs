using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3_2
{
    class Car
    {
        int color;
        int number;
        bool breaking;
        public Car()
        {
            color = 1;
            number = 0;
            breaking = false;
        }
        public Car(int i, int number,bool flag)
        {
            color = i;
            this.number = number;
            breaking = false;
        }
        public bool Breaking
        {
            get
            {
                return breaking;
            }
            set
            {
                breaking = value;
            }
        }
        public int Number
        {
            get
            {
                return number;
            }
        }
        public int Color
        {
            get
            {
                return color;
            }
        }
        public void up_Car(int i, int str)
        {
            Console.SetCursorPosition(i, str);
            Console.WriteLine("╔╩═╩╗");
        }
        public void middle_Car(int i,int str)
        {
            Console.SetCursorPosition(i, str);
            Console.WriteLine("║ " + number + " ╠");
        }
        public void down_Car(int i,int str)
        {
            Console.SetCursorPosition(i, str);
            Console.WriteLine("╚╦═╦╝");
        }
        public void breaking_car(int way)
        {
            int countWay = way * 20;
            int countProc = 1;
            Random randomNumber = new Random();
            int[] numberBreak = new int[countProc];
            for (int i = 0, r = 0; i < countProc; i++)
            {
                if (i != 0)
                {
                    r = randomNumber.Next(1, countWay);
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (r == numberBreak[j])
                        {
                            r = randomNumber.Next(1, countWay);
                            j = i;
                        }
                    }
                    numberBreak[i] = r;
                }
                else
                    numberBreak[i] = randomNumber.Next(1, countWay);
            }
            int rand = randomNumber.Next(1, countWay);
            for (int i = 0; i < countProc; i++)
            {
                if (numberBreak[i] == rand)
                {
                    breaking = true;
                }
            }
        }
    }
}
