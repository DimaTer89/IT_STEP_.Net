using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Создать класс «Одномерный массив», в котором описать следующие элементы: 
•	+закрытое поле – массив целых чисел, 
•	+свойство для определения длины массива,
•	+индексатор для доступа к элементам поля-массива,  
•	+конструктор с параметрами,
•	+метод ToString(), 
•	+статический метод с переменным числом параметров для вычисления общей суммы отрицательных элементов в нескольких массивах, 
•	+операции  умножения массива на целое число и числа на массив,
•	+унарная операция - (знаки элементов меняются на противоположные)
•	-операция неявного преобразования строки в объект этого класса (Например, строка вида «1 2 -4 3 -2» преобразуется в объект класса Одномерный массив с полем-массивом (1 2 -4 3 -2) ).
При попытке неявного преобразования строки неправильного формата должно генерироваться исключение.
*/
namespace HomeWork5
{
    class One_dimensional_Array
    {
        int[] arr;
        int size;
        public int Count
        {
            get
            {
                if (arr != null)
                    return arr.Length;
                else return 0;
            }
        }
        public int[] Arr => arr;
        public One_dimensional_Array()
        {
            arr = null;
            size = 0;
        }
        public One_dimensional_Array(int[] arr)
        {
            this.arr = arr;
            size = Count;
        }
        public int this[int i]
        {
            get
            {
                return arr[i];
            }
            set
            {
                arr[i] = value;
            }
        }
        static public int Sum_Negative_Elements(params One_dimensional_Array[] arr)
        {
            int sum = 0;
            for(int i=0;i<arr.Length;i++)
            {
                for(int j=0;j<arr[i].Count;j++)
                {
                    if (arr[i][j] < 0)
                        sum += arr[i][j];
                }
            }
            return sum;
        }
        public static One_dimensional_Array operator *(One_dimensional_Array arr,int num)
        {
            for (int i = 0; i < arr.Count; i++)
                arr[i] *= num;
            return arr;
        }
        public static One_dimensional_Array operator *(int num,One_dimensional_Array arr)
        {
            for (int i = 0; i < arr.Count; i++)
                arr[i] *= num;
            return arr;
        }
        public static One_dimensional_Array operator -(One_dimensional_Array arr)
        {
            One_dimensional_Array tmp = new One_dimensional_Array(arr.Arr);
            for (int i = 0; i < tmp.Count; i++)
                tmp[i] *= -1;
            return tmp;
        }
        public static implicit operator One_dimensional_Array(string str)
        {
            int[] temp=null;
            int count = 1;
            for (int i = 0; i < str.Length; i++)
            {
                try
                {
                    if (str[i] == ' ')
                        count++;
                    if ((str[i] >= '0' && str[i] <= '9') || str[i] == '-' || str[i] == ' ')
                        continue;
                    else
                        throw new Exception("Не формат!!!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return (new One_dimensional_Array());
                }
            }
            temp = new int[count];
            string temp1 = null;
            int num = str.Length;
            int k;
            int j = 0;
            for (int i = 0; i < num; i++)
            {
                if ((str[i] >= '0' && str[i] <= '9') || str[i] == '-')
                {

                    for (k = i; k < num; k++)
                    {
                        if (str[k] == ' ')
                            break;
                        temp1 += str[k];
                    }
                    temp[j++] = Convert.ToInt32(temp1);
                    i = k;
                    temp1 = null;
                }
            }
            return (new One_dimensional_Array(temp));
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for(int i=0;i<Count;i++)
            {
                sb.Append($"{arr[i],4}");
            }
            return  sb.ToString();
        }
        
    }
}
