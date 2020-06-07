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
using System.Data.Linq;

namespace independentWork
{
    public partial class Form1 : Form
    {
        CowDataContext cowDataBase;
        SqlConnectionStringBuilder strBuilder;
        public Form1()
        {
            InitializeComponent();
            strBuilder = new SqlConnectionStringBuilder();
            strBuilder.DataSource = @"(localdb)\mssqllocaldb";
            strBuilder.InitialCatalog = "Cowshed";
            strBuilder.IntegratedSecurity = true;
            cowDataBase = new CowDataContext(strBuilder.ConnectionString);
            dataGridView1.DataSource = cowDataBase.Cows;
            dataGridView1.Columns[0].Visible = false;
        }

        private void save_Click(object sender, EventArgs e)
        {
            cowDataBase.SubmitChanges();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            cowDataBase = new CowDataContext(strBuilder.ConnectionString);
            dataGridView1.DataSource=cowDataBase.Cows;
            dataGridView1.Columns[0].Visible = false;
        }

        private void needAboveAverage_Click(object sender, EventArgs e)
        {
            var nadoiQuery = cowDataBase.Cows.Where(cow => cow.Nadoi > cowDataBase.Cows.Average(cows => cows.Nadoi));
            dataGridView1.DataSource = nadoiQuery.ToList();
            dataGridView1.Columns[0].Visible = false;
        }

        private void dataBase_Click(object sender, EventArgs e)
        {
           
            dataGridView1.DataSource = cowDataBase.Cows;
        }
    }
}
