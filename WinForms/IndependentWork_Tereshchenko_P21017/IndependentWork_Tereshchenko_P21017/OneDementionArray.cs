using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Создать класс «Одномерный массив», в котором описать следующие элементы: 
 * закрытое поле – массив целых чисел,
 * свойство для определения длины массива,
 * индексатор для доступа к элементам поля-массива,
 * конструктор с параметрами,
 * метод для вычисления суммы элементов массива,
 * метод для вычисления произведения элементов массива.*/
namespace IndependentWork_Tereshchenko_P21017
{
    public class OneDementionArray
    {
        int[] array;
        public OneDementionArray(int[] array)
        {
            this.array = array;
        }
        public int Lenght=> array.Length;
        public  int this[int n]=>array[n];
        public int Sum() => array.Sum();
        public int ProductOfElements()
        {
            int temp = 1;
            foreach (int item in array)
            {
                temp *= item;
            }
            return temp;
        }
    }
}
