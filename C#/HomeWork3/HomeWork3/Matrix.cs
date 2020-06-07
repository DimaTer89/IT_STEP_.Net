using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Для решения задачи создать класс Matrix, содержащий 
  + закрытое поле-массив для хранения данных, 
  + конструктор без параметров для создания единичной матрицы 3×3, 
  + конструктор с параметрами (параметр – матрица целых чисел),
  - метод  ToString(), возвращающий строковое представление  матрицы, 
  + индексатор для доступа к элементам поля-массива, 
  + метод GetLenth – аналог одноименного метода из Array,
  + закрытый (private) метод, возвращающий true, если столбец состоит из положительных элементов (параметр – номер столбца),
  + метод, возвращающий сумму элементов столбцов, состоящих из положительных элементов,
  + свойство, возвращающее сумму элементов диагоналей матрицы.
*/
namespace HomeWork3
{
    class Matrix
    {
        int[,] arr;
        int size;
        public Matrix()
        {
            size = 9;
            arr = new int[3, 3];
            for(int i=0;i<GetLenth();i++)
            {
                for(int j=0;j<GetLenth();j++)
                {
                    if (j == i)
                        arr[i, j] = 1;
                    else
                        arr[i, j] = 0;
                }
            }
            
        }
        public int GetLenth()
        {
            return ((int)Math.Sqrt(size));
        }
        public Matrix(int[,] arr,int size)
        {
            this.size = size;
            this.arr = arr;
            
        }
        public int this[int i,int j]
        {
            get
            {
                return arr[i, j];
            }
            set
            {
                arr[i, j] = value;
            }
        }
        private bool positive_elements(int col)
        {
            for (int i = 0; i < GetLenth(); i++)
            {
                if (arr[i, col] < 0)
                    return false;
            }
            return true;
        }
        public int Sum_of_diagonals
        {
            get
            {
                int sum = 0;
                int num = GetLenth();
                for (int i = 0; i < GetLenth(); i++)
                {
                    sum += arr[i, i];
                    sum += arr[i,(num - 1 - i)];
                }
                return sum;
            }
        }
        public int Sum_Positive_Col()
        {
            int sum = 0;
            for(int i=0;i<GetLenth();i++)
            {
                for(int j=0;j<GetLenth();j++)
                {
                    if(positive_elements(j))
                        sum+=arr[i,j];
                }
            }
            return sum;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < GetLenth(); i++)
            {
                for (int j = 0; j < GetLenth(); j++)
                {
                    sb.Append($"{arr[i, j],4} ");
                }

                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
