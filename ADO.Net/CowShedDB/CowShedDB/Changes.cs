using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CowShedDB
{
    public partial class Changes : Form
    {
        public Changes(DataSet set)
        {
            InitializeComponent();
            dataGridView1.DataSource = set.Tables[0];
        }
    }
}
