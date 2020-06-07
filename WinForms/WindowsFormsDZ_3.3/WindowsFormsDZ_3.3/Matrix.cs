using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsDZ_3._3
{
    public class Matrix
    {
        int[,] matrixArray;
        public Matrix(int row,int col)
        {
            matrixArray = new int[row, col];
        }
        public int this[int row,int col]
        {
            get => matrixArray[row, col];
            set => matrixArray[row, col] = value;
        }
        public int NumberOfPositive()
        {
            int count = 0;
            for(int i=0;i<matrixArray.GetLength(0);i++)
            {
                for (int j = 0; j < matrixArray.GetLength(1); j++)
                    if (matrixArray[i, j] > 0)
                        count++;
            }
            return count;
        }
    }
}
