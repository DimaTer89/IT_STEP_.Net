using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeFirstSportsmens.Model;
using System.Data.SqlClient;

namespace CodeFirstSportsmens
{
    public partial class Form1 : Form
    {
        SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
        SportsmenContext spDb;
        public Form1()
        {
            InitializeComponent();
            stringBuilder.DataSource = @"(localdb)\mssqllocaldb";
            stringBuilder.InitialCatalog = "Championship";
            stringBuilder.IntegratedSecurity = true;
            spDb = new SportsmenContext(stringBuilder.ConnectionString);
            dataGridView1.DataSource = spDb.Sportsmen.Select(s => new { s.Lastname,s.Country.Name, s.SportKind.Kind, s.Place }).ToList();
            dataGridView1.Columns[0].HeaderText = "Фамилия";
            dataGridView1.Columns[1].HeaderText = "Страна";
            dataGridView1.Columns[2].HeaderText = "Вид спорта";
            dataGridView1.Columns[1].HeaderText = "Место";
        }
    }
}
