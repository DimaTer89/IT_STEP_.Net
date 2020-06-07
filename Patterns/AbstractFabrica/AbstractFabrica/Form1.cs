using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbstractFabrica
{
    public partial class Form1 : Form
    {
        List<IFactory> factory;
        public Form1()
        {
            InitializeComponent();
            factory = new List<IFactory> { new AvtoVazFactory(), new VWFactory() };
            comboBox2.SelectedIndex = 0;
            //factory.Add(new AvtoVazFactory());
            //factory.Add(new VWFactory());
            comboBox1.DataSource = factory;
            //comboBox1.DisplayMember = "Name";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                IFactory currentFacrtory = (IFactory)comboBox1.SelectedItem;
                //if (comboBox1.SelectedIndex == 0)
                //    currentFacrtory = new AvtoVazFactory();
                //else
                //    currentFacrtory = new VWFactory();
                string engineType = radioButton1.Checked ? "Benzine" : "Diesel";
                //MessageBox.Show(currentFacrtory.CreateAuto("Red", engineType).ToString());
                if (comboBox2.SelectedIndex == 1)
                {
                    textBox1.Text = currentFacrtory.CreateAuto("Red", engineType).ToString();
                }
                else
                {
                    textBox1.Text = currentFacrtory.CreateMotocycle("Black", engineType).ToString();
                }
            }
            catch
            {
                MessageBox.Show("No found!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }

        }
    }
}
