using EasyWeightLoss.DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyWeightLoss
{
    public partial class RegistrationForm : Form
    {
        public User User { get; private set; }
        public RegistrationForm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            label7.Visible = false;
        }
        //public string Nickname => textBox1.Text;
        //public int Male => comboBox1.SelectedIndex;
        //public int Activity => comboBox2.SelectedIndex;
        //public string Password
        //{
        //    get
        //    {
        //        if (textBox2.Text == textBox3.Text)
        //            return textBox2.Text;
        //        else
        //            return "!!!";
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            User = new User
            {
                Login = textBox1.Text,
                Password = textBox2.Text,
                Age = Convert.ToInt32(numericUpDown1.Value),
                Sex = (Sex)comboBox1.SelectedIndex,
                ActivityLevel = (ActivityLevel)comboBox2.SelectedIndex
            };
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(textBox3.Text!=textBox2.Text)
            {
                label7.Visible = true;
                textBox2.ForeColor = Color.Red;
                button1.DialogResult = DialogResult.None;
            }
            else
            {
                label7.Visible = false;
                textBox2.ForeColor = Color.Black;
                button1.DialogResult = DialogResult.OK;
            }
        }
    }
}
