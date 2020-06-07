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
                button1.Location = new Point(89, 56);
                Size = new Size(356, 149);
            }
            else
            {
                button1.Location = new Point(80, 161);
                Size = new Size(356, 247);
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
