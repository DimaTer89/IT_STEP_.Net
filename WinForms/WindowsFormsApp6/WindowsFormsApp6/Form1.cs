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

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        List<Dog> dogs = new List<Dog>();
        BindingSource source = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            //toolStripStatusLabel2.Text = DateTime.Now.ToShortDateString() +"   "+ DateTime.Now.ToLongTimeString();
            toolStripStatusLabel2.Text = DateTime.Now.ToString();
            //dogs.Add(new Dog());
            //dogs.Add(new Dog());
            source.DataSource = dogs;
            dataGridView1.Font = new Font("Arial", 12);
            dataGridView1.DataSource = source;
            dataGridView1.Columns[0].HeaderText = "Кличка";
            dataGridView1.Columns[1].HeaderText = "Владелец";
            dataGridView1.Columns[2].HeaderText = "Высота в холке";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //toolStripStatusLabel2.Text = DateTime.Now.ToShortDateString() + "   " + DateTime.Now.ToLongTimeString();
            toolStripStatusLabel2.Text = DateTime.Now.ToString();
        }

        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            //поискToolStripMenuItem.Enabled = true;
        }
        //добавить собаку
        private void button1_Click(object sender, EventArgs e)
        {
            поискToolStripMenuItem.Enabled = true;
            source.Add(new Dog());
            // тоже самое
            //source.AddNew();
        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = dogs.Count(s => s.Height > 25).ToString();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Application.StartupPath;
            if(saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                saveFileDialog1.InitialDirectory = Application.StartupPath;
                using (StreamWriter writer = new StreamWriter(saveFileDialog1.FileName))
                {
                    for(int i=0;i<dataGridView1.RowCount;i++)
                    {
                        writer.WriteLine(dataGridView1[0, i].Value + ";" + dataGridView1[1, i].Value + ";" + dataGridView1[2, i].Value);
                    }
                }
            }
        }
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Application.StartupPath;
            source.Clear();
            panel1.Visible = true;
            поискToolStripMenuItem.Enabled = true;
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                using (StreamReader reader = new StreamReader(openFileDialog1.FileName))
                {
                    while(!reader.EndOfStream)
                    {
                        string[] str;
                        str = reader.ReadLine().Split(';');
                        source.Add(new Dog { Name = str[0], Owner = str[1], Height = Convert.ToDouble(str[2]) });
                    }
                }
            }
        }
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message + " ошибка в строке " + e.RowIndex);
            dataGridView1[e.ColumnIndex, e.RowIndex].Value = 0;
        }
    }
}
