using CodeFirstMigrationManyToMany.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CodeFirstMigrationManyToMany
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder();
            connStr.DataSource = @"(localdb)\mssqllocaldb";
            connStr.InitialCatalog = "Football";
            connStr.AttachDBFilename = Application.StartupPath+@"\Football.mdf";
            connStr.IntegratedSecurity = true;
            using (FootballContext db = new FootballContext(connStr.ConnectionString))
            {
                //var p = db.Players.Include("Teams").ToList();
                dataGridView1.DataSource = db.Players.ToList().Select(pl => new { pl.Name, pl.Position, pl.Age, Team = pl.Teams.LastOrDefault().Name }).ToList();
            }
        }
    }
}
