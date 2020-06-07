using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsDZ_5
{
    public partial class Form1 : Form
    {
        
        static string pathPattern = @"\w{1}:{1}\\{1}(\w+\\{1})*";
        Regex pathRegex = new Regex(pathPattern);
        public Form1()
        {
            InitializeComponent();
            treeView1.ImageList = imageList1;
            listView1.SmallImageList = imageList2;
            listView1.ContextMenuStrip = contextMenuStrip1;
            label1.Enabled = false;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.Enabled = false;
            richTextBox1.AllowDrop = true;
            richTextBox1.DragDrop += RichTextBox1_DragDrop;
            radioButton1.Checked = true;
        }

        private void RichTextBox1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                richTextBox1.Clear();
                textBox2.Text = listView1.Items[listView1.SelectedIndices[0]].Text;
                //не смог придумать имя переменной...
                StringBuilder @string = new StringBuilder();
                if (textBox1.Text[textBox1.Text.Length - 1] == '\\')
                    @string.Append(textBox1.Text).Append(listView1.Items[listView1.SelectedIndices[0]].Text);
                else
                    @string.Append(textBox1.Text).Append('\\').Append(listView1.Items[listView1.SelectedIndices[0]].Text);
                using (StreamReader reader = new StreamReader(@string.ToString(),Encoding.Default))
                {
                    while (!reader.EndOfStream)
                    {
                        richTextBox1.Text += reader.ReadToEnd();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Wrong address", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

            }
        }

        void BuildTree(string Path,TreeNode node)
        {
            try
            {
                DirectoryInfo curDir = new DirectoryInfo(Path);
                DirectoryInfo[] dir = curDir.GetDirectories();
                foreach (DirectoryInfo item in dir)
                {
                    TreeNode tmp = new TreeNode(item.Name,1,1);
                    node.Nodes.Add(tmp);
                    BuildTree(item.FullName, tmp);
                }
                FileInfo[] files = curDir.GetFiles();
                foreach (FileInfo item in files)
                {
                    TreeNode curNode = new TreeNode(item.Name,0,0);
                    node.Nodes.Add(curNode);
                }
            }
            catch { }
        }
        void DefaultTreeView()
        {
            string str = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Application.StartupPath).ToString()).ToString()).ToString()).ToString()).ToString();
            TreeNode node = new TreeNode(str, 2, 2);
            textBox1.Text = str;
            treeView1.Nodes.Add(node);
            BuildTree(str, node);
            ViewList(str);
        }
        void ViewList(string Path)
        {
            try
            {
                DirectoryInfo curDir = new DirectoryInfo(Path);
                DirectoryInfo[] dirs = curDir.GetDirectories();
                foreach (DirectoryInfo item in dirs)
                {
                    listView1.Items.Add(item.Name, 1);
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(item.CreationTime.ToShortDateString());
                }
                foreach (FileInfo item in curDir.GetFiles())
                {
                    listView1.Items.Add(item.Name, 0);
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(item.CreationTime.ToShortDateString());
                }
            }
            catch { }
        }
        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left&&listView1.GetItemAt(e.X,e.Y)!=null)
            {
                listView1.DoDragDrop(listView1.GetItemAt(e.X, e.Y), DragDropEffects.Move);
            }
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void smallIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.SmallIcon;
        }

        private void largeIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;
        }

        private void tileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.Tile;
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.List;
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.Details;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Enabled = false;
            textBox3.Enabled = false;
            textBox2.Text = "";
            textBox3.Text = "";
            richTextBox1.Clear();
            treeView1.Nodes.Clear();
            DefaultTreeView();
        }
               
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            listView1.Items.Clear();
            textBox1.Text = e.Node.FullPath;
            textBox1.Text += '\\';
            ViewList(textBox1.Text);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            treeView1.Nodes.Clear();
            textBox1.Text = "";
            textBox2.Text = "";
            label1.Enabled = true;
            textBox3.Enabled = true;
            textBox3.Focus();
        }
        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (pathRegex.IsMatch(textBox3.Text))
                {
                    treeView1.Nodes.Clear();
                    listView1.Items.Clear();
                    textBox1.Text = textBox3.Text;
                    TreeNode node = new TreeNode(textBox3.Text, 2, 2);
                    treeView1.Nodes.Add(node);
                    BuildTree(textBox3.Text, node);
                    ViewList(textBox3.Text);
                }
                else
                    MessageBox.Show("Wrong address", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

            }
        }
    }
}
