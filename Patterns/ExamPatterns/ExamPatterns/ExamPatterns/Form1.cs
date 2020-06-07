using ExamPatterns.AbstractFactory;
using ExamPatterns.Decorator;
using ExamPatterns.ChainOfResponsibility;
using System;
using System.Collections.Generic;
using ExamPatterns.Observer;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamPatterns
{
    public partial class Form1 : Form
    {
        List<ICafeFactory> cafeFactories;
        List<decimal> menuPrice;
        List<string> menuCafePizza;
        List<int> weightPizza;
        List<string> menuCafeBarbecue;
        List<int> weightBarbecue;
        IPriceListObserver priceList;
        void ChangesPrices()
        {
            menuPrice.Clear();
            for (int i = 0; i < menuCafePizza.Count; i++)
                menuPrice.Add(priceList.GetTotalPizzaPrice(menuCafePizza[i], weightPizza[i]));
            for (int i = 0; i < menuCafeBarbecue.Count; i++)
                menuPrice.Add(priceList.GetTotalBarbecuePrice(menuCafeBarbecue[i], weightBarbecue[0]));
        }
        string[] menu =
        {
            "Пицца с курицей, перцем и грибами ",
            "Пицца с морепродуктами и сыром ",
            "Баранина",
            "Свинина"
        };
        void ChangeTextBoxesPizza()
        {
            textBox1.Text = priceList.GetPriceCafePizza(comboBox1.Items[0].ToString());
            textBox3.Text = priceList.GetPriceCafePizza(comboBox1.Items[1].ToString());
        }
        void ChangeTextBoxesBarbecue()
        {
            textBox2.Text = priceList.GetPriceCafeBabrbecue(comboBox1.Items[0].ToString());
            textBox4.Text = priceList.GetPriceCafeBabrbecue(comboBox1.Items[1].ToString());
        }
        void MenuCaragePizza()
        {
            comboBox3.Items.Clear();
            comboBox3.Items.Add(menu[0]);
            comboBox3.SelectedIndex = 0;
        }
        void MenuArlekinoPizza()
        {
            comboBox3.Items.Clear();
            comboBox3.Items.Add(menu[1]);
            comboBox3.SelectedIndex = 0;
        }
        void MenuBarbekue(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add(menu[2]);
            comboBox.Items.Add(menu[3]);
            comboBox.SelectedIndex = 0;
        }

        public Form1()
        {
            InitializeComponent();
            comboBox2.SelectedIndex = 0;
            groupBox2.Visible = false;
            cafeFactories = new List<ICafeFactory> { new CafeGarage(), new CafeArlekino() };
            menuPrice = new List<decimal>();
            priceList = new PriceList();
            menuCafePizza = new List<string>();
            weightPizza = new List<int>();
            menuCafeBarbecue = new List<string>();
            weightBarbecue = new List<int>();
            weightBarbecue.Add(350);
            comboBox1.DataSource = cafeFactories;
            comboBox1.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            priceList.RegisterObserverble(new CafeGarage());
            priceList.RegisterObserverble(new CafeArlekino());
            priceList.AlertObserveble();
            textBox1.Text = priceList.GetPriceCafePizza(comboBox1.Items[0].ToString());
            textBox2.Text = priceList.GetPriceCafeBabrbecue(comboBox1.Items[0].ToString());
            textBox3.Text = priceList.GetPriceCafePizza(comboBox1.Items[1].ToString());
            textBox4.Text = priceList.GetPriceCafeBabrbecue(comboBox1.Items[1].ToString());
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex==1)
            {
                groupBox1.Visible = false;
                groupBox2.Visible = true;
                MenuBarbekue(comboBox4);
            }
            else
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
                if (comboBox1.SelectedIndex == 0)
                    MenuCaragePizza();
                else
                    MenuArlekinoPizza();
            }

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == 0)
                MenuCaragePizza();
            else if (comboBox1.SelectedIndex == 1 && comboBox2.SelectedIndex == 0)
                MenuArlekinoPizza();
            else if (comboBox2.SelectedIndex == 1)
                MenuBarbekue(comboBox4);
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                ICafeFactory currentFactory = (ICafeFactory)comboBox1.SelectedItem;
                IPizza currentPizza = currentFactory.CreatePizza();
                string[] pars = comboBox5.SelectedItem.ToString().Split(' ');
                if (checkBox1.Checked)
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        menuCafePizza.Add(comboBox1.Items[0].ToString());
                        menuPrice.Add(priceList.GetTotalPizzaPrice(comboBox1.Items[0].ToString(), Convert.ToInt32(pars[0])));
                        currentPizza = new PizzaChikenMushroomsPepper(currentPizza);
                    }
                    else if (comboBox1.SelectedIndex == 1)
                    {
                        menuCafePizza.Add(comboBox1.Items[1].ToString());
                        menuPrice.Add(priceList.GetTotalPizzaPrice(comboBox1.Items[1].ToString(), Convert.ToInt32(pars[0])));
                        currentPizza = new PizzaSeaFoodCheese(currentPizza);
                    }
                }
                else
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        menuCafePizza.Add(comboBox1.Items[0].ToString());
                        menuPrice.Add(priceList.GetTotalPizzaPrice(comboBox1.Items[0].ToString(), Convert.ToInt32(pars[0])));
                    }

                    else if (comboBox1.SelectedIndex == 1)
                    {
                        menuCafePizza.Add(comboBox1.Items[1].ToString());
                        menuPrice.Add(priceList.GetTotalPizzaPrice(comboBox1.Items[1].ToString(), Convert.ToInt32(pars[0])));
                    }
                }
                weightPizza.Add(Convert.ToInt32(pars[0]));
                listBox1.Items.Add(currentPizza.CreatePizza(Convert.ToInt32(pars[0])));
            }
            if(comboBox2.SelectedIndex==1)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    menuCafeBarbecue.Add(comboBox1.Items[0].ToString());
                    menuPrice.Add(priceList.GetTotalBarbecuePrice(comboBox1.Items[0].ToString(), 350));
                }
                else
                {
                    menuCafeBarbecue.Add(comboBox1.Items[1].ToString());
                    menuPrice.Add(priceList.GetTotalBarbecuePrice(comboBox1.Items[1].ToString(), 350));
                }
                ShishKebabOrder kebabArlekino = new ShishKebabCafeArlekino();
                ShishKebabOrder kebabGarage = new ShishKebabCafeGarage();
                kebabGarage.NextCafe = kebabArlekino;
                kebabGarage.ShishKebab(listBox1, comboBox4.SelectedItem.ToString(), comboBox1.SelectedIndex);
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            try
            {
                priceList.GetPizza(Convert.ToDecimal(textBox5.Text));
                priceList.AlertObserveble();
                ChangesPrices();
                ChangeTextBoxesPizza();
            }
            catch
            {
                MessageBox.Show("Неверные данные","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            try
            {
                priceList.GetBarbecue(Convert.ToDecimal(textBox6.Text));
                priceList.AlertObserveble();
                ChangesPrices();
                ChangeTextBoxesBarbecue();
            }
            catch
            {
                MessageBox.Show("Неверные данные","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Check check = new Check(listBox1, menuPrice);
            check.ShowDialog();
        }
    }
}
