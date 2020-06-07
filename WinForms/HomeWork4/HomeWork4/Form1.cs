using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HomeWork4
{
    public partial class Form1 : Form
    {
        const int points = 100;
        private void SinX(Chart chartArea,double xB=-3.1, double xE=2.9)
        {
            double xS = (xE - xB) / points;
            for (double i = xB; i <= xE; i += xS)
                chartArea.Series[0].Points.AddXY(i, Math.Sin(i));
        }
        private void CosX(Chart chartArea,double xB=-3.1,double xE=2.9)
        {
            double xS = (xE - xB) / points;
            for (double i = xB; i <= xE; i += xS)
                 chartArea.Series[1].Points.AddXY(i, (2*Math.Cos(i)));
        }
        private void ChangeFunction(Chart chartArea,double xB=-3.1,double xE=2.9)
        {
            chartArea.Series[0].Points.Clear();
            chartArea.Series[1].Points.Clear();
            if (checkBox1.Checked && checkBox2.Checked)
            {
                SinX(chartArea,xB,xE);
                CosX(chartArea,xB,xE);
            }
            else if (checkBox1.Checked)
                SinX(chartArea,xB,xE);
            else if(checkBox2.Checked)
                CosX(chartArea,xB,xE);
            else
            {
                chartArea.Series[0].Points.Clear();
                chartArea.Series[1].Points.Clear();
            }
        }
        public Form1()
        {
            InitializeComponent();
            checkBox1.Checked = true;
            radioButton1.Checked = true;
            panel1.Visible = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            ChangeFunction(chart1);
        }
        private void RunFunctionRadioButton1(Chart chartArea)
        {
            double xB = 0;
            double xE = 0;
            try
            {
                xB = Convert.ToDouble(textBox1.Text);
                xE = Convert.ToDouble(textBox2.Text);
                try
                {
                    if (xB > xE)
                        throw new Exception("Начальное значение X больше конечного");
                    if (chart1.Visible)
                        ChangeFunction(chartArea, xB, xE);
                    else
                    {
                        chart1.Visible = true;
                        panel1.Visible = false;
                        ChangeFunction(chartArea, xB, xE);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            catch
            {
                MessageBox.Show("Неверные данные", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        private void RunFunctionRadioButton2(Chart chartArea)
        {
            double xB = 0;
            double xE = 0;
            try
            {
                xB = Convert.ToDouble(textBox1.Text);
                xE = Convert.ToDouble(textBox2.Text);
                try
                {
                    if (xB > xE)
                        throw new Exception("Начальное значение X больше конечного");
                    ChangeFunction(chartArea, xB, xE);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            catch
            {
                MessageBox.Show("Неверные данные", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (chart1.Visible)
                    ChangeFunction(chart1);
                else
                {
                    chart1.Visible = true;
                    panel1.Visible = false;
                    ChangeFunction(chart1);
                }
            }
            else
                RunFunctionRadioButton1(chart1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Visible = false;
            panel1.Visible = true;
            if (radioButton1.Checked)
            {
                ChangeFunction(chart2);
            }
            else
                RunFunctionRadioButton2(chart2);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox1.Focus();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Enabled = false;
                textBox2.Enabled = false;
            }
        }
    }
}
