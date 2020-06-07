using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDZ_1
{
    public partial class Form1 : Form
    {
        int tick_interval = 60;
        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("Программа работает минуту, но если в классе Form1 изменить переменную tick_interval, то время работы увеличиться или уменьшиться ", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            timer1.Start();
            Text = DateTime.Now.ToLongTimeString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(textBox1.Text);
                double y = Convert.ToDouble(textBox2.Text);
                double rezult = Math.Pow((Math.Pow(Math.Sin(x), 2) + 1), 3) - Math.Sqrt(Math.Abs(y - 3)) / 3.01;
                textBox3.Text = $"{rezult:f12}";
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 photoForm2 = new Form2();
            photoForm2.ShowDialog();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            --tick_interval;
            Text =System.DateTime.Now.ToLongTimeString();
            if (tick_interval == 0)
                Application.Exit();
        }
        private void Form1_Closing(object sender,FormClosingEventArgs e)
        {
            if (tick_interval == 0)
                MessageBox.Show("До новых встреч", "Bye-Bye", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
