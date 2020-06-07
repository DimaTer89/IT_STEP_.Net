using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Adapter.Classes;

namespace Adapter
{
    public partial class Form1 : Form
    {
        Driver driver;
        Car carDriver;
        Camel animalDriver;
        Airplane airplaneDriver;
        AnimalToTransport animalAdapter;
        AirPlaneToTransport airplaneAdapter;
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            driver = new Driver();
            carDriver = new Car();
            airplaneDriver = new Airplane();
            animalDriver = new Camel();
            animalAdapter = new AnimalToTransport(animalDriver);
            airplaneAdapter = new AirPlaneToTransport(airplaneDriver);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                label1.Text = driver.Travel(carDriver);
            else if (comboBox1.SelectedIndex == 1)
                label1.Text = driver.Travel(animalAdapter);
            else
                label1.Text = driver.Travel(airplaneAdapter);
        }
    }
}
