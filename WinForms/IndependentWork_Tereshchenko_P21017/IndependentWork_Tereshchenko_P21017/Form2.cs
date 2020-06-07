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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public void ShowDialog(OneDementionArray array,string title,int rezult)
        {
            dataGridView1.RowCount = array.Lenght;
           
            for(int i=0;i<array.Lenght;i++)
            {
                dataGridView1[0, i].Value = array[i];
            }
            label1.Text = title;
            if(title=="Сумма = ")
                 label2.Location=new Point(240,120);
            label2.Text = rezult.ToString();
            ShowDialog();
        }
       
    }
}
