using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Создать класс «Окружность», описывающий объекты – окружности на координатной плоскости. Класс должен содержать указанные ниже элементы. 
•	+Закрытые поля для хранения координат центра окружности и радиуса.
•	+Конструктор без параметров для создания окружности с центром в начале координат и единичным радиусом.
•	+Конструктор с параметрами для создания произвольной окружности. Предусмотреть проверку на корректность введенных данных.
•	+Свойства для доступа к полям класса (только для чтения).
•	+Свойства для определения длины окружности.
•	+Метод,   результатом которого является true, если окружность целиком лежит в одной координатной четверти, и false в противном случае.
•	-Метод для перемещения окружности по вертикали вниз или по горизонтали влево (в зависимости от значения соответствующего параметра) на заданную величину.
•	+Метод для увеличения радиуса окружности на заданную величину.
•	+Статический метод для проверки, пересекаются ли две окружности (входные параметры – объекты класса, результат true или false).
*/
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
namespace HomeWork2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle circle_1 = new Circle();
            Circle circle_2 = new Circle();
            Circle circle_3 = new Circle();
            GetCircle(circle_2);
            GetCircle(circle_3);
            up_frame();
            middle_frame(circle_1,1,fouth(circle_1));
            middle_1_frame();
            middle_frame(circle_2,2,fouth(circle_2));
            middle_1_frame();
            middle_frame(circle_3,3,fouth(circle_3));
            down_frame();
            Crossing(circle_1, circle_2, circle_3);
            Console.Write("1 - Перемещение или 2 - увеличение : ");
            int key = Convert.ToInt32(Console.ReadLine());
            if(key==1)
            {
                Console.Write("Выполнить перемещение по вертикали (1) или по горизонтали (2) : ");
                int key_1 = Convert.ToInt32(Console.ReadLine());
                if(key_1==1)
                {
                    Console.Write("Введите величину изменения : ");
                    int move = Convert.ToInt32(Console.ReadLine());
                    circle_1.move(y: move);
                }
                else
                {
                    Console.Write("Введите величину измения : ");
                    int move = Convert.ToInt32(Console.ReadLine());
                    circle_1.move(x: move);
                }
            }
            if(key==2)
            {
                Console.Write("Введите на сколько увеличить радиус : ");
                double rad = Convert.ToDouble(Console.ReadLine());
                circle_1.ChangeRad(rad);
            }
            up_frame();
            middle_frame(circle_1, 1, fouth(circle_1));
            down_frame();
            Console.ReadKey();
        }
        static void GetCircle(Circle circle)
        {
            Console.Write("Введите координату х : ");
            circle.Coordinate_X = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите координату y : ");
            circle.Coordinate_Y = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите радиус окружности : ");
            do
            {
                circle.Radius = Convert.ToDouble(Console.ReadLine());
                if (circle.Radius <= 0) Console.Write("Ошибка ввода, радиус не может быть отрицательным либо равным нулю, введите снова : ");
            } while (circle.Radius <= 0);
        }
        static void up_frame()
        {
            Console.WriteLine("╔════════╦═════════════╦═════════╦═════════╦════════════════════════╗");
            Console.WriteLine("║ № п/п  ║ Центр       ║ Радиус  ║ Длина   ║ Лежит ли в одной       ║");
            Console.WriteLine("║        ║             ║         ║         ║ координатной плоскости ║");
            Console.WriteLine("╠════════╬═════════════╬═════════╬═════════╬════════════════════════╣");
        }
        static void middle_frame(Circle circle,int num,string str)
        {
            Console.WriteLine($"║{num,7} ║{circle,13}║{circle.Radius,9:f2}║{circle.Сircumference,9:f2}║{str,24}║");
           
        }
        static void middle_1_frame()
        {
            Console.WriteLine("║        ║             ║         ║         ║                        ║");
            Console.WriteLine("╠════════╬═════════════╬═════════╬═════════╬════════════════════════╣");
        }
        static void down_frame()
        {
            Console.WriteLine("║        ║             ║         ║         ║                        ║");
            Console.WriteLine("╚════════╩═════════════╩═════════╩═════════╩════════════════════════╝");
        }
        static string fouth(Circle circle)
        {
            if (circle.fourth())
                return ("Да");
            else
                return ("Нет");
        }
        static void Crossing(Circle circle1, Circle circle2, Circle circle3)
        {
            bool flag = false;
            if (Circle.intersectionOfCircles(circle1, circle2))
            {
                Console.WriteLine("Первая окружность пересекается со второй ");
                flag = true;
            }
            if (Circle.intersectionOfCircles(circle1, circle3))
            {
                Console.WriteLine("Первая окружность пересекается с третьей ");
                flag = true;
            }
            if (Circle.intersectionOfCircles(circle2, circle3))
            {
                Console.WriteLine("Вторая окружность пересекается с третьей ");
                flag = true;
            }
            if (!flag)
                Console.WriteLine("Окружности не пересекаются ");
        }
    }
}
