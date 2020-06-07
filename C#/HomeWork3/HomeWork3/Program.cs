using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Если в квадратной матрице A сумма элементов столбцов, состоящих из положительных элементов, больше чем такая же сумма в квадратной матрице В,
 заменить все нулевые элементы матрицы В на значение суммы элементов диагоналей этой матрицы. 
 В противном случае определить сумму элементов диагоналей матрицы А.
 При создании объектов класса матрицы-аргументы конструктора создавать с использованием синтаксиса инициализаторов. С клавиатуры не вводить.
 */
namespace HomeWork3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 35;
            int[,] arr = new int[,]
                {
                    {4,5,2,-8 },
                    {0,1,0,8 },
                    {4,5,-9,0 },
                    {4,5,4,9 },
                };
            int[,] arr1 = new int[,]
            {
                {12,3,6,8,5 },
                {-11,5,-3,6,8 },
                {6,-9,8,4,-1 },
                {5,9,8,4,1},
                {1,9,1,23,37 },
            };
            int[,] arr2 = new int[,]
               {
                    {4,5,2,-4 },
                    {0,1,0,8 },
                    {4,5,-7,0 },
                    {4,5,4,9 },
               };
            int[,] arr3 = new int[,]
            {
                {2,3,6,8,5 },
                {-1,5,-3,6,4 },
                {6,-9,8,4,1 },
                {5,9,8,4,1},
                {1,9,1,2,3 },
            };
            Matrix A = new Matrix(arr1,arr1.Length);
            Matrix B = new Matrix(arr,arr.Length);
            Matrix A1 = new Matrix(arr2, arr2.Length);
            Matrix B1 = new Matrix(arr3, arr3.Length);
            Console.WriteLine("Демонстация программы, когда сумма элементов положительных столбцов матрицы А больше матрицы B");
            Pokaz(A, B);
            Console.WriteLine("Нажмите Enter");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Теперь наоборот ");
            Pokaz(A1, B1);
            Console.ReadKey();
        }
        static void Pokaz(Matrix a,Matrix b)
        {
            Console.WriteLine("Матрица A \n" + a);
            Console.WriteLine("Матрица B \n" + b);
            Console.WriteLine();
            Console.WriteLine("Сумма элементов положительных столбцов матрицы A : " + a.Sum_Positive_Col());
            Console.WriteLine("Сумма элементов положительных столбцов матрицы B : " + b.Sum_Positive_Col());
            Console.WriteLine();
            if (a.Sum_Positive_Col() > b.Sum_Positive_Col())
            {
                int sumDiag = b.Sum_of_diagonals;
                Console.WriteLine("Сумма диагоналей матрицы B : " + sumDiag);
                for (int i = 0; i < b.GetLenth(); i++)
                {
                    for (int j = 0; j < b.GetLenth(); j++)
                    {
                        if (b[i, j] == 0)
                            b[i, j] = sumDiag;
                    }
                }
                Console.WriteLine("Матрица A \n" + a);
                Console.WriteLine("Матрица B \n" + b);
            }
            else
            {
                Console.WriteLine("Сумма диагоналей матрицы A : " + a.Sum_of_diagonals);
                Console.WriteLine("Матрица A \n" + a);
                Console.WriteLine("Матрица B \n" + b);
            }
        }
    }
}
