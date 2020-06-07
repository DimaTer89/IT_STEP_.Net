using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Написать приложение «Автомобильные гонки».  В гонке участвует от 2 до 7 автомобилей (количество задается пользователем перед началом каждой гонки). 
 * Автомобили двигаются по экрану консоли от левого края к правому с переменной скоростью. Победителем гонки считается автомобиль, который первым достиг правого края консоли. 
 * Автомобили отображать в консоли с помощью символов псевдографики. Для решения задачи необходимо
реализовать класс «Автомобиль», который имеет цвет (красный, синий и т.д. – назначается автомобилю случайным образом в конструкторе), номер (1, 2, и т.д. – задается программой).
Предусмотреть возможность поломки автомобиля во время гонок – вероятность поломки – 5%. 
В случае поломки объект «Автомобиль» генерирует исключительную ситуацию, которая должна быть обработана в программе – поломанный автомобиль перестает двигаться,
но остается на экране (отображается на экране как поломанный), и выбывает из гонок. Пользователь перед началом гонок может сделать ставку на один из автомобилей.
В случае, если побеждает автомобиль пользователя – программа сообщает «Вы выиграли», иначе – «Вы проиграли».
Программа должна иметь меню, предлагающее пользователю сделать ставку и начать новую гонку или выйти из программы.
*/
namespace HomeWork3_2
{
    class Program
    {

        static void Main(string[] args)
        {
            int racer;
            int rate;
            Car[] car;
            Console.WindowHeight = 33;
            CarCollection carCollection;
            ConsoleKeyInfo cki;
            Random random = new Random();
            do
            {
                Console.Clear();
                Console.Write("Добро пожаловать в гонки, введите количество машин для участия( от 2 до 7 ) : ");
                racer = test();
                car = new Car[racer];
                int kol = 0;
                for (int i = 0; i < car.Length; i++)
                {
                    car[i] = new Car(random.Next(1, 15),++kol , false);
                }
                carCollection = new CarCollection(car);
                Console.Write("На какой автомобиль сделаете ставку от 1 до " + car.Length + " : ");
                rate = Rate(car);
                carCollection.Race(rate);
                Console.Write("Чтобы сделать ставку и сыграть заново, нажмите Y , чтобы выйти из приложения нажмите N : ");
                cki = Console.ReadKey();
                Console.WriteLine();
            } while (cki.KeyChar == 'y' || cki.KeyChar == 'Y');
            if(cki.KeyChar=='n'||cki.KeyChar=='N')
            {
                Console.WriteLine("До свидания, спасибо за игру");
                Console.ReadKey();
            }
        }
        static int Rate(Car[] car)
        {
            int rate;
            bool flag = false;
            do
            {
                if (!int.TryParse(Console.ReadLine(), out rate))
                    Console.Write("Неправильный символ, повторите ввод : ");
                else if (rate < 0 || rate > car.Length)
                    Console.Write("Неверное число, такого количества машин не существует, повторите ввод : ");
                else
                    flag = true;
            } while (!flag);
            return rate;

        }
        static int test()
        {
            int num;
            bool flag = false;
            do
            {
                if (!int.TryParse(Console.ReadLine(), out num))
                    Console.Write("Неверное число, повторите ввод : ");
                else if (num < 2 || num > 7)
                    Console.Write("Внимательно читайте условие, повторите ввод : ");
                else
                    flag = true;
            } while (!flag);
            return num;
        }
    }
}
