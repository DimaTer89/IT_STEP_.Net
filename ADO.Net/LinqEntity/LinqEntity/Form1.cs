using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqEntity
{
    public partial class Form1 : Form
    {
        HumansEntities humanEnt = new HumansEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void deletePeople_Click(object sender, EventArgs e)
        {

        }

        private void humans_Click(object sender, EventArgs e)
        {
           dataGridView1.DataSource=humanEnt.Men.Select(men=>new { Name = men.Name, Country = men.Country.Name }).ToList();
        }

        private void countPeople_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = humanEnt.Men.GroupBy(cout=>cout.Country.Name).Select(cout=>new { Name = cout.Key, Count = cout.Count() }).ToList();
        }

        private void addCanadaPeople_Click(object sender, EventArgs e)
        {

        }
    }
}
