using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Ввод и вывод трех массивов A, В и С;
  Вычисление общей суммы отрицательных элементов в массивах 5*A и С;
  Вычисление общей суммы отрицательных элементов в массивах 2*В, -А и С*4;
  Если сумма отрицательных элементов в массиве –А больше суммы отрицательных элементов в массиве А, заменить все отрицательные повторяющиеся элементы этого массива на значение этой суммы.
*/
namespace HomeWork5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = new int[] { 1, 5, -6, 9, -8, 7, 4, 5, 9, 11 };
            int[] A1 = new int[] { 1, 5, -6, 9, -8, -7, 4, 5, 9,11 };
            int[] B = new int[] { 1, 6, -9, 8, -7, -5, 6, -11 };
            One_dimensional_Array arr = new One_dimensional_Array(A);
            One_dimensional_Array arr1 = new One_dimensional_Array(B);
            One_dimensional_Array arr2 = "10 5 6 -19 8 -7 24 -5 36 -11 -5";
            One_dimensional_Array arr3 = new One_dimensional_Array(A1);
            arr3 = -arr3;
            Console.WriteLine("Массив A\n" +arr);
            Console.WriteLine("Массив B\n" + arr1);
            Console.WriteLine("Массив C\n" + arr2);
            Console.WriteLine("Массив -A\n"+arr3);
            arr = 5 * arr;
            Console.WriteLine("=====================");
            Console.WriteLine("Массив A\n" + arr);
            Console.WriteLine("Массив B\n" + arr1);
            Console.WriteLine("Массив C\n" + arr2);
            Console.WriteLine("Сумма отрицательных элементов массива 5*А и B: " + One_dimensional_Array.Sum_Negative_Elements(arr, arr1));
            arr1 = 2 * arr1;
            arr2 = arr2 * 4;
            Console.WriteLine("=====================");
            Console.WriteLine("Массив A\n" + arr);
            Console.WriteLine("Массив B\n" + arr1);
            Console.WriteLine("Массив C\n" + arr2);
            Console.WriteLine("Сумма отрицательных элементов массива 2*B,-А и C*4: " + One_dimensional_Array.Sum_Negative_Elements(arr, arr3, arr2));
            Console.WriteLine("=====================");
            Console.WriteLine("Сумма отрицательных элментов массива A : "+One_dimensional_Array.Sum_Negative_Elements(arr)+"\nСумма отрицательных элементова массива -A : "+One_dimensional_Array.Sum_Negative_Elements(arr3));
            if (One_dimensional_Array.Sum_Negative_Elements(arr3) > One_dimensional_Array.Sum_Negative_Elements(arr))
                 Replacement_of_elements(arr3);
            Console.WriteLine("Массив A\n" + arr);
            Console.WriteLine("Массив -A\n" + arr3);
            Console.WriteLine("=====================");
            Console.ReadKey();
        }
        static void Replacement_of_elements(One_dimensional_Array arr)
        {
            int k;
            int temp = One_dimensional_Array.Sum_Negative_Elements(arr);
            bool flag = false;
            int num = arr.Count;
            for(int i=0;i<num;i++)
            {
                if (arr[i] < 0)
                {
                    for(k=i+1;k<num;k++)
                    {
                        if (arr[i] == arr[k])
                        {
                            flag = true;
                            arr[k] = temp;
                        }
                    }
                    if (flag)
                    {
                        arr[i] = temp;
                        flag = false;
                    }
                }
                else
                    continue;
            }
        }
    }
}
