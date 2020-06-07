using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsExamExample
{
    public partial class Form1 : Form
    {
        int interval;
        List<Dog> dogs = new List<Dog>();
        BindingSource source = new BindingSource();
        //TimeSpan span = DateTime.Now.Minute + 5;
        bool flag;
        int ind;
        private string datePatern = @"\b[0-9]{4}\b";
        private void ChangeChart()
        {
            var porody = from dog in dogs group dog by dog.Kind into newDog select new { Name = newDog.Key, Count = newDog.Count() };
            chart1.DataSource = porody;
            chart1.Series[0].XValueMember = "Name";
            chart1.Series[0].YValueMembers = "Count";
            chart1.Invalidate();
        }
        public Form1()
        {
            InitializeComponent();
            toolStripStatusLabel2.Text = DateTime.Now.ToShortDateString() + "  ";
            toolStripStatusLabel3.Text = DateTime.Now.ToLongTimeString();
            radioButton1.Checked = true;
            interval = 360;
            //dateNow = DateTime.Now.ToShortTimeString();
            ind = 0;
            timer1.Start();
            source.DataSource = dogs;
            dataGridView1.DataSource = source;
            dataGridView1.Font = new Font("Segoe UI", 12, FontStyle.Regular, GraphicsUnit.Point);
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
            comboBox1.SelectedIndex = 0;
            openFileDialog1.InitialDirectory = Application.StartupPath;
            DriveInfo[] driveInfo = DriveInfo.GetDrives();
            foreach (var item in driveInfo)
            {
                comboBox2.Items.Add(item);
            }
            comboBox2.SelectedIndex = 0;
        }
        void BuildTree(string Path, TreeNode node)
        {
            try
            {
                DirectoryInfo curDir = new DirectoryInfo(Path);
                DirectoryInfo[] dir = curDir.GetDirectories();
                foreach (DirectoryInfo item in dir)
                {
                    TreeNode tmp = new TreeNode(item.Name, 1, 1);
                    node.Nodes.Add(tmp);
                    BuildTree(item.FullName, tmp);
                }
                FileInfo[] files = curDir.GetFiles();
                foreach (FileInfo item in files)
                {
                    TreeNode curNode = new TreeNode(item.Name, 2, 2);
                    node.Nodes.Add(curNode);
                }
            }
            catch { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            --interval;
            toolStripStatusLabel2.Text = DateTime.Now.ToShortDateString() + "  ";
            toolStripStatusLabel3.Text = DateTime.Now.ToLongTimeString();
            if(interval==0)
            {
                MessageBox.Show("Buy dog food", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                interval = 360;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            source.Add(new Dog());
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                dataGridView1.BackgroundColor = colorDialog1.Color;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                dataGridView1.Font = fontDialog1.Font;
        }
        private void ClearColorGriedView()
        {
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                dataGridView1[i, ind].Style.ForeColor = Color.Black;
        }
        private void FillDataGriedView()
        {
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                dataGridView1[i, ind].Style.ForeColor = Color.Red;
        }
        private int MinimumAge()
        {
            int Age;
            Age = dogs[0].AgeDog();
            for (int i = 0; i < dogs.Count; i++)
            {
                if (dogs[i].AgeDog() < Age)
                {
                    Age = dogs[i].AgeDog();
                    ind = i;
                }
            }
            return ind;
        }
        private int MaximumAge()
        {
            int Age;
            Age = dogs[0].AgeDog();
            for (int i = 0; i < dogs.Count; i++)
            {
                if (dogs[i].AgeDog() > Age)
                {
                    Age = dogs[i].AgeDog();
                    ind = i;
                }
            }
            return ind;
        }
        private void button3_Click(object sender, EventArgs e)
        {
           
            ClearColorGriedView();
            ind = 0;
            if (comboBox1.SelectedIndex == 0)
            {
                ind = MinimumAge();
                FillDataGriedView();
            }
            else
            {
                ind = MaximumAge();
                FillDataGriedView();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count>0)
                source.Remove(source[dataGridView1.SelectedRows[0].Index]);
            ChangeChart();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AuthorForm authorForm = new AuthorForm();
            authorForm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            TreeNode node;
            //MessageBox.Show(textBox1.Focused.ToString());
            if (!flag)
            {
                node = new TreeNode(comboBox2.SelectedItem.ToString());
                treeView1.Nodes.Add(node);
                BuildTree(comboBox2.SelectedItem.ToString(), node);
                textBox1.Text = "";
            }
            else
            {
                node = new TreeNode(textBox1.Text);
                treeView1.Nodes.Add(node);
                BuildTree(textBox1.Text, node);
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            flag = true;
        }

        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
            flag = false;
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            source.Clear();
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader reader = new StreamReader(openFileDialog1.FileName, Encoding.Default))
                    {
                        while (!reader.EndOfStream)
                        {
                            string[] str = reader.ReadLine().Split(';');
                            source.Add(new Dog { NickName = str[0], Kind = str[1], YearOfBirthday = Convert.ToInt32(str[2]) });
                        }
                    }
                }
                ChangeChart();
            }
            catch{ MessageBox.Show("Wrong file", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1); }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ChangeChart();
            //MessageBox.Show(datePatern+"  "+dataGridView1[2, e.RowIndex].Value.ToString());
            Regex dateRegex = new Regex(datePatern);
            if(dataGridView1.SelectedCells[0].ColumnIndex==2&&dateRegex.IsMatch(dataGridView1[2, e.RowIndex].Value.ToString())==false)
            { }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                chart1.Visible = false;
            else
                chart1.Visible = true;
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            dataGridView1[2, e.RowIndex].Value = 0;
            MessageBox.Show("Wrong date", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            source.Clear();
            try
            {

                using (StreamReader reader = new StreamReader(e.Node.FullPath, Encoding.Default))
                {
                    while (!reader.EndOfStream)
                    {
                        string[] str = reader.ReadLine().Split(';');
                        source.Add(new Dog { NickName = str[0], Kind = str[1], YearOfBirthday = Convert.ToInt32(str[2]) });
                    }
                }
                ChangeChart();
            }
            catch { MessageBox.Show("Wrong file", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1); }
        }
    }
}
