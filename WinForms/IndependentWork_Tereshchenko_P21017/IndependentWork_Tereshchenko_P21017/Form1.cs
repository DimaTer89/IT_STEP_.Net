using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndependentWork_Tereshchenko_P21017
{
    public partial class Form1 : Form
    {
        OneDementionArray array;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.RowCount = 1;
            comboBox1.SelectedIndex = 0;
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = (int)numericUpDown1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] tmp = new int[dataGridView1.ColumnCount];
            for(int i=0;i<dataGridView1.ColumnCount;i++)
            {
                try
                {
                    tmp[i] = Convert.ToInt32(dataGridView1[i,0].Value);
                }
                catch { }
            }
            array = new OneDementionArray(tmp);
            Form2 form2 = new Form2();
            if (comboBox1.SelectedIndex == 0)
                form2.ShowDialog(array, "Сумма = ", array.Sum());
            else
                form2.ShowDialog(array, "Произведение = ", array.ProductOfElements());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }
    }
}
