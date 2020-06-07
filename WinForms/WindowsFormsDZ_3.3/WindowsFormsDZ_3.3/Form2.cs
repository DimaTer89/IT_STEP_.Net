using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDZ_3._3
{
    public partial class Form2 : Form
    {
        public Form2(Matrix matrix,int[,] array)
        {
            InitializeComponent();
            dataGridView1.RowCount = dataGridView2.RowCount=array.GetLength(0);
            dataGridView1.ColumnCount = dataGridView2.ColumnCount=array.GetLength(1);
            for(int i=0;i<dataGridView1.RowCount;i++)
            {
                for(int j=0;j<dataGridView1.ColumnCount;j++)
                {
                    dataGridView1[j, i].Value = matrix[i, j];
                    dataGridView2[j, i].Value = array[i, j];
                }
            }
        }

       
    }
}
