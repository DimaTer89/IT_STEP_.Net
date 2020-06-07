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
    public partial class Form1 : Form
    {
        Matrix matrix;
        int[,] tmpMarix;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.RowCount = 1;
            toolTip1.SetToolTip(button1, "Заменяет отрицательные элементы матрицы на количество положительных элементов");
            dataGridView1.ShowCellToolTips = false;
            toolTip1.SetToolTip(dataGridView1, "Отображение матрицы");
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.RowCount = (int)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = (int)numericUpDown2.Value;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            matrix = new Matrix(dataGridView1.RowCount, dataGridView1.ColumnCount);
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    try
                    {
                        matrix[i, j] = Convert.ToInt32(dataGridView1[j, i].Value);
                    }
                    catch
                    {
                        MessageBox.Show($"Неверные данные в {i+1} строке, {j+1} столбце, неверные данные заменяются на 0", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        matrix[i, j] = Convert.ToInt32(dataGridView1[j, i].Value = 0);
                    }
                }
            }
            int count = matrix.NumberOfPositive();
            tmpMarix = new int[dataGridView1.RowCount, dataGridView1.ColumnCount];
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (matrix[i, j] < 0)
                        tmpMarix[i, j] = count;
                    else
                        tmpMarix[i, j] = matrix[i, j];
                }
            }
            if (checkBox1.Checked)
            {
                Form2 form2 = new Form2(matrix, tmpMarix);
                form2.ShowDialog();
            }
            else
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        dataGridView1[j, i].Value = tmpMarix[i, j];
                    }
                }
            }
        }
    }
}
