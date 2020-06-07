using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Создать класс «Таблица», описывающий объекты-таблицы из двух столбцов, содержащий следующие элементы:
­	+Закрытые поля: заголовок таблицы, заголовки столбцов, ширина первого столбца, ширина второго столбца.
­	+Конструктор с параметрами. 
­	+Метод для вывода шапки таблицы.
­	+Метод для вывода строки таблицы (входные параметры – числовые значения, которые выводятся в строке  таблицы).
­	+Метод для вывода низа таблицы.
*/
namespace HomeWork2_2
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
    class Tablica
    {
        string nameTablica;
        string nameCol1;
        string nameCOl2;
        int widthFirstCol;
        int widthSecondCol;
        public Tablica(string nameC1,string nameC2,int width1=20,int width2=20, string name= "f(x)=1+cos^2(x+a)/|x^3-2*b^2|")
        {
            nameTablica = name;
            nameCol1 = nameC1;
            nameCOl2 = nameC2;
            widthFirstCol = width1;
            widthSecondCol = width2;
        }
        public void up_frame()
        {
            Console.Write("╔");
            int len = nameTablica.Length;
            if ((widthFirstCol + widthSecondCol) < len)
            {
                widthFirstCol = len / 2;
                widthSecondCol = len - widthFirstCol;
            }
            else
                len = widthFirstCol + widthSecondCol;
            for(int i=0;i<len;i++)
            {
                Console.Write("═");
            }
            Console.WriteLine("╗");
            Console.Write("║");
            for (int i=0;i<len;i++)
            {
                if (i == 7)
                {
                    Console.Write(nameTablica);
                    int len1 = nameTablica.Length;
                    i = len1 + 7;
                }
                Console.Write(" ");
            }
            Console.WriteLine("║");
            Console.Write("╠");
            for(int i=0;i<widthFirstCol+widthSecondCol;i++)
            {
                if (i == ((widthFirstCol + widthSecondCol) / 2))
                    Console.Write("╦");
                else
                    Console.Write("═");
            }
            Console.WriteLine("╣");
            Console.Write("║");
            for(int i=0;i<widthFirstCol;i++)
            {
                Console.Write(" ");
                if (i == widthFirstCol / 2-2)
                {
                    Console.Write("x");
                    i++;
                }
            }
            Console.Write("║");
            for(int i=0;i<widthSecondCol;i++)
            {
                Console.Write(" ");
                if (i == widthSecondCol / 2-3)
                {
                    Console.Write("f(x)");
                    i += 5;
                }
            }
            Console.WriteLine("║");
            
        }
        public void middle_frame(Function function,double xB,double rez)
        {
            Console.Write("╠");
            for (int i = 0; i < widthFirstCol + widthSecondCol; i++)
            {
                if (i == ((widthFirstCol + widthSecondCol) / 2))
                    Console.Write("╬");
                else
                    Console.Write("═");
            }
            Console.WriteLine("╣");
            Console.Write("║");
            for(int i=0;i<widthFirstCol;i++)
            {
                if (i == (widthFirstCol / 2 - 1))
                {
                    Console.Write($"{xB:f2}");
                    if (xB <= -10)
                    {
                        i += 5;
                        continue;
                    }
                    if (xB < 0)
                    {
                        i += 4;
                        continue;
                    }
                    if (xB >= 0&&xB<0)
                    {
                        i += 3;
                        continue;
                    }
                    if (xB >= 10 )
                    {
                        i += 4;
                        continue;
                    }
                    else
                        i += 4;
                } 
                Console.Write(" ");
            }
            Console.Write("║");
            string tmp = Convert.ToString(rez);
           for(int i=0;i<widthSecondCol;i++)
           {
                if (i == 0)
                {
                    Console.Write("{0:f10}", rez);
                    string str = Convert.ToString(rez);
                    int len = str.Length;
                    i=test(len, rez);
                }
               Console.Write(" ");
           }
           
           Console.WriteLine("║");
        }
        static int test(int len,double rez)
        {
            if (len > 1 && rez < 10)
                return 13;
            else if (len > 1 && rez >= 10 && rez < 100)
                return 14;
            else if (len > 1 && rez >= 100 && rez < 1000)
                return 15;
            else if (len > 1 && rez >= 1000 && rez < 10000)
                return 16;
            else if (len > 1 && rez >= 10000)
                return 17;
            else
                return len+1;
        }
        public void down_frame()
        {
            Console.Write("╚");
            for (int i = 0; i < widthFirstCol + widthSecondCol; i++)
            {
                if (i == ((widthFirstCol + widthSecondCol) / 2))
                    Console.Write("╩");
                else
                    Console.Write("═");
            }
            Console.WriteLine("╝");
        }
    }
}
