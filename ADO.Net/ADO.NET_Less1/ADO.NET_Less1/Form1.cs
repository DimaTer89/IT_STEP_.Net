using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO.NET_Less1
{
    public partial class Form1 : Form
    {
        string cnstr = ConfigurationManager.ConnectionStrings["Library"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
        }
        //Авторы
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].HeaderText = "Id";
            dataGridView1.Columns[1].HeaderText = "Name";
            dataGridView1.Columns[2].HeaderText = "LastName";
            //string connectionString = @"Data source=(localdb)\MSSQLLocalDB;Initial catalog=Library;Integrated security=true;";

            //SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
            //stringBuilder.DataSource = @"(localdb)\MSSQLLocalDB";
            //stringBuilder.InitialCatalog = @"Library";
            //stringBuilder.IntegratedSecurity = true;

            //получение строки подключения из файла конфигурации
            string cnstr = ConfigurationManager.ConnectionStrings["Library"].ConnectionString;

            //создаём подключение
            using (SqlConnection connect = new SqlConnection(cnstr))
            {
                try
                {
                    connect.Open();
                    // 1 способ 
                    SqlCommand command = new SqlCommand();
                    command.Connection = connect;
                    command.CommandText = "Select * from Authors";
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while(dataReader.Read())
                        {
                            dataGridView1.Rows.Add(dataReader["Id"],dataReader["FirstName"],dataReader["LastName"]);
                        }
                    }
                    //MessageBox.Show("OK");
                    //dataGridView1.DataSource = connect.DataSource;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString(),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);
                }
            }
        }
        //книги
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].HeaderText = "№";
            dataGridView1.Columns[1].HeaderText = "Название";
            dataGridView1.Columns[2].HeaderText = "Автор";
            dataGridView1.Columns[3].HeaderText = "Цена";
            string cnstr = ConfigurationManager.ConnectionStrings["Library"].ConnectionString;
            using (SqlConnection connect = new SqlConnection(cnstr))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand("select b.Title,a.LastName,b.Price from Books b left join Authors a on a.Id=b.AuthorId", connect);
                    int count = 1;
                    using (SqlDataReader sqlData = command.ExecuteReader())
                    {
                        while (sqlData.Read())
                        {
                            dataGridView1.Rows.Add(count,sqlData["Title"],sqlData["LastName"],sqlData["Price"]);
                            count++;
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cnstr = ConfigurationManager.ConnectionStrings["Library"].ConnectionString;
            {
                using (SqlConnection connect = new SqlConnection(cnstr))
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(@"insert into Books(Title,Pages,Price,AuthorId) values (N'Анна Каренина','500','200','1')", connect);
                    command.ExecuteNonQuery();
                }
                //using (SqlConnection delete = new SqlConnection(cnstr))
                //{
                //    delete.Open();
                //    SqlCommand deleteSQl = new SqlCommand(@"delete from Books where Id=5",delete);
                //    deleteSQl.ExecuteNonQuery();
                //}
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection insert = new SqlConnection(cnstr))
            {
                try
                {
                    insert.Open();
                    //команда поиска id автора по фамилии 
                    SqlCommand find = insert.CreateCommand();
                    find.CommandText = "select Id from Authors where LastName=@lastname";
                    //find.Parameters.AddWithValue("@lastname", textBox1.Text);
                    find.Parameters.Add("@lastname", SqlDbType.NVarChar);
                    find.Parameters["@lastname"].Value = textBox1.Text;
                    object a = find.ExecuteScalar();
                    int Id;
                    if (a != null)
                    {
                        Id = Convert.ToInt32(a);
                    }
                    else
                    {
                        SqlCommand insertAuthor = new SqlCommand("insert into Authors(LastName,FirstName) values (@lastname,@firstname)", insert);
                        insertAuthor.Parameters.AddWithValue("@lastname", textBox1.Text);
                        //insertAuthor.Parameters["@lastname"].Value = textBox1.Text;
                        insertAuthor.Parameters.AddWithValue("@firstname", textBox5.Text);
                        insertAuthor.ExecuteNonQuery();
                        Id = Convert.ToInt32(find.ExecuteScalar());
                        
                    }
                    //команда добавления книги
                    SqlCommand command = new SqlCommand(@"insert into Books(Title,Pages,Price,AuthorId) values (@title,@pages,@price,@aId)", insert);
                    command.Parameters.AddWithValue("@title", textBox2.Text);
                    command.Parameters.Add("@pages", SqlDbType.Int);
                    command.Parameters["@pages"].Value = Convert.ToInt32(textBox4.Text);
                    command.Parameters.Add("@price", SqlDbType.Money);
                    command.Parameters["@price"].Value = Convert.ToDecimal(textBox3.Text);
                    command.Parameters.Add("@aId", SqlDbType.Int);
                    command.Parameters["@aId"].Value = Id;
                    command.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //список всех авторов и список книг, которые дешевле 100$
            using (SqlConnection doubleSelect = new SqlConnection(cnstr))
            {
                try
                {
                    int n = 0;
                    doubleSelect.Open();
                    SqlCommand cmd = doubleSelect.CreateCommand();
                    cmd.CommandText = "select LastName,FirstName from Authors;select title from Books where Price<100;select * from Authors LastName where LastName like N'%о%'";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        
                        do
                        {
                            richTextBox1.Text += n==0?"Authors: ":(n==1?"\nCheap books : ":"\n Authors o : ");
                            while (reader.Read())
                            {
                                richTextBox1.Text += "\t";
                                for(int i=0;i<reader.FieldCount;i++)
                                    richTextBox1.Text += "\t"+reader[i]+"\n";
                                //richTextBox1.Text += "\nCheap books : ";
                                richTextBox1.Text += "\t";
                            }
                            n++;
                            //richTextBox1.Text += "\nCheap books : ";
                        } while (reader.NextResult());
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (SqlConnection proc = new SqlConnection(cnstr))
            {
                try
                {
                    proc.Open();
                    SqlCommand procCmd = new SqlCommand("getBooksNumber", proc);
                    procCmd.CommandType = CommandType.StoredProcedure;
                    procCmd.Parameters.AddWithValue("@AuthorId", 1);
                    //procCmd.Parameters.Add(new SqlParameter("@BookCount", SqlDbType.Int));
                    SqlParameter param = new SqlParameter("@BookCount", SqlDbType.Int);
                    param.Direction = ParameterDirection.Output;
                    procCmd.Parameters.Add(param);
                    procCmd.ExecuteNonQuery();
                    textBox6.Text = procCmd.Parameters["@BookCount"].Value.ToString();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }
        private void ProcessBan(bool thrEx,int IdAuthors,SqlConnection connection)
        {
            string lName = "";
            string fName = "";
            SqlCommand cmd = new SqlCommand("select * from Authors where Id=@IdAuthors", connection);
            cmd.Parameters.AddWithValue("@IdAuthors", IdAuthors);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    lName = reader.GetString(1);
                    fName = reader.GetString(2);
                }
                else
                    return;
            }
            //Создание объектов комманды транзакции
            SqlCommand delete = new SqlCommand("delete from Authors where Id=@aId", connection);
            delete.Parameters.AddWithValue("@aId", IdAuthors);
            SqlCommand insert = new SqlCommand("insert into BannerAuthors(LastName,FirstName) values (@lastname,@firstname)", connection);
            insert.Parameters.AddWithValue("@lastname", lName);
            insert.Parameters.AddWithValue("@firstname", fName);
            //Транзакция
            SqlTransaction sqlTransaction = null;
            try
            {
                sqlTransaction = connection.BeginTransaction();
                delete.Transaction = sqlTransaction;
                insert.Transaction = sqlTransaction;
                delete.ExecuteNonQuery();
                if(thrEx)
                {
                    throw new Exception("Ошибка, транзакция не завершена");
                }
                insert.ExecuteNonQuery();
                sqlTransaction.Commit();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                sqlTransaction.Rollback();
            }
                
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(textBox7.Text);
            using (SqlConnection connect = new SqlConnection(cnstr))
            {
                try
                {
                    connect.Open();
                    ProcessBan(true, Id, connect);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }

            }
        }
    }
}
