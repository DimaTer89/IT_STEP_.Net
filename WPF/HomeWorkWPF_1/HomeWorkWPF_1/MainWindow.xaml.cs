using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HomeWorkWPF_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int size_matrix = 9;
        public MainWindow()
        {
            InitializeComponent();
        }
       private void Validate(object sender,RoutedEventArgs args)
       {
            try
            {
                if (((TextBox)sender).Text == "")
                    return;
                Convert.ToDouble(((TextBox)sender).Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+" Значение заменено на 0", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                ((TextBox)sender).Text = "0";
            }
       }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double num1 = (Convert.ToDouble(a11.Text) * Convert.ToDouble(a22.Text) * Convert.ToDouble(a33.Text) + Convert.ToDouble(a12.Text) * Convert.ToDouble(a23.Text) * Convert.ToDouble(a31.Text) + Convert.ToDouble(a13.Text) * Convert.ToDouble(a21.Text) * Convert.ToDouble(a32.Text));
                double num2 = (Convert.ToDouble(a13.Text) * Convert.ToDouble(a22.Text) * Convert.ToDouble(a31.Text) + Convert.ToDouble(a12.Text) * Convert.ToDouble(a21.Text) * Convert.ToDouble(a33.Text) + Convert.ToDouble(a11.Text) * Convert.ToDouble(a23.Text) * Convert.ToDouble(a32.Text));
                rezult.Content = (num1 - num2).ToString("f4");
            }
            catch
            {
                MessageBox.Show("Не все значения заполнены.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}