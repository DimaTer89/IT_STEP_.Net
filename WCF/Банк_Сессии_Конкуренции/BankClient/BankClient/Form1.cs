using BankClient.BankServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankClient
{
    public partial class Form1 : Form
    {
        BankServiceClient proxy;
        public Form1()
        {
            InitializeComponent();
             proxy = new BankServiceClient();
             textBox2.Text = proxy.GetBalance().ToString();
             label3.Text = "Идентификатор сесии " + proxy.InnerChannel.SessionId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                decimal sum = Convert.ToDecimal(textBox1.Text);
                proxy.ToDeposit(sum);
                textBox2.Text = proxy.GetBalance().ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Что-то не так...");
                textBox1.Text = "";
                textBox1.Focus();
            }
        }
    }
}
