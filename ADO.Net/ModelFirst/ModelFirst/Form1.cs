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
            dataGridView1.DataSource = db.CatSet.Select(cat => new {cat.Id, cat.Name, cat.Age, cat.Owner.LastName }).ToList();
            dataGridView1.Columns[0].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label1.Text == "Имя кота")
                dataGridView1.DataSource = db.CatSet.Where(cat => cat.Name == textBox1.Text).Select(cat => new {cat.Id, cat.Name, cat.Age, cat.Owner.LastName }).ToList();
            if (label1.Text == "Возраст кота")
            {
                int age = Convert.ToInt32(textBox1.Text);
                dataGridView1.DataSource = db.CatSet.Where(cat => cat.Age == age).Select(cat => new {cat.Id, cat.Name, cat.Age, cat.Owner.LastName }).ToList();
            }
            if (label1.Text == "Имя владельца")
                dataGridView1.DataSource = db.CatSet.Where(cat => cat.Owner.LastName == textBox1.Text).Select(cat => new { cat.Id,cat.Name, cat.Age }).ToList();
            dataGridView1.Columns[0].Visible = false;
        }

        private void добавлениеКотаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCat(new Form2("Добавление кота"));
        }

        private void добавлениеВладельцаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddOwner(new Form2("Добавление владельца"));
        }
        private void DeleteCat(Form2 form)
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
                try
                {
                    db.CatSet.Remove(db.CatSet.First(gib => gib.Name == cat && gib.Age == age && gib.Owner.LastName == name));
                    db.SaveChanges();
                }
                catch { }
                dataGridView1.DataSource = db.CatSet.Select(cats => new { cats.Id, cats.Name, cats.Age, cats.Owner.LastName }).ToList();
                dataGridView1.Columns[0].Visible = false;
            }
            catch { }
        }
        private void AddOwner(Form2 form)
        {
            try
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
            catch { }
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
                ModelFirst.Owner owner = db.OwnerSet.FirstOrDefault(own=>own.LastName==name);
                if (owner == null)
                {
                    try
                    {
                        ModelFirst.Owner owner1 = new Owner { LastName = name };
                        db.OwnerSet.Add(owner1);
                        db.SaveChanges();
                    }
                    catch { MessageBox.Show("Error"); }
                    owner = db.OwnerSet.First(own => own.LastName == name);
                    ModelFirst.Cat kot = new Cat { Name = cat, Owner = owner, Age = age };
                    db.CatSet.Add(kot);
                    db.SaveChanges();
                }
                else
                {
                    ModelFirst.Cat kot = new Cat { Name = cat, Owner = owner, Age = age };
                    db.CatSet.Add(kot);
                    db.SaveChanges();
                }
                dataGridView1.DataSource = db.CatSet.Select(cats => new { cats.Id, cats.Name, cats.Age, cats.Owner.LastName }).ToList();
                dataGridView1.Columns[0].Visible = false;
            }
            catch { };
        }

        private void количестовКотовУКаждогоВладельцадиаграммаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Statictic stat = new Statictic(db);
            stat.ShowDialog();
        }

        private void среднийВосрастКотовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox2.Text = String.Format("{0:f2}", Convert.ToDouble(db.CatSet.Average(cat => cat.Age)));
        }

        private void количествоВладельцевУКоторыхБольше2КотовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox3.Text=Convert.ToString(db.CatSet.GroupBy(own=>own.Owner.LastName).Where(own=>own.Count()>2).Count());
        }

        private void кличкиКотовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.CatSet.GroupBy(cat => cat.Name).OrderBy(cat => cat.Key).ToList();
            dataGridView1.Columns[0].HeaderText = "Клички котов";
        }

        private void удалениеПоВведённымДаннымToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCat(new Form2(""));
            dataGridView1.DataSource = db.CatSet.Select(cats => new { cats.Id, cats.Name, cats.Age, cats.Owner.LastName }).ToList();
            dataGridView1.Columns[0].Visible = false;
        }

        private void удалениеПоОтмеченномуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModelFirst.DeleteCat cat = new ModelFirst.DeleteCat(db);
            cat.ShowDialog();
            dataGridView1.DataSource = db.CatSet.Select(gib => new { gib.Id, gib.Name, gib.Age, gib.Owner.LastName }).ToList();
            dataGridView1.Columns[0].Visible = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            db.Dispose();
        }
    }
}
