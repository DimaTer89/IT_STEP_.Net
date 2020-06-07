using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDZ_1._2
{
    public partial class Form1 : Form
    {
        Matrix matrix;
        int col = 0;
        int row = 0;
        DataGridViewCellStyle temp = new DataGridViewCellStyle();
        DataGridViewCellStyle tmp = new DataGridViewCellStyle();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.RowCount = 1;
            tmp.BackColor = Color.White;
            temp.BackColor = Color.Green;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = (int)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.RowCount = (int)numericUpDown2.Value;
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
                        matrix[i, j] = 0;
                        dataGridView1[j, i].Value = 0;
                    }
                }
                      
            }
            if(col<dataGridView1.ColumnCount&&row<dataGridView1.RowCount)
                dataGridView1[col, row].Style = tmp;
            if (radioButton1.Checked)
            {
                matrix.MaxElemMatrix(ref row,ref col);
                dataGridView1[col, row].Style = temp;
            }
            else
            {
                matrix.MinElemMatrix(ref row,ref col);
                dataGridView1[col, row].Style = temp;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            List<int> temp = matrix.PositiveElements();
            foreach (int item in temp)
            {
                listBox1.Items.Add(item);
            }
            listBox1.Visible = true;
        }
    }
}
