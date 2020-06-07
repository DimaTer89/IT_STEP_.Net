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

namespace HomeWorkWPF_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random;
        public MainWindow()
        {
            InitializeComponent();
            random = new Random();
        }

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            button.Margin = new Thickness(random.Next(-410, 410), random.Next(-267, 267), 0,0);
            int label = random.Next(0, 4);
            button.Content = (label == 0) ? "Press here" : (label == 1) ? "Too slow" : (label == 2) ? "Try once again" : "Catch me";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Congratulations, you caught me. Game over", "Congratulations", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
