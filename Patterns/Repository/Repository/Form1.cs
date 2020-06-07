using Repository.DBRepositories;
using Repository.Interfaces;
using Repository.MemoryRepositpries;
using Repository.Models;
using Repository.XmlRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Repository.FileRepositories;

namespace Repository
{
    public partial class Form1 : Form
    {
        IRepository<Dog> db;
        IRepository<Cat> cb;
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }
    //Открыть
        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        //db = new DbDogRepository();
                        break;
                    }
                case 1:
                    {
                        db = new FileDogRepositories();
                        cb = new FileCatRepositories();
                        break;
                    }
                case 2:
                    {
                        db = new XmlDogRepository();
                        cb = new XmlCatRepositories();
                        break;
                    }
                case 3:
                    {
                        db = new MemDogRepository();
                        cb = new MemCatRepositories();
                        break;
                    }
                
            }
            dataGridView1.DataSource = db.GetAll().ToList();
            dataGridView2.DataSource = cb.GetAll().ToList();
        }
    }
}
