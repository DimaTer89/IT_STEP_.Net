using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModelFirst
{
    public partial class Statictic : Form
    {
        public Statictic(CatsModelContainer catsModel)
        {
            InitializeComponent();
            BindingSource source = new BindingSource();
            source.DataSource = catsModel.CatSet.GroupBy(own => own.Owner.LastName).Select(own => new { Name = own.Key, Count = own.Count() }).ToList();
            chart1.DataSource = source;
            chart1.Series[0].XValueMember = "Name";
            chart1.Series[0].YValueMembers = "Count";
        }
    }
}
