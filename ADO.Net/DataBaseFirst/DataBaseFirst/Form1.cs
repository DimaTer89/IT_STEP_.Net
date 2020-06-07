using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            OlimpiadaEntities olimpiada = new OlimpiadaEntities();
            InitializeComponent();
            dataGridView1.DataSource = olimpiada.Sportmens.Select(sport => new { sport.Id, sport.Surname, sport.Sport.kindOfSport, sport.Country.nameCountry, sport.result }).ToList();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Фамилия спотрсмена";
            dataGridView1.Columns[2].HeaderText = "Вид спорта";
            dataGridView1.Columns[3].HeaderText = "Страна";
            dataGridView1.Columns[4].HeaderText = " Место";
        }

        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
