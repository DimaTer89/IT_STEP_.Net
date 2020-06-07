using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProxySingletton.Interfaces;
using ProxySingletton.Proxy;

namespace ProxySingletton
{
    public partial class Form1 : Form
    {
        IPrizeOrder deputyHead;
        public Form1()
        {
            InitializeComponent();
            deputyHead = new DeputyHead("Петров Петр Петрович");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                PrizeOrder order = new PrizeOrder(deputyHead.CreatePrizeOrder(textBox1.Text, Convert.ToDecimal(textBox2.Text)));
                order.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Неверные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
