using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientForms.ServiceReference1;
using System.ServiceModel;

namespace ClientForms
{
    public partial class Form1 : Form
    {
        CalculateContractClient calc;
        DopContractClient dop;
        Person person = new Person { Name = "Misha", Weight = 90 };
        PersonContractClient personClient;
        public Form1()
        {
            InitializeComponent();
            calc = new CalculateContractClient();
            dop = new DopContractClient();
            personClient = new PersonContractClient();
            label7.Text = person.Name + " old Weight=" + person.Weight;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(textBox1.Text);
                double y = Convert.ToDouble(textBox2.Text);
                textBox3.Text = calc.Plus(x, y).ToString();
                textBox4.Text = calc.Sqr(x).ToString();
                textBox5.Text = dop.SinXCosY(x, y).ToString("f5");
                textBox6.Text = dop.TexX(x).ToString();
                textBox7.Text = "New Weight=" + personClient.WeightPlus(ref person, x);
                label7.Text = person.Name + " old Weight=" + person.Weight;
               
            }
            
            catch(FormatException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(TimeoutException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(EndpointNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            personClient.HelloPerson(person, "Hello ");
            MessageBox.Show("WoW!!!");
        }
    }
}
