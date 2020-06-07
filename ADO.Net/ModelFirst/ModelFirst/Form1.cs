using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModelFirst
{
    public partial class Form1 : Form
    {
        CatsModelContainer db = new CatsModelContainer();
        public Form1()
        {
            InitializeComponent();
            groupBox1.Visible = false;
            //dataGridView1.DataSource = db.CatSet.Select(cat => new { cat.Name, cat.Age, cat.Owner.LastName }).ToList();
        }

        private void поКличкеКотаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Имя кота";
            groupBox1.Visible = true;
        }

        private void поВозрастуКотаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Возраст кота";
            if (!groupBox1.Visible)
                groupBox1.Visible = true;
        }

        private void поИмениВладельцаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Имя владельца";
            if (!groupBox1.Visible)
                groupBox1.Visible = true;
        }

        private void всёToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.CatSet.Select(cat => new { cat.Name, cat.Age, cat.Owner.LastName }).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label1.Text == "Имя кота")
                dataGridView1.DataSource = db.CatSet.Where(cat => cat.Name == textBox1.Text).Select(cat => new { cat.Name, cat.Age, cat.Owner.LastName }).ToList();
            if (label1.Text == "Возраст кота")
            {
                int age = Convert.ToInt32(textBox1.Text);
                dataGridView1.DataSource = db.CatSet.Where(cat => cat.Age == age).Select(cat => new { cat.Name, cat.Age, cat.Owner.LastName }).ToList();
            }
            if (label1.Text == "Имя владельца")
                dataGridView1.DataSource = db.CatSet.Where(cat => cat.Owner.LastName == textBox1.Text).Select(cat => new { cat.Name, cat.Age }).ToList();
        }

        private void добавлениеКотаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCat(new Form2("Добавление кота"));
        }

        private void добавлениеВладельцаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddOwner(new Form2("Добавление владельца"));
        }

        private void удалениеКотаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void AddOwner(Form2 form)
        {
            string name;
            form.ShowDialog();
            name = form.OwnerName;
            try
            {
                ModelFirst.Owner owner = new Owner { LastName = name };
                db.OwnerSet.Add(owner);
                db.SaveChanges();
            }
            catch { MessageBox.Show("Error"); }
        }
        private void AddCat(Form2 form)
        {
            try
            {
                string name;
                string cat;
                int age;
                form.ShowDialog();
                name = form.OwnerName;
                cat = form.CatName;
                age = Convert.ToInt32(form.Age);
                ModelFirst.Owner owner = db.OwnerSet.FirstOrDefault(own => own.LastName == name);
                if (owner == null)
                {
                    AddOwner(new Form2("Добавление владельца"));
                    owner = db.OwnerSet.First(own => own.LastName == name);
                    AddCat(new Form2("Добавление кота"));
                }
                else
                {
                    ModelFirst.Cat kot = new Cat { Name = cat, Owner = owner, Age = age };
                    db.CatSet.Add(kot);
                    db.SaveChanges();
                }
            }
            catch { };
        }
        private void сортировкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.OwnerSet.Select(own => own).ToList();
        }
    }
}
