using Exam.Sportsmans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.IO;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            const int exitMenu = 7;
            int key;
            string[] menu =
            {
                "Вывод информации на экран",
                "Сортировка информации по убыванию возраста",
                "Сериализация коллекции в двоичном формате",
                "Вывод информации  о пловцах моложе 20 лет с указанием среднего результата в 1 - м, 2 - м и 5 - м заплывах",
                "Сравнение двух указанных гимнастов по результатам",
                "Сериализация информации о гимнастах в формате XML",
                "Вывод на экран фамилии слушателя, текущую дату и время",
                "Выход"
            };
            Menu myMenu = new Menu(menu);
            List<Sportsman> list = new List<Sportsman>();
            list = ReadFile();
            SportsmanCollection<Sportsman> sportsman = new SportsmanCollection<Sportsman>(list);
            do
            {
                key = myMenu.ShowMenu();
                switch(key)
                {
                    case 0:
                        BaseColor();
                        Console.SetCursorPosition(0, menu.Length);
                        Tablica();
                        sportsman.ShowSportsMans();
                        Down_Tablica();
                        Console.WriteLine("Для продолжения нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                    case 1:
                        BaseColor();
                        Console.SetCursorPosition(0, menu.Length);
                        sportsman.Sort(new SortSportsMans());
                        Tablica();
                        sportsman.ShowSportsMans();
                        Down_Tablica();
                        Console.WriteLine("Для продолжения нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                    case 2:
                        BaseColor();
                        Console.SetCursorPosition(0, menu.Length);
                        sportsman.Serialization(new BinaryFormatter());
                        Console.WriteLine("Для продолжения нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                    case 3:
                        BaseColor();
                        Console.SetCursorPosition(0, menu.Length);
                        SportsmanCollection<Sportsman> temp = sportsman.Find((match => match.Age < 20 && match.KindOfSport == "плавание"));
                        Console.WriteLine("╔═══════════════╦═════════════╦═════════════════════════╗");
                        Console.WriteLine("║    Фамилия    ║   Возраст   ║Среднее за 1,2,5 заплывы ║");
                        foreach (var item in temp.SportsMens)
                        {
                            Console.WriteLine($"╠═══════════════╬═════════════╬═════════════════════════╣\n║{item.Surname,15}║{item.Age,13}║{((Swimmer)item).AverageResult(1,2,5),6:f2}{" сек."}{" ",14}║");
                        }
                        Console.WriteLine("╚═══════════════╩═════════════╩═════════════════════════╝");
                        Console.WriteLine("Для продолжения нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                    case 4:
                        BaseColor();
                        Console.SetCursorPosition(0, menu.Length);
                        Console.WriteLine("Сравнение двух гимнастов : Учимура и Щербо");
                        if ((Gymnast)sportsman.SportsMens.Find(match => match.Surname == "Учимура") > (Gymnast)sportsman.SportsMens.Find(match => match.Surname == "Щербо"))
                            Console.WriteLine("Учимура как гимнаст лучше Щербо");
                        else if ((Gymnast)sportsman.SportsMens.Find(match => match.Surname == "Учимура") < (Gymnast)sportsman.SportsMens.Find(match => match.Surname == "Щербо"))
                            Console.WriteLine("Щербо как гимнаст лучше Учимуры");
                        else
                            Console.WriteLine("Два гимнаста не лучше и не хуже друг друга");
                        Console.WriteLine("Для продолжения нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                    case 5:
                        BaseColor();
                        Console.SetCursorPosition(0, menu.Length);
                        sportsman.Serialization(new XmlSerializer(typeof(List<Sportsman>), new Type[] { typeof(List<Gymnast>), typeof(List<Swimmer>) }));
                        Console.WriteLine("Для продолжения нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                    case 6:
                        BaseColor();
                        Console.SetCursorPosition(0, menu.Length);
                        Console.WriteLine("Слушатель : Терещенко Д.А.\n"+"Текущая дата : "+DateTime.Now.ToLongDateString()+"\nТекущее время : "+DateTime.Now.ToLongTimeString());
                        Console.WriteLine("Для продолжения нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                    case 7:
                        BaseColor();
                        Console.SetCursorPosition(0, menu.Length);
                        Console.WriteLine("До Свидания");
                        Console.ReadKey();
                        break;
                }
            } while (key != exitMenu);
        }
        static void BaseColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void Tablica()
        {
            Console.WriteLine("╔═══════════════╦═════════════╦════════════════════╦══════════════════════╗");
            Console.WriteLine("║    Фамилия    ║   Возраст   ║     Вид спорта     ║    Лучший результат  ║");
        }
        static void Down_Tablica()
        {
            Console.WriteLine("╚═══════════════╩═════════════╩════════════════════╩══════════════════════╝");
        }
        static List<Sportsman> ReadFile()
        {
            List<Sportsman> temp = new List<Sportsman>();
            string[] data;
            string[] heats;
            using (StreamReader reader = new StreamReader("sportsmans.txt",Encoding.Default))
            {
                while (!reader.EndOfStream)
                {
                    data = reader.ReadLine().Split(';');
                    if(data[2]=="гимнастика")
                    {
                        try
                        {
                           temp.Add(new Gymnast(data[0], int.Parse(data[1]), data[2], double.Parse(data[3]), double.Parse(data[4]), double.Parse(data[5])));
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadKey();
                        }
                    }
                    if(data[2]=="плавание")
                    {
                        heats = data[3].Split(' ');
                        try
                        {
                            double[] gradeHeats = new double[heats.Length];
                            for(int i=0;i<heats.Length;i++)
                            {
                                gradeHeats[i] = double.Parse(heats[i]);
                            }
                            temp.Add(new Swimmer(data[0], int.Parse(data[1]), data[2], gradeHeats));
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadKey();
                        }
                    }
                       
                }
            }
            return temp;
        }
    }
}
