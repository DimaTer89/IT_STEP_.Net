using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ADO.NET_Task_Epam
{
    public partial class Form1 : Form
    {
        BindingSource source = new BindingSource();
        const string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""db1.accdb""";
        Dictionary<int, int> listLenghtCount = new Dictionary<int, int>();
        public Form1()
        {
            InitializeComponent();
        }
        //формирование и вывод коллекции
        private void button1_Click(object sender, EventArgs e)
        {
            listLenghtCount.Clear();
            OleDbConnection cnn = null;
            OleDbCommand cmd = null;
            OleDbDataReader dtReader = null;
            try
            {
                cnn = new OleDbConnection(connectionString);
                cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT (int(abs((x2-x1)+0.5))) AS len, Count(*) AS num FROM Coordinates GROUP BY (int(abs((x2-x1)+0.5))) ORDER BY 1 ";
                cnn.Open();
                dtReader = cmd.ExecuteReader();
                while (dtReader.Read())
                {
                    listLenghtCount.Add((int)dtReader.GetDouble(0), dtReader.GetInt32(1));
                }
                //dataGridView1.RowCount = listLenghtCount.Count;
                source.DataSource = listLenghtCount;
                dataGridView1.DataSource = source;
                dataGridView1.Columns[0].HeaderText = "Длина отрезка";
                dataGridView1.Columns[1].HeaderText = "Количество отрезков";
                dtReader.Close();
                cmd.CommandText = "delete from Frequencies";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "insert into Frequencies (len,num) values(@len,@num)";
                cmd.Parameters.Add("@len", OleDbType.Integer);
                cmd.Parameters.Add("@num", OleDbType.Integer);
                foreach (var item in listLenghtCount)
                {
                    cmd.Parameters["@len"].Value = item.Key;
                    cmd.Parameters["@num"].Value = item.Value;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (dtReader != null) dtReader.Dispose();
                if (cmd != null) cmd.Dispose();
                if (cnn != null) cnn.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listLenghtCount.Clear();
            OleDbConnection cnn = null;
            OleDbCommand cmd = null;
            OleDbDataReader dtReader = null;
            try
            {
                cnn = new OleDbConnection(connectionString);
                cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Frequencies where len>num";
                cnn.Open();
                dtReader = cmd.ExecuteReader();
                while (dtReader.Read())
                {
                    listLenghtCount.Add(dtReader.GetInt32(1), dtReader.GetInt32(2));
                }
                BindingSource source1 = new BindingSource();
                source1.DataSource = listLenghtCount;
                dataGridView1.DataSource = source1;
                dataGridView1.Columns[0].HeaderText = "Длина отрезка";
                dataGridView1.Columns[1].HeaderText = "Количество отрезков";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (dtReader != null) dtReader.Dispose();
                if (cmd != null) cmd.Dispose();
                if (cnn != null) cnn.Dispose();
            }
        }
    }
}
