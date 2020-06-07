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

namespace HomeWork_Ado.Net_1
{
    public partial class Form1 : Form
    {
        SqlConnection connect=null;
        SqlCommand command=null;
        SqlDataReader reader=null;
        SqlConnectionStringBuilder connectString = new SqlConnectionStringBuilder();
        const string exellentStud = "select count(*) from Students s left join Groups g on g.id=s.idGroup where g.id=@Id and (s.OOPScore+s.WinFormsScore+s.ADO_NETScore)/3.>=9";
        const string looserStud = "select count(*) from Students s left join Groups g on g.id=s.idGroup where g.id=@Id and (s.OOPScore+s.WinFormsScore+s.ADO_NETScore)/3.<=4";
        public Form1()
        {
            InitializeComponent();
            connectString.DataSource = @"(localdb)\mssqllocaldb";
            connectString.InitialCatalog = "Education_Institution";
            connectString.IntegratedSecurity = true;
            exellentStudents.Checked = true;
        }

        private void infoAboutGrS_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            try
            {
                connect = new SqlConnection(connectString.ConnectionString);
                connect.Open();
                command = connect.CreateCommand();
                command.CommandText = "waitfor delay '00:00:05';select Surname,OOPScore,WinFormsScore,ADO_NETScore from Students;" +
                    "select nameGroup,curatorSurname from Groups;select stud.Surname,gr.nameGroup,cast((stud.OOPScore+stud.WinFormsScore+stud.ADO_NETScore)/3.as numeric(4,2)) Average_Ball from Students stud left join Groups gr on gr.id = stud.idGroup";
                command.BeginExecuteReader(CallBack, command);
                        //using (reader = command.ExecuteReader())
                        //{
                        //    dataGridView1.ColumnCount = reader.FieldCount;
                        //    dataGridView1.Columns[0].HeaderText = "Surname";
                        //    dataGridView1.Columns[1].HeaderText = "OOP Score";
                        //    dataGridView1.Columns[2].HeaderText = "WinForms Score";
                        //    dataGridView1.Columns[3].HeaderText = "ADO.NET Score";
                        //    while (reader.Read())
                        //        dataGridView1.Rows.Add(reader.GetString(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3));
                        //    reader.NextResult();
                        //    dataGridView2.ColumnCount = reader.FieldCount;
                        //    dataGridView2.Columns[0].HeaderText = "Name Group";
                        //    dataGridView2.Columns[1].HeaderText = "Curator Surname";
                        //    while (reader.Read())
                        //        dataGridView2.Rows.Add(reader.GetString(0), reader.GetString(1));
                        //    reader.NextResult();
                        //    dataGridView3.ColumnCount = reader.FieldCount;
                        //    dataGridView3.Columns[0].HeaderText = "Surname";
                        //    dataGridView3.Columns[1].HeaderText = "Name Group";
                        //    dataGridView3.Columns[2].HeaderText = "Average Ball";
                        //    while (reader.Read())
                        //        dataGridView3.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetDecimal(2));

                        //}
                        //reader.Close();
            }
            catch(SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CallBack(IAsyncResult result)
        {
            SqlCommand cmd =(SqlCommand)result.AsyncState;
            using (reader = cmd.EndExecuteReader(result))
            {
                dataGridView1.Invoke(new Action(() =>
                {
                    dataGridView1.ColumnCount = reader.FieldCount;
                    dataGridView1.Columns[0].HeaderText = "Surname";
                    dataGridView1.Columns[1].HeaderText = "OOP Score";
                    dataGridView1.Columns[2].HeaderText = "WinForms Score";
                    dataGridView1.Columns[3].HeaderText = "ADO.NET Score";
                }));
                while (reader.Read())
                    dataGridView1.Invoke(new Action(() => { dataGridView1.Rows.Add(reader.GetString(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3)); }));
                reader.NextResult();
                dataGridView2.Invoke(new Action(() =>
                {
                    dataGridView2.ColumnCount = reader.FieldCount;
                    dataGridView2.Columns[0].HeaderText = "Name Group";
                    dataGridView2.Columns[1].HeaderText = "Curator Surname";
                }));
                while (reader.Read())
                    dataGridView2.Invoke(new Action(() => { dataGridView2.Rows.Add(reader.GetString(0), reader.GetString(1)); }));
                reader.NextResult();
                dataGridView3.Invoke(new Action(() => 
                {
                    dataGridView3.ColumnCount = reader.FieldCount;
                    dataGridView3.Columns[0].HeaderText = "Surname";
                    dataGridView3.Columns[1].HeaderText = "Name Group";
                    dataGridView3.Columns[2].HeaderText = "Average Ball";
                }));
                
                while (reader.Read())
                    dataGridView3.Invoke(new Action(() => { dataGridView3.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetDecimal(2)); }));
            }
        }

        private void AddGroup_Click(object sender, EventArgs e)
        {
            try
            {
                using (connect = new SqlConnection(connectString.ConnectionString))
                {
                    connect.Open();
                    using (command = new SqlCommand("insert into Groups (nameGroup,curatorSurname) values (@gr,@cur)",connect))
                    {
                        command.Parameters.Add("@gr", SqlDbType.NVarChar);
                        command.Parameters["@gr"].Value = textBox1.Text;
                        command.Parameters.AddWithValue("@cur", textBox2.Text);
                        command.ExecuteNonQuery();
                    }
                }
                connect.Close();
            }
            catch(SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exellentStudents_CheckedChanged(object sender, EventArgs e)
        {
            if (exellentStudents.Checked)
                label1.Text = "Exellent Students";
            else
                label1.Text = "looser Students";
        }

        private void Find_Click(object sender, EventArgs e)
        {
            int id;
            try
            {
                using (connect = new SqlConnection(connectString.ConnectionString))
                {
                    connect.Open();
                    using (command = connect.CreateCommand())
                    {
                        command.CommandText = "select id from Groups where nameGroup=@name";
                        command.Parameters.AddWithValue("@name", textBox4.Text);
                        object tmp = command.ExecuteScalar();
                        if (tmp == null)
                        {
                            textBox3.Text = "No group found";
                            return;
                        }
                        else
                            id = (int)tmp;
                        if(exellentStudents.Checked)
                        {
                            command.CommandText = exellentStud;
                            command.Parameters.AddWithValue("@Id", id);
                            textBox3.Text = Convert.ToString((int)command.ExecuteScalar());
                        }
                        else
                        {
                            command.CommandText = looserStud;
                            command.Parameters.AddWithValue("@Id", id);
                            textBox3.Text = Convert.ToString((int)command.ExecuteScalar());
                        }
                    }
                }
                connect.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
