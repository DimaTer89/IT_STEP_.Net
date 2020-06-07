using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDZ_3._2
{
    public partial class Form2 : Form
    {
        public Form2(List<Rabotnik>list)
        {
            InitializeComponent();
            dataGridView1.Font = new Font("Segoe UI", 11);
            if (list.Count > 0)
            {
                dataGridView1.RowCount = list.Count;
                for (int i = 0; i < list.Count; i++)
                {
                    dataGridView1[0, i].Value = list[i].Surname;
                    dataGridView1[1, i].Value = list[i].MiddleSalary().ToString("f2");
                }
            }
        }
        
    }
}
