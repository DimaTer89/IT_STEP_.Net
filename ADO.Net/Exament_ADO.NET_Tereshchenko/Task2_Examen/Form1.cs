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
using System.Configuration;

namespace Task2_Examen
{
    public partial class Form1 : Form
    {
        SqlDataAdapter dataDogs;
        DataSet setDogs=new DataSet();
        string connect = ConfigurationManager.ConnectionStrings["DogShelter"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
            dataDogs = new SqlDataAdapter("select d.Id, d.Nickname,k.NameKind,d.Height from Dogs d left join Kinds k on k.Id=d.KindId", connect);
            dataDogs.Fill(setDogs, "DogShelter");
            setDogs.Tables[0].PrimaryKey =new DataColumn[] { setDogs.Tables[0].Columns["Id"] };
            dataGridView1.DataSource = setDogs.Tables[0];
        }

        private void removeDog_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow row = setDogs.Tables[0].Rows.Find(Convert.ToInt32(textBox1.Text));
                row.Delete();
                SqlCommand delete = new SqlCommand();
                delete.Connection = dataDogs.SelectCommand.Connection;
                delete.CommandText = "delete from Dogs where Id=@id";
                delete.Parameters.Add("@id", SqlDbType.Int);
                delete.Parameters["@id"].SourceColumn = "Id";
                dataDogs.DeleteCommand = delete;
                dataDogs.Update(setDogs,"DogShelter");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
