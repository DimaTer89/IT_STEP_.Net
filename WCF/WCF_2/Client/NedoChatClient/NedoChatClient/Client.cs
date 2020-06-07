using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NedoChatClient.ServiceReference;

namespace NedoChatClient
{
    public partial class Client : Form
    {
        MessageContractClient message;
        public Client()
        {
            InitializeComponent();
            message = new MessageContractClient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text=="")
                MessageBox.Show("Empty name", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            else
                richTextBox2.AppendText(message.PrintMessage(new ServiceReference.Message { UserName = textBox2.Text, Text = textBox1.Text, DateTime = DateTime.Now }));
        }
    }
}
