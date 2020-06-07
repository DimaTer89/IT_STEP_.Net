using CodeFirst.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CodeFirst
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            using (UserContext db = new UserContext())
            {
                //db.Users.Add(new User { Login = "Vasya", Password = "ssss" });
                //db.SaveChanges();
                
                dataGridView1.DataSource = db.Users.Select(us=>new { us.Id, us.Login,us.Password, us.Country.Name }).ToList();
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                //dataGridView2.ColumnCount = 2;
                //var tmpQuery = db.Countries.Include("Users").ToList().Select(c => new { c.Name, Users = c.Users.Select(m => m.Login).ToList().GetString()});
                var tmpQuery = db.Countries.Include("Users").ToList().Select(c => new { c.Name, Users = c.Users.Select(m => m.Login).Aggregate((l1,l2)=>l1+";"+l2)});
                //var tmpQuery = db.Countries.GroupBy(c => c.Name).Select(men => new { men.Key, Users = men.Select(m => m.Users.Select(chel => chel.Login)) });
                dataGridView2.DataSource = tmpQuery.ToList();
                //dataGridView2.DataSource = db.Countries.Select(c => c.Name).ToList();
                //List<string> list = new List<string>();
                //StringBuilder s = new StringBuilder();
                //foreach (var item in db.Countries)
                //{
                //    item.Users.ToList().ForEach(u => { s.Append(u.Login).Append(";"); });
                //    list.Add(s.ToString());
                //    s.Clear();
                //}
                //dataGridView2.DataSource = list;
                //dataGridView2.Columns[0].Visible = false;
                //dataGridView2.DataSource=db.Countries.Select(u => new { u.Name, Users = u.Users.Select(c => c.Login).ToList().GetString() }).ToList();
                //User user = new User { Login = "Муся", Password = "***", Country = db.Countries.FirstOrDefault() };
                //db.Users.Add(user);
                //db.SaveChanges();
                //Profile prof = new Profile { Id = user.Id, Age = 17, Weight = 80 };
                //db.Profiles.Add(prof);
                //db.SaveChanges();

            }
        }
        
    }
}
