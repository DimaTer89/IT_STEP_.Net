using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppDZ_6_Tereshchenko
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        Function func;
        Pen pen1 = new Pen(Color.Blue, 4);
        Pen pen2 = new Pen(Color.Red, 4);
        const string wrong = "Wrong data!!!";
        public Form1()
        {
            InitializeComponent();
            checkBox1.Checked = true;
            graphics = panel1.CreateGraphics();
            func = new Function(panel1.Size);
        }

        private void label1_Paint(object sender, PaintEventArgs e)
        {
           
            e.Graphics.DrawLine(pen1, 1, label1.Size.Height / 2, label1.Size.Width - 1, label1.Size.Height / 2);
        }

        private void label2_Paint(object sender, PaintEventArgs e)
        {
          
            e.Graphics.DrawLine(pen2, 1, label2.Size.Height / 2, label2.Size.Width - 1, label2.Size.Height / 2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.Aqua);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.Aqua);
            try
            {
                func.XBegin = Convert.ToDouble(textBox1.Text);
                func.XEnd = Convert.ToDouble(textBox2.Text);
                if (func.XEnd <= func.XBegin)
                    throw new MyException("xEnd more or equal xBegin");
                func.FillingData();
                if(checkBox1.Checked&&!checkBox2.Checked)
                    func.PaintGraphSin(panel1.Size, pen1, graphics);
                if (checkBox2.Checked && !checkBox1.Checked)
                    func.PaintGraphCos(panel1.Size, pen2, graphics);
                if (checkBox1.Checked && checkBox2.Checked)
                    func.PaintGraphSinCos(panel1.Size, pen1,pen2, graphics);
            }
            catch (MyException ex)
            {
                MessageBox.Show(ex.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);
            }
            catch
            {
                MessageBox.Show(wrong, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            
        }
        
    }
}
