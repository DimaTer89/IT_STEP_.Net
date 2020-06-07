using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Написать приложение, выполняющее следующие функции:
	Ввод с клавиатуры данных  о студентах в массив объектов класса Student.
	Вывод списка всех студентов с указанием среднего балла каждого студента в порядке возрастания среднего балла.
	Определение количества студентов, получивших больше двух оценок 10 в массиве.
	Вывод списка двоечников в заданной группе (если таких студентов нет, вывести соответствующее сообщение).
*/
namespace HomeWork3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            int[] arr;
            int kol;
            int count=0;
            string name,group;
            int key;
            StudentCollection studentCollection;
            Student[] student;
            Console.WriteLine("Введите данные о студентах.");
            Console.Write("Количество студентов (минимум двух) : ");
            kol = test();
            student = new Student[kol];
            for (int i = 0; i < kol; i++)
            {
                Input(out name, out group, out arr,count);
                student[i] = new Student(name, group, arr);
            }
            studentCollection = new StudentCollection(student);
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Вывести список студентов с указанием среднего балла в порядке возрастания.");
                Console.WriteLine("2 - Определить количество студентов, получивших больше двух оценок 10 в массиве.");
                Console.WriteLine("3 - Вывод списка двоечников.");
                Console.WriteLine("4 - Выход.");
                Console.Write("Ваш выбор : ");
                key = Convert.ToInt32(Console.ReadLine());
                switch(key)
                {
                    case 1:
                        studentCollection.Sort();
                        for(int i=0;i<studentCollection.Count;i++)
                        {
                            studentCollection[i].ShowStudent();
                        }
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Студентов получивших больше двух оценок 10 = "+studentCollection.More_10);
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Список двоечников");
                        studentCollection.Losers_list();
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("До свидания, спасибо, что воспользовались моим приложением.");
                        break;
                    default:
                        Console.WriteLine("Данный номер отсутствует в меню выбора ");
                        break;
                }                
            } while (key!=4);
            Console.ReadKey();
        }
        static void Input(out string name,out string group,out int[]arr,int count)
        {
            Console.Write("Введите фамилию : ");
            name = Convert.ToString(Console.ReadLine());
            Console.Write("Введите номер группы : ");
            group = Convert.ToString(Console.ReadLine());
            Console.Write("Введите количество оценок : ");
            count = test();
            Console.WriteLine("Введите оценки (от 2 до 10)");
            arr = new int[count];
            for(int i=0;i<arr.Length;i++)
            {
                Console.Write((i + 1) + " оценка : ");
                arr[i] =test();
            }
        }
        static int test()
        {
            int num;
            bool flag = false;
            do
            {
                if (!int.TryParse(Console.ReadLine(), out num))
                    Console.Write("Ошибка неправильное число, повторите ввод : ");
                else if (num <= 0)
                {
                    Console.Write("В данном контексте введённое вами число не должо быть отрицательным либо равным нулю, повторите ввод : ");
                    continue;
                }
                else if (num < 2 || num > 10)
                    Console.Write("Значение недопустимо, повторите ввод : ");
                else
                    flag = true;

            } while (!flag);
            return num;
        }
    }
}
