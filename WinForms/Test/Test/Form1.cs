using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        int ind=0;
        int count = 0;
        public Form1()
        {
            InitializeComponent();
            listView1.View = View.List;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0)
                listView1.Items.Add(textBox1.Text);
            else
            {
                ind = listView1.SelectedIndices[0];
                listView1.Items.Insert(ind,textBox1.Text);
                ind = 0;
                count = 0;
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && listView1.SelectedIndices.Count > 0)
            {
                count = 1;
                ind = listView1.SelectedIndices[0];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            if (node == null)
                treeView1.Nodes.Add(textBox1.Text);
            else
                node.Nodes.Add(textBox1.Text);
        }
    }
}
