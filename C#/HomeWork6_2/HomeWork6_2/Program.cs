using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*В классе Program создать объект класса-контейнера с информацией о двух кругах и двух квадратах. 
 * Вывести информацию о фигурах, используя для просмотра содержимого контейнера оператор foreach.
 * Сортировать информацию по типу. Сортировать информацию по площадям фигур.*/
namespace HomeWork6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IGeometricFigures[] geometricFigures =
            {
                new Square(5.6),
                new Circle(5.4,"белый"),
                new Circle(9.4,"серый"),
                new Square(10.2)
            };
                int key;
                bool flag = true;
                FigureCollections collections = new FigureCollections(geometricFigures);
                DataPrinting(collections);
                Console.WriteLine("Нажмите любую клавишу для продолжения");
                Console.ReadKey();
                do
                {
                    Console.Clear();
                    Console.WriteLine("1 - Сортировать по площади");
                    Console.WriteLine("2 - Сортировать по типу");
                    Console.WriteLine("3 - Выход");
                    Console.Write("Ваш выбор : ");
                    key = Convert.ToInt32(Console.ReadLine());
                    switch(key)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Коллекция отсортирована по полощади");
                            collections.SortBySquare();
                            DataPrinting(collections);
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Коллекция отсортирована по типу");
                            collections.SortByType();
                            DataPrinting(collections);
                            Console.ReadKey();
                            break;
                        case 3:
                            flag = false;
                            Console.WriteLine("До свидания!!!");
                            break;
                        default:
                            Console.WriteLine("Ошибка выбора меню, повторите ввод");
                            Console.ReadKey();
                            break;
                    }
                } while (flag);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
        static void Tablica()
        {
            Console.WriteLine("╔══════════════╦════════════════════╦═══════════════════════════╗");
            Console.WriteLine("║  Вид фигуры  ║      Площадь       ║ Дополнительная информация ║");
        }
        static void DownTablica()
        {
            Console.WriteLine("╚══════════════╩════════════════════╩═══════════════════════════╝");
        }
        static void DataPrinting(FigureCollections figure)
        {
            Tablica();
            foreach (object item in figure)
            {
                ((IGeometricFigures)item).Print();
            }
            DownTablica();
        }
    }
}
