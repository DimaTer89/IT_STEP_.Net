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

namespace CowShedDB
{
    public partial class Form1 : Form
    {
        DataSet cowSet = new DataSet();
        SqlDataAdapter cowAdapter;
        SqlCommandBuilder cmdBuilder;
        const string connectString = @"Data source=(localdb)\mssqllocaldb;Initial catalog=Cowshed;Integrated security=true";
        public Form1()
        {
            InitializeComponent();
            cowAdapter = new SqlDataAdapter("select * from Herd", connectString);
            cowAdapter.Fill(cowSet,"Herd");
            dataGridView1.DataSource = cowSet.Tables[0];
            SqlCommand delete = new SqlCommand();
            delete.Connection = cowAdapter.SelectCommand.Connection;
            delete.CommandText = "delete from Herd where Id=@id";
            delete.Parameters.Add("@id", SqlDbType.Int);
            delete.Parameters["@id"].SourceColumn = "Id";
            SqlCommand insert = new SqlCommand();
            insert.Connection = cowAdapter.SelectCommand.Connection;
            insert.CommandText = "insert into Herd (nameCow,milkFeeds) values(@nameCow,@milkFeeds)";
            insert.Parameters.Add("@nameCow", SqlDbType.NVarChar);
            insert.Parameters.Add("@milkFeeds", SqlDbType.Int);
            insert.Parameters[0].SourceColumn = "nameCow";
            insert.Parameters[1].SourceColumn = "milkFeeds";
            SqlCommand update = new SqlCommand();
            update.Connection = cowAdapter.SelectCommand.Connection;
            update.CommandText = "update Herd set nameCow=@nc,milkFeeds=@mf where Id=@id";
            update.Parameters.Add("@nc", SqlDbType.NVarChar);
            update.Parameters.Add("@mf", SqlDbType.Int);
            update.Parameters.Add("@id", SqlDbType.Int);
            update.Parameters[0].SourceColumn = "nameCow";
            update.Parameters[1].SourceColumn = "milkFeeds";
            update.Parameters[2].SourceColumn = "Id";
            update.Parameters[2].SourceVersion = DataRowVersion.Original;
            cmdBuilder = new SqlCommandBuilder();
            cmdBuilder.DataAdapter = cowAdapter;
            dataGridView1.Columns[0].Visible = false;
        }

        private void save_Click(object sender, EventArgs e)
        {
            if(cowSet.HasChanges())
            {
                DataSet set = new DataSet();
                set = cowSet.GetChanges();
                Changes changes = new Changes(set);
                if (changes.ShowDialog() == DialogResult.OK)
                    cowAdapter.Update(cowSet, "Herd");
                else
                    cowSet.RejectChanges();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cowSet.RejectChanges();
        }
    }
}
