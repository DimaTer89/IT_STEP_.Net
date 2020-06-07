using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Decorator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Driver driver = new CarDriver();
            driver.Name = textBox1.Text;
            if (checkBox1.Checked)
                driver = new BusDriver(driver);
            if (checkBox2.Checked)
                driver = new GonshchigDriver(driver);
            Form2 from2 = new Form2();
            from2.GetLabelText(driver.Drive());
            from2.ShowDialog();
        }
    }
}
