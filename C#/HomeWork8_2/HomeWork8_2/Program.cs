using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Написать  статический метод, выполняющий указанное действие над элементами матрицы целых чисел.  Параметры:  матрица целых чисел, заданное действие – объект  стандартного делегата Action.
Используя написанный метод:
•	вывести матрицу на экран;
•	вывести на экран положительные элементы матрицы;
*/
namespace HomeWork8_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int> action = delegate (int num)
            {
                Console.Write($"{num,5}");
            };
            int[,] matrix =
            {
                {4,-9,4,-2,3,-5,4 },
                {1,2,3,6,12,-1,6 },
                {4,9,-4,2,3,5,-4 },
                {1,9,2,10,3,-15,4 },
                {41,-19,4,-52,73,15,94 },
                {40,-9,-41,21,3,-54,-40 },
                {4,-91,4,-21,3,-57,-4 },
            };
            bool flag = true;
            Console.WriteLine("Исходная матрица");
            ShowMatrix(matrix, action,flag);
            Console.WriteLine("Положительные элементы матрицы ");
            ShowMatrix(matrix,action,flag=false);
            Console.ReadKey();
        }
        static void ShowMatrix(int[,]matrix,Action<int> action,bool flag)
        {
            for(int i=0;i<matrix.GetLength(0);i++)
            {
                for(int j=0;j<matrix.GetLength(1);j++)
                {
                    if (flag)
                        action(matrix[i, j]);
                    else
                        if (matrix[i, j] > 0)
                        action(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
