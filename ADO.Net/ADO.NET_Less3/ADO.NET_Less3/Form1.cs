using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO.NET_Less3
{
    public partial class Form1 : Form
    {
        SqlConnection connect;
        const string stringConnect = @"Data source=(localdb)\mssqllocaldb;Initial catalog=Library;Integrated security=true;MultipleActiveResultSets=True";
        public Form1()
        {
            InitializeComponent();
            using (connect = new SqlConnection(stringConnect))
            {
                connect.Open();
                using (SqlCommand cmd = new SqlCommand("select Id,LastName,FirstName from Authors;select AuthorId,Title,Price from Books;select b.Title,a.LastName,a.FirstName, b.Price from Books b left join Authors a on a.Id=b.AuthorId", connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dataGridView1.ColumnCount = reader.FieldCount;
                        dataGridView1.Columns[0].HeaderText = "ID";
                        dataGridView1.Columns[1].HeaderText = "Фамилия";
                        dataGridView1.Columns[2].HeaderText = "Имя";
                        while (reader.Read())
                            dataGridView1.Rows.Add(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                        reader.NextResult();
                        dataGridView2.ColumnCount = reader.FieldCount;
                        dataGridView2.Columns[0].HeaderText = "ID";
                        dataGridView2.Columns[1].HeaderText = "Название";
                        dataGridView2.Columns[2].HeaderText = "Цена";
                        while (reader.Read())
                            dataGridView2.Rows.Add(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2));
                        reader.NextResult();
                        dataGridView3.ColumnCount = reader.FieldCount;
                        dataGridView3.Columns[0].HeaderText = "Название";
                        dataGridView3.Columns[1].HeaderText = "Фамилия";
                        dataGridView3.Columns[2].HeaderText = "Имя";
                        dataGridView3.Columns[3].HeaderText = "Цена";
                        while (reader.Read())
                            dataGridView3.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDecimal(3));
                    }
                }
                connect.Close();
            }
        }
        [MTAThread]
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (connect = new SqlConnection(stringConnect))
                {
                    connect.Open();
                    SqlCommand cmd1 = connect.CreateCommand();
                    cmd1.CommandText = "waitfor delay '00:00:05';select count(*) from Authors where FirstName=N'Иван' or FirstName='Ivan'";
                    SqlCommand cmd2 = connect.CreateCommand();
                    cmd2.CommandText = "waitfor delay '00:00:05';select avg(Price) from Books where Pages>150";
                    WaitHandle[] handles = new WaitHandle[2];
                    try
                    {
                        IAsyncResult res1 = cmd1.BeginExecuteReader();
                        handles[0] = res1.AsyncWaitHandle;
                        IAsyncResult res2 = cmd2.BeginExecuteReader();
                        handles[1] = res2.AsyncWaitHandle;
                        if (WaitHandle.WaitAll(handles))
                        {
                            SqlDataReader reader = cmd1.EndExecuteReader(res1);
                            if (reader.Read())
                                 textBox2.Text = Convert.ToString(reader.GetInt32(0));
                            reader = cmd2.EndExecuteReader(res2);
                            if (reader.Read())
                                 textBox1.Text = reader[0].ToString();
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
