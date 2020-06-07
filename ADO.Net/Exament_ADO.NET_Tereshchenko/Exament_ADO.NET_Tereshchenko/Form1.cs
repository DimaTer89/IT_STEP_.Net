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

namespace Exament_ADO.NET_Tereshchenko
{
    public partial class Form1 : Form
    {
        SqlConnection connect;
        SqlConnectionStringBuilder connectBuilder;
        SqlDataReader dataReader;
        public Form1()
        {
            InitializeComponent();
            connectBuilder = new SqlConnectionStringBuilder();
            connectBuilder.DataSource = @"(localdb)\mssqllocaldb";
            connectBuilder.InitialCatalog = "DogShelter";
            connectBuilder.AttachDBFilename = Application.StartupPath + @"\DogShelter.mdf";
            connectBuilder.IntegratedSecurity = true;
            using (connect = new SqlConnection(connectBuilder.ConnectionString))
            {
                connect.Open();
                using (SqlCommand cmd = connect.CreateCommand())
                {
                    cmd.CommandText = "select d.Nickname,k.NameKind,d.Height from Dogs d left join Kinds k on k.Id=d.KindId";
                    using (dataReader = cmd.ExecuteReader())
                    {
                        dataGridView1.ColumnCount = 3;
                        dataGridView1.Columns[0].HeaderText = "Кличка";
                        dataGridView1.Columns[1].HeaderText = "Порода";
                        dataGridView1.Columns[2].HeaderText = "Высота в холке";
                        while (dataReader.Read())
                            dataGridView1.Rows.Add(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetInt32(2));
                    }
                }
            }
        }

        private void findCountDogsKind_Click(object sender, EventArgs e)
        {
            using (connect = new SqlConnection(connectBuilder.ConnectionString))
            {
                connect.Open();
                using (SqlCommand cmd = new SqlCommand("select count(*) from Dogs d left join Kinds k on k.Id=d.KindId where k.NameKind=@kind", connect))
                {
                    try
                    {
                        cmd.Parameters.Add("@kind", SqlDbType.NVarChar);
                        cmd.Parameters[0].Value = textBox1.Text;
                        countDogs.Text = Convert.ToString(cmd.ExecuteScalar());
                    }
                    catch
                    {
                        MessageBox.Show("ERROR", "WRONG DATA", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            using (connect = new SqlConnection(connectBuilder.ConnectionString))
            {
                connect.Open();
                try
                {
                    using (SqlCommand cmd = connect.CreateCommand())
                    {
                        cmd.CommandText = "waitfor delay '00:00:10';select d.Nickname,k.NameKind,d.Height from Dogs d left join Kinds k on k.Id=d.KindId where d.Height>30";
                        Task<SqlDataReader> task = cmd.ExecuteReaderAsync();
                        using (dataReader = await task)
                        {
                            dataGridView2.ColumnCount = 3;
                            dataGridView2.Columns[0].HeaderText = "Кличка";
                            dataGridView2.Columns[1].HeaderText = "Порода";
                            dataGridView2.Columns[2].HeaderText = "Высота в холке";
                            while (await dataReader.ReadAsync())
                                dataGridView2.Rows.Add(task.Result.GetString(0), task.Result.GetString(1), task.Result.GetInt32(2));
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("ERROR", " ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }
    }
}
