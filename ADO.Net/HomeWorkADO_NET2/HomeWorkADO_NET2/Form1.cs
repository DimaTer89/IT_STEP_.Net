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
using System.IO;
using System.Drawing.Imaging;
using System.Data.Common;

namespace HomeWorkADO_NET2
{
    public partial class Form1 : Form
    {
        DataSet set = new DataSet();
        SqlDataAdapter adapter;
        const string connectString = @"Data source=(localdb)\mssqllocaldb;Initial catalog=Dictionary;Integrated security=true";
        SqlCommandBuilder cmdBuilder = new SqlCommandBuilder();
        Random randomNumber;
        int row;
        public Form1()
        {
            InitializeComponent();
            trainingBox.Visible = false;
            editingBox.Visible = false;
            adapter = new SqlDataAdapter("select * from Dictionary", connectString);
            adapter.Fill(set,"Dictionary");
            dataGridView1.DataSource = set.Tables["Dictionary"];
            SqlCommand delete = new SqlCommand();
            delete.Connection = adapter.SelectCommand.Connection;
            delete.CommandText = "delete from Dictionary where id=@id";
            delete.Parameters.Add("@id", SqlDbType.Int);
            delete.Parameters["@id"].SourceColumn = "id";
            SqlCommand insert = new SqlCommand();
            insert.Connection = adapter.SelectCommand.Connection;
            insert.CommandText = @"insert into Dictionary (englishWord,russianWord,picture) values( @eW,@rW,@picture)";
            insert.Parameters.Add("@englishWord", SqlDbType.NVarChar);
            insert.Parameters.Add("@russianWord", SqlDbType.NVarChar);
            insert.Parameters.Add("@picture", SqlDbType.VarBinary);
            insert.Parameters["@englishWord"].SourceColumn = "englishWord";
            insert.Parameters["@russianWord"].SourceColumn = "russianWord";
            insert.Parameters["@picture"].SourceColumn = "picture";
            SqlCommand update = new SqlCommand();
            update.Connection = adapter.SelectCommand.Connection;
            update.CommandText = "update Dictionary set englishWord=@eW,russianWord=@rW,picture=@pic where id=@id";
            update.Parameters.Add("@eW", SqlDbType.NVarChar);
            update.Parameters.Add("@rW", SqlDbType.NVarChar);
            update.Parameters.Add("@pic", SqlDbType.VarBinary);
            update.Parameters.Add("@id", SqlDbType.Int);
            update.Parameters["@eW"].SourceColumn = "englishWord";
            update.Parameters["@rW"].SourceColumn = "russianWord";
            update.Parameters["@pic"].SourceColumn = "picture";
            update.Parameters["@id"].SourceColumn = "id";
            update.Parameters["@id"].SourceVersion = DataRowVersion.Original;
            dataGridView1.Columns[0].Visible = false;
            cmdBuilder.DataAdapter = adapter;
            randomNumber = new Random();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void trainingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editingBox.Visible)
                editingBox.Visible = false;
            row = randomNumber.Next(1, set.Tables[0].Rows.Count);
            trainingBox.Visible = true;
            label1.Text = set.Tables["Dictionary"].Rows[row]["englishWord"].ToString();
            pictureBox1.Image = null;
            textBox1.Text = "";
        }

        private void editingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trainingBox.Visible)
                trainingBox.Visible = false;
            editingBox.Visible = true;
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void saveChanges_Click(object sender, EventArgs e)
        {
            adapter.Update(set, "Dictionary");
            MessageBox.Show("Changes successfully passed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                int countRow = 1;
                if (dataGridView1.SelectedRows[0].Cells[0].Value != null)
                    countRow = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                try
                {
                    if (set.Tables[0].Rows[countRow - 1]["picture"] != null)
                    {
                        byte[] buf = (byte[])set.Tables[0].Rows[countRow - 1]["picture"];
                        ms.Write(buf, 0, buf.Length);
                        Image image = Image.FromStream(ms);
                        pictureBox2.Image = image;
                    }
                }
                catch{ }
            }
            catch { }
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            string text = set.Tables["Dictionary"].Rows[row]["russianWord"].ToString();
            //MessageBox.Show(text);
            try
            {
                if (text==textBox1.Text)
                    textBox1.ForeColor = Color.Green;
                else
                    textBox1.ForeColor = Color.Red;
            }
            catch { MessageBox.Show("Wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
        }

        private void next_Click(object sender, EventArgs e)
        {
            row = randomNumber.Next(1, set.Tables["Dictionary"].Rows.Count);
            label1.Text = set.Tables["Dictionary"].Rows[row]["englishWord"].ToString();
            pictureBox1.Image = null;
            textBox1.Text = "";
        }

        private void pictureHelp_Click(object sender, EventArgs e)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                try
                {
                    byte[] buf = (byte[])set.Tables[0].Rows[row]["picture"];
                    ms.Write(buf, 0, buf.Length);
                    Image image = Image.FromStream(ms);
                    pictureBox1.Image = image;
                }
                catch { }
            }
            catch { }
        }

        private void addPicture_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    Image image = Image.FromFile(openFileDialog1.FileName);
                    pictureBox2.Load(openFileDialog1.FileName);
                    MemoryStream ms = new MemoryStream();
                    image.Save(ms, ImageFormat.Jpeg);
                    ms.Flush();
                    ms.Seek(0, SeekOrigin.Begin);
                    BinaryReader binReader = new BinaryReader(ms);
                    byte[] imageFile = binReader.ReadBytes((int)ms.Length);
                    set.Tables[0].Rows[dataGridView1.CurrentRow.Index]["picture"] = imageFile;
                }
                catch { }
            }
        }

        private void cancelChanges_Click(object sender, EventArgs e)
        {
            set.Clear();
            adapter.Fill(set, "Dictionary");
        }
    }
}
