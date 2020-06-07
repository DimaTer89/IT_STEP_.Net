using EasyWeightLoss.DAL.EFRepositories;
using EasyWeightLoss.DAL.Interfaces;
using EasyWeightLoss.DAL.Model;
using EasyWeightLoss.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyWeightLoss.DAL.DaperRepositories;
using EasyWeightLoss.DAL.ADORepositories;

namespace EasyWeightLoss
{
    public partial class EasyWeightLoss : Form
    {
        UserManager userManager;
        EntryForm entry = new EntryForm();
        RegistrationForm regis = new RegistrationForm();
        User currentUser;
        ProductManager productManager;
        public EasyWeightLoss()
        {
            InitializeComponent();
            SqlConnectionStringBuilder connect = new SqlConnectionStringBuilder();
            connect.DataSource = @"(localdb)\mssqllocaldb";
            connect.InitialCatalog = "WeightLoss";
            connect.AttachDBFilename = Application.StartupPath + @"\WeightLoss.mdf";
            connect.IntegratedSecurity = true;
            IRepositories<User> users = new UserRepository(connect.ConnectionString);
            IRepositories<DailyCalories> calories = new CaloriesRepositiry(connect.ConnectionString);
            IRepositories<Product> productRep = new ADOProductRepository(connect.ConnectionString);
            IRepositories<User> us = new ADOUserRepository(connect.ConnectionString);
            //dataGridView1.DataSource = calories.Get();
            //userManager = new UserManager(users, calories);
            productManager = new ProductManager(productRep);
            dataGridView1.DataSource = productManager.GetAll();
            userManager = new UserManager(us, calories);
            //productManager = new ProductManager(new (connect.ConnectionString));
            //dataGridView1.AutoGenerateColumns = false;
            //dataGridView1.RowTemplate.Height = 40;
            ////добавляем столбец для выбора продуктов
            //DataGridViewComboBoxColumn cbc = new DataGridViewComboBoxColumn();
            //List<Product> products = productManager.GetAll().ToList();
            //cbc.Name = "ProductList";
            //cbc.HeaderText = "Съеденные продукты";
            //cbc.DataSource = products;
            //cbc.DataPropertyName = "Name";
            //cbc.DisplayMember = "Name";
            //cbc.ValueMember = "Id";
            //cbc.Width = 200;
            //dataGridView1.Columns.Add(cbc);
            ////столбец для ввода данных
            //DataGridViewTextBoxColumn cbt = new DataGridViewTextBoxColumn();
            //cbt.Name = "Weight";
            //cbt.HeaderText = "Вес(г)";
            //cbt.Width = 100;
            //dataGridView1.Columns.Add(cbt);
            //dataGridView1.Font = new Font("Segou UI", 10);
            //dataGridView1.RowCount = 5;
            ////dataGridView1.DataSource = userManager.GetAll();
            //Visible = false;
        }

        private void EasyWeightLoss_Load(object sender, EventArgs e)
        {
            DialogResult dialogResult = entry.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                if (!userManager.Validate(entry.Login, entry.Password))
                {
                    entry.ErrorMessage = "Error data ";
                    EasyWeightLoss_Load(this, e);
                }
                else
                {
                    currentUser = userManager.FindByLogin(entry.Login);
                    Visible = true;
                    Text = currentUser.Login;
                    CalorieRange range = userManager.GetNorm(currentUser);
                    textBox1.Text = range.Min+" - "+range.Max;
                }
            }
            else if(dialogResult==DialogResult.Yes)
            {
                dialogResult=regis.ShowDialog();
                entry.Visible = false;
                if (dialogResult==DialogResult.OK)
                {
                    if(userManager.IsExist(regis.User.Login))
                    {
                        entry.ErrorMessage = "Error data ";
                    }
                    else
                    {
                        try
                        {
                            userManager.Create(regis.User);
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    EasyWeightLoss_Load(this, e);
                }
                else
                {
                    userManager.Dispose();
                    Close();
                }
            }
            else
            {
                userManager.Dispose();
                Close();
            }
            //Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateProduct product = new CreateProduct();
            if(product.ShowDialog()==DialogResult.OK)
            {
             
                    Product tmp = new Product { Name = product.Product_Name, EnergyValue = product.Energy_Value };
                    //MessageBox.Show(tmp.Name+" "+tmp.EnergyValue.ToString());
                    productManager.Create(tmp);
                
            }
            
        }

        private void productCalorieTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = productManager.GetAll();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = userManager.GetAll();
        }
    }
}
