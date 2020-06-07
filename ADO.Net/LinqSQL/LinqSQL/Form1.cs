using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
using System.IO;


namespace LinqSQL
{
    public partial class Form1 : Form
    {
        const string connectString = @"Data source=(localdb)\mssqllocaldb;Initial catalog=Monkies;Integrated security=true";
        MonkeysDataContext dataBase;
        StreamWriter writer;
        public Form1()
        {
            InitializeComponent();
            dataBase = new MonkeysDataContext(connectString);
            //Table<Monkey> monkeys = dataBase.GetTable<Monkey>();
            dataGridView1.DataSource = dataBase.Monkeys;
            writer = new StreamWriter("log.dat");
            dataBase.Log = writer;
        }
        //до 10 лет
        private void youngMonkeys_Click(object sender, EventArgs e)
        {
            //var youngQuery = from monkey in dataBase.Monkeys where monkey.Age < 10 select monkey;
            var youngQuery = dataBase.Monkeys.Where(monkey => monkey.Age < 10);//.Select(monkey=>new {Name=monkey.Name,Kind=monkey.Vid,Age=monkey.Age });
            dataGridView1.DataSource = youngQuery.ToList();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            writer.Close();
        }
        //сохранить изменения
        private void saveChanges_Click(object sender, EventArgs e)
        {
            dataBase.SubmitChanges();
        }

        private void showDataBase_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataBase.Monkeys;
        }

        private void byBreed_Click(object sender, EventArgs e)
        {
            //var byBreed = from monkey in dataBase.Monkeys group monkey by monkey.Vid into gr select new { Name = gr.Key, AverageAge = gr.Average(mon => mon.Age) }; 
            var byBreed = dataBase.Monkeys.GroupBy(monkey=>monkey.Vid).Select(monkey=>new { Name = monkey.Key, AverageAge = monkey.Average(monk => monk.Age) });
            dataGridView1.DataSource = byBreed.ToList();
        }

        private void monkeysOverTen_Click(object sender, EventArgs e)
        {
            var olderQuery = dataBase.Monkeys.Where(monkey => monkey.Age >10);//.Select(monkey=>new {Name=monkey.Name,Kind=monkey.Vid,Age=monkey.Age });
            dataGridView1.DataSource = olderQuery.ToList();
        }
    }
}
