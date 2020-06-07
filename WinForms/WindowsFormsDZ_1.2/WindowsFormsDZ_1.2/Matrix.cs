using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsDZ_1._2
{
    class Matrix
    {
        int RowCount;
        int ColumnCount;
        int[,] matrixArray;
        public Matrix(int RowCount,int ColumnCount)
        {
            this.RowCount = RowCount;
            this.ColumnCount = ColumnCount;
            matrixArray = new int[RowCount, ColumnCount];
        }
        public int this[int x, int y]
        {
            get => matrixArray[x, y];
            set
            {
                matrixArray[x, y] = value;
            }
        }
        public void MaxElemMatrix(ref int row, ref int col)
        {
            int max = matrixArray[0, 0];
            row = col = 0;
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    if (matrixArray[i, j] > max)
                    {
                        row = i;
                        col = j;
                        max = matrixArray[i, j];
                    }
                }
            }
        }
        public void MinElemMatrix(ref int row, ref int col)
        {
            int min = matrixArray[0, 0];
            row = col = 0;
            for(int i=0;i<RowCount;i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    if (min > matrixArray[i, j])
                    {
                        row = i;
                        col = j;
                        min = matrixArray[i, j];
                    }
                }
            }
        }
        public List<int> PositiveElements()
        {
            List<int> postiveElems = new List<int>();
            for(int i=0;i<RowCount;i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                    if (matrixArray[i, j] > 0)
                        postiveElems.Add(matrixArray[i, j]);
            }
            return postiveElems;
        }

    }
}
