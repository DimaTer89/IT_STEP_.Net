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

namespace DisabledMode
{
    public partial class Form1 : Form
    {
        DataSet set = new DataSet();
        SqlDataAdapter adapter;
        SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
        public Form1()
        {
            InitializeComponent();
           
            comboBox1.SelectedIndex = 0;
            stringBuilder.DataSource = @"(localdb)\mssqllocaldb";
            stringBuilder.InitialCatalog = "Library";
            stringBuilder.IntegratedSecurity = true;
            adapter = new SqlDataAdapter("select * from Authors", stringBuilder.ConnectionString);
            adapter.Fill(set, "Authors");
            //adapter.SelectCommand.CommandText = "select * from Books";
            //adapter.Fill(set, "Books");
        }

        private void disabledMode_Click(object sender, EventArgs e)
        {
            string nameTable = "";          
            switch(comboBox1.SelectedIndex)
            {
                case 0: nameTable="Authors";break;
                case 1: nameTable="Books";break;
            }
            adapter.SelectCommand.CommandText = "select * from " + nameTable;
            set.Tables[nameTable]?.Clear();
            adapter.Fill(set, nameTable);
            dataGridView1.DataSource = set.Tables[nameTable];
        }

        private void save_Click(object sender, EventArgs e)
        {
            string nameTable = "";
            switch (comboBox1.SelectedIndex)
            {
                case 0: nameTable = "Authors"; break;
                case 1: nameTable = "Books"; break;
            }
            SqlCommand delete = new SqlCommand();
            delete.Connection = adapter.SelectCommand.Connection;
            delete.CommandText = "delete from " + nameTable + " where Id=@id";
            delete.Parameters.Add("@id",SqlDbType.Int);
            delete.Parameters["@id"].SourceColumn = "Id";
            adapter.DeleteCommand = delete;
            adapter.Update(set,nameTable);
            MessageBox.Show("Save Complited","Information",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
        }
    }
}
