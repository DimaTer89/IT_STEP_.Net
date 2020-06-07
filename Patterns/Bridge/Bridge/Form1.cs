using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bridge
{
    public partial class Form1 : Form
    {
        PriceCalc priceCalc;
        PriceCalcImpl priceImpl;
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            radioButton1.Checked = true;
            textBox1.ReadOnly = true;
            priceImpl = new PriceCalcBaseImpl();
            priceCalc = new RefinedPriceCalc(priceImpl);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(comboBox1.SelectedItem.ToString() + " " + numericUpDown1.Value.ToString() + " шт.");
            listBox1.Items.Add(builder);
            priceCalc.AddProduct(Convert.ToUInt32(comboBox1.SelectedIndex), Convert.ToUInt32(numericUpDown1.Value));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                priceImpl = new PriceCalcShippImpl();
                priceCalc.GetPriceCalcImpl(priceImpl);
            }
            else
            {
                priceImpl = new PriceCalcBaseImpl();
                priceCalc.GetPriceCalcImpl(priceImpl);
            }
            textBox1.Text=priceCalc.GetTotalPrice(comboBox2.SelectedItem.ToString()).ToString();
        }
    }
}
