using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModelFirst
{
    public partial class Form2 : Form
    {
       
        public Form2(string pole)
        {
            InitializeComponent();
            if (pole == "Добавление владельца")
            {
                label1.Visible = false;
                label2.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
            }
        }
        public string OwnerName => textBox3.Text;
        public string CatName => textBox1.Text;
        public string Age => textBox2.Text;
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
