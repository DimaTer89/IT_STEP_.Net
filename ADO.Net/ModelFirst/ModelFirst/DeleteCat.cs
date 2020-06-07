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
    public partial class DeleteCat : Form
    {
        CatsModelContainer catModel;
        public DeleteCat(CatsModelContainer catModel)
        {
            InitializeComponent();
            dataGridView1.DataSource = catModel.CatSet.Select(cats => new { cats.Id, cats.Name, cats.Age, cats.Owner.LastName }).ToList();
            dataGridView1.Columns[0].Visible = false;
            this.catModel = catModel;
        }

        private void ok_Click(object sender, EventArgs e)
        {
            int id;
            try
            {
                id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                catModel.CatSet.Remove(catModel.CatSet.First(cat => cat.Id == id));
                catModel.SaveChanges();
                dataGridView1.DataSource = catModel.CatSet.Select(cats => new { cats.Id, cats.Name, cats.Age, cats.Owner.LastName }).ToList();
                dataGridView1.Columns[0].Visible = false;
            }
            catch { }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
