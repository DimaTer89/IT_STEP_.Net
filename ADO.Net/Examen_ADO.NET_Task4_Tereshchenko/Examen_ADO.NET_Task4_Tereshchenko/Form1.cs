using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Examen_ADO.NET_Task4_Tereshchenko.Model;

namespace Examen_ADO.NET_Task4_Tereshchenko
{
    public partial class Form1 : Form
    {
        DogShelterContext db;
        const string connect = @"Data source=(localdb)\mssqllocaldb;Initial catalog=DogShelter;AttachDBFilename = d:\ado.net\Examen_ADO.NET_Task4_Tereshchenko\Examen_ADO.NET_Task4_Tereshchenko\bin\debug\DogShelter.mdf;Integrated security =true";
        public Form1()
        {
            InitializeComponent();
            db = new DogShelterContext(connect);
            dataGridView1.DataSource = db.Dogs.Select(d => new { d.DogName, d.Breed.Breedname, d.Height }).ToList();
            dogBox.DataSource = db.Breeds.Select(breed => breed.Breedname).ToList();
            dogBox.SelectedIndex = 0;
            comboBox1.DataSource = db.Dogs.Select(name => name.DogName).ToList();
            comboBox1.SelectedIndex = 0;
            dataGridView2.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (breedName.Text == "")
                MessageBox.Show("The field is empty, enter the name of the breed.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            else
            {
                var averageCount = db.Breeds.Where(breed => breed.Breedname == breedName.Text).Select(count => count.Dogs.Average(dog => dog.Height)).ToList();
                if (averageCount.Count==0)
                    averageHeght.Text = "Breed not found.";
                else
                    averageHeght.Text = String.Format("{0:f2} см.", averageCount.ElementAt(0));
            }
        }

        private void addDog_Click(object sender, EventArgs e)
        {
            if (dogName.Text == "")
                MessageBox.Show("The field is empty, enter the the name of the dog.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            else
            {
                int Id = db.Breeds.FirstOrDefault(id=>id.Breedname== dogBox.SelectedItem.ToString()).BreedId;
                if (db.Dogs.FirstOrDefault(dName => dName.DogName == dogName.Text) != null)
                    MessageBox.Show("A dog with the same name is in the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                else
                {
                    Dog dog = new Dog
                    {
                        DogName = dogName.Text,
                        BreedId = Id,
                        Height = (int)numericUpDown1.Value,
                    };
                    db.Dogs.Add(dog);
                    db.SaveChanges();
                    MessageBox.Show("Dog successfully added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    dataGridView1.DataSource = db.Dogs.Select(d => new { d.DogName, d.Breed.Breedname, d.Height }).ToList();
                }
            }
        }

        private void changeHeightDog_Click(object sender, EventArgs e)
        {
            try
            {
                if ((int)numericUpDown2.Value == db.Dogs.FirstOrDefault(dog => dog.DogName == comboBox1.SelectedItem.ToString()).Height)
                    MessageBox.Show("Current growth corresponds to a new level.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                else
                {
                    IEnumerable<Dog> dogy = db.Dogs.Where(dog => dog.DogName == comboBox1.SelectedItem.ToString()).AsEnumerable().Select(height => { height.Height = (int)numericUpDown2.Value; return height; });
                    foreach (var item in dogy)
                    {
                        db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    }
                    db.SaveChanges();
                    dataGridView1.DataSource = db.Dogs.Select(d => new { d.DogName, d.Breed.Breedname, d.Height }).ToList();
                }
            }
            catch
            {
                MessageBox.Show("Wrong data.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void dogsBelow50cm_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.DataSource = db.Dogs.Where(height => height.Height < 50).GroupBy(key => key.Breed.Breedname).
                   ToList().
                    Select(list => new
                    {
                        Breed =list.Key,
                        Names =list.OrderByDescending(height=>height.Height).
                        Select(breed=>breed.DogName).Aggregate((name1,name2)=>"("+name1+","+name2+")"),
                        Heights = list.OrderByDescending(t => t.Height).
                        Select(k => k.Height.ToString()).Aggregate((dog1, dog2) => dog1 + ";" + dog2)
                    })
                    .ToList();
            }
            catch
            {
                MessageBox.Show("OOPS");
            }
        }
    }
}
