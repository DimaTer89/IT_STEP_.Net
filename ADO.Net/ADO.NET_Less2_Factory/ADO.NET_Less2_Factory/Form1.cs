using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;

namespace ADO.NET_Less2_Factory
{
    public partial class Form1 : Form
    {
        DbProviderFactory dbFactory;//фабрика провайдеров
        DbConnection connect = null;//подключение
        public Form1()
        {
            InitializeComponent();
            ConfigurationManager.ConnectionStrings.Cast<ConnectionStringSettings>().ToList().ForEach(s => comboBox1.Items.Add(s.Name));
            comboBox1.SelectedIndex = 0;
            //dataGridView2.DataSource = DbProviderFactories.GetFactoryClasses();
        }
        static string GetConnectionString(string name) => ConfigurationManager.ConnectionStrings
            .Cast<ConnectionStringSettings>()
            .First(srt => srt.Name == name).ConnectionString;
        static string GetProviderName(string name) => ConfigurationManager.ConnectionStrings
            .Cast<ConnectionStringSettings>()
            .First(prov => prov.Name == name).ProviderName;

        private void button1_Click(object sender, EventArgs e)
        {
            dbFactory = DbProviderFactories.GetFactory(GetProviderName(comboBox1.SelectedItem.ToString()));
            connect = dbFactory.CreateConnection();
            connect.ConnectionString = GetConnectionString(comboBox1.SelectedItem.ToString());
            try
            {
                connect.Open();
                DbCommand select = connect.CreateCommand();
                select.Connection = connect;
                select.CommandText = "waitfor delay '00:00:05';select * from Dict";
                using (DbDataReader dbData = select.ExecuteReader())
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.ColumnCount = dbData.FieldCount - 1;
                    while(dbData.Read())
                       dataGridView1.Rows.Add(dbData.GetString(1), dbData.GetString(2));
                }
                connect.Close();
            }
            catch(DbException ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                if (connect != null)
                    connect.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dbFactory = DbProviderFactories.GetFactory(GetProviderName(comboBox1.SelectedItem.ToString()));
            connect = dbFactory.CreateConnection();
            connect.ConnectionString = GetConnectionString(comboBox1.SelectedItem.ToString());
            try
            {
                connect.Open();
                DbCommand select = connect.CreateCommand();
                select.Connection = connect;
                select.CommandText = "waitfor delay '00:00:05';select * from Dict";
                ((SqlCommand)select).BeginExecuteReader(GetDataCallBack, (SqlCommand)select);
            }
            catch (DbException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void GetDataCallBack(IAsyncResult command)
        {
            SqlDataReader reader = null;
            try
            {
                SqlCommand cmd = (SqlCommand)command.AsyncState;
                reader=cmd.EndExecuteReader(command);
                dataGridView2.Invoke(new Action(() => { dataGridView2.ColumnCount = reader.FieldCount - 1; }));
                while (reader.Read())
                    dataGridView2.Invoke(new Action(()=> { dataGridView2.Rows.Add(reader.GetString(1), reader.GetString(2)); }));
                
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
