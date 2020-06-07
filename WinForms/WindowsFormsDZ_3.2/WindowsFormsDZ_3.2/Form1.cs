using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace WindowsFormsDZ_3._2
{
    public partial class Form1 : Form
    {
        List<Rabotnik> workers = new List<Rabotnik>();
        BindingSource source = new BindingSource();
        int j;
        event EventHandler MiddleSalary;
        public Form1()
        {
            InitializeComponent();
            label1.Enabled = true;
            textBox1.Enabled = true;
            radioButton1.Checked = true;
            timer1.Interval = 1000;
            timer1.Start();
            panel1.Visible = false;
            panel2.Visible = false;
            toolStripStatusLabel2.Text = DateTime.Now.ToString();
            openFileDialog1.InitialDirectory = Application.StartupPath;
            saveFileDialog1.InitialDirectory = Application.StartupPath;
            dataGridView1.Font = new Font("Segoe UI", 11);
            source.DataSource = workers;
            dataGridView1.DataSource = source;
            dataGridView1.Columns[0].HeaderText = "Фамилия";
            dataGridView1.Columns[1].HeaderText = "Фирма";
            dataGridView1.Columns[2].HeaderText = "Дата рождения";
            dataGridView1.Columns[3].HeaderText = "Зарплата за полгода";
            textBox1.Text = "";
        }
        void NotEnableButtons()
        {
            сохранитьToolStripMenuItem.Enabled = false;
            обработкаToolStripMenuItem.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }
        void EnableButtons()
        {
            сохранитьToolStripMenuItem.Enabled = true;
            обработкаToolStripMenuItem.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToString();
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            NotEnableButtons();
            source.Clear();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            source.Clear();
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                using (StreamReader reader = new StreamReader(openFileDialog1.FileName))
                {
                    while(!reader.EndOfStream)
                    {
                        string[] str;
                        str = reader.ReadLine().Split(';');
                        string[] tmp = str[3].Split(' ');
                        decimal[] temp = new decimal[tmp.Length];
                        try
                        {
                            for (int i = 0; i < tmp.Length; i++)
                                temp[i] = Convert.ToDecimal(tmp[i]);
                        }
                        catch { }
                        source.Add(new Rabotnik(str[0], str[1], str[2], temp));
                    }
                }
            }
            panel1.Visible = true;
            EnableButtons();
        }
       
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog1.FileName))
                {
                    foreach (Rabotnik item in workers)
                    {
                        writer.WriteLine(item);
                    }
                }
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            source.Add(new Rabotnik());
            EnableButtons();
        }

        private void средняяЗарплатаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnableColorDateGridView(Color.White);
            List<Rabotnik> list = workers.Where(s => s.LabelFilm.CompareTo(textBox1.Text) == 0).ToList();
            Form2 form2 = new Form2(list);
            form2.ShowDialog();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                MiddleSalary += средняяЗарплатаToolStripMenuItem_Click;
                MiddleSalary?.Invoke(this,EventArgs.Empty);
                MiddleSalary -= средняяЗарплатаToolStripMenuItem_Click;
            }
            if(radioButton2.Checked)
            {
                MiddleSalary += самыйМолодойToolStripMenuItem_Click;
                MiddleSalary ?.Invoke(this, EventArgs.Empty);
                MiddleSalary -= самыйМолодойToolStripMenuItem_Click;
            }
        }
        void EnableColorDateGridView(Color color)
        {
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                dataGridView1[i, j].Style.BackColor = color;
        }
        private void самыйМолодойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int min = workers[0].Age();
            j = 0;
            for(int i=0;i<workers.Count;i++)
            {
                if (workers[i].Age() < min)
                {
                    j = i;
                    min = workers[i].Age();
                }
            }
            EnableColorDateGridView(Color.Red);
        }
    }
}
