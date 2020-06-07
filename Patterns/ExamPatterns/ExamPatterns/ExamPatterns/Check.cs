using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamPatterns
{
    public partial class Check : Form
    {
        public Check(ListBox listBox,List<decimal> menuList)
        {
            InitializeComponent();
            for(int i=0;i<listBox.Items.Count;i++)
            {
                listBox1.Items.Add(listBox.Items[i] + "     " + menuList[i]);
            }
            listBox1.Items.Add("Итого : " + "                          " + menuList.Sum());
        }
    }
}
