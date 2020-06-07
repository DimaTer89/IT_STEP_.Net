using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HomeWork3_2
{
    class CarCollection
    {
        Car[] car;
        public CarCollection(params Car[] car)
        {
            this.car = car;
        }
        public Car this[int i]
        {
            get
            {
                return car[i];
            }
            set
            {
                car[i] = value;
            }
        }
        public ConsoleColor ConsoleColor(Car car)
        {
            if (car.Color == 1)
                return  System.ConsoleColor.Blue;
            if (car.Color == 2)
                return System.ConsoleColor.Cyan;
            if (car.Color == 3)
                return System.ConsoleColor.DarkBlue;
            if (car.Color == 4)
                return System.ConsoleColor.DarkCyan;
            if (car.Color == 5)
               return System.ConsoleColor.DarkGray;
            if (car.Color == 6)
                return System.ConsoleColor.DarkGreen;
            if (car.Color == 7)
                return System.ConsoleColor.DarkMagenta;
            if (car.Color == 8)
                return System.ConsoleColor.DarkRed;
            if (car.Color == 9)
                return System.ConsoleColor.DarkYellow;
            if (car.Color == 10)
                return System.ConsoleColor.Gray;
            if (car.Color == 11)
                return System.ConsoleColor.Green;
            if (car.Color == 12)
                return System.ConsoleColor.Magenta;
            if (car.Color == 13)
                return System.ConsoleColor.Red;
            if (car.Color == 14)
                return System.ConsoleColor.White;
            else
                return System.ConsoleColor.Yellow;
        }
        public void Race(int rate)
        {
            Random rnd = new Random();
            Random rnd2 = new Random();
            int i;
            int max = 0;
            int race_car = 0;
            int number = 0;
            int l;
            //количество автомобилей
            int[] num_car = new int[car.Length];
            for(i=0;i<num_car.Length;i++)
            {
                num_car[i] = 0;
            }
            //количество строк
            int[] num_str = new int[car.Length * 4];
            for (i = 0; i < num_str.Length; i++)
            {
                num_str[i] = i+2;
            }
            while (max < Console.WindowWidth-5)
            {
                Console.Clear();
                l = 0;
                for (i = 0; i < car.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor(car[i]);
                    car[i].up_Car(num_car[i], num_str[l]);
                    car[i].middle_Car(num_car[i], num_str[l + 1]);
                    car[i].down_Car(num_car[i], num_str[l + 2]);
                    l += 4;
                    Console.ResetColor();
                }
                for (i = 0; i < car.Length; i++)
                {
                    if (car[i].Breaking == true)
                        race_car++;
                }
                if (race_car == car.Length)
                    break;
                for (i = 0; i < car.Length; i++)
                {
                    if (car[i].Breaking == false)
                        num_car[i] += rnd.Next(1, 5);
                }
                for (int j = 0; j < car.Length; j++)
                {
                    if (car[j].Breaking == false)
                        car[j].breaking_car(Console.WindowWidth - 5);
                    try
                    {
                        if (car[j].Breaking == true)
                            throw new Exception();
                    }
                    catch
                    {
                        j++;
                    }
                }
                max = num_car[0];
                for (int k = 0; k < num_car.Length; k++)
                {
                    if (num_car[k] > max)
                    {
                        max = num_car[k];
                        number = k;
                    }
                }
                for (int k = 0; k < num_car.Length; k++)
                {
                    if ((num_car[k] > Console.WindowWidth-5)&&num_car[k]==max)
                        num_car[k] = Console.WindowWidth-5;
                    else if(num_car[k]>115)
                        num_car[k] = Console.WindowWidth-5 - (max - num_car[k]);
                }
                Thread.Sleep(50);
            }
            Console.Clear();
            l = 0;
            Console.WriteLine("Машин в гонке : "+car.Length+ "\tВаша ставка : " + rate);
            for (i = 0; i < car.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor(car[i]);
                car[i].up_Car(num_car[i], num_str[l]);
                car[i].middle_Car(num_car[i], num_str[l + 1]);
                car[i].down_Car(num_car[i], num_str[l + 2]);
                l += 4;
                Console.ResetColor();
            }
            if (race_car == car.Length)
                Console.WriteLine("Все автомобили выбыли из участия, гонка не состоялась ");
            else
                Console.WriteLine("Победитель гонки автомобиль под номером " + car[number].Number);
            if (car[number].Number == rate&&race_car!=car.Length)
                Console.WriteLine("Вы выиграли");
            else if(car[number].Number!=rate&&race_car!=car.Length)
                Console.WriteLine("Вы проиграли");
        }
    }
}
