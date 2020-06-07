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

namespace WPF_HomeWork3_Tereshchenko
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Style calculateStyle = new Style(typeof(Button));
            Style authorStyle = new Style(typeof(Button));
            calculateStyle.Setters.Add(new Setter { Property = Control.FontFamilyProperty, Value = new FontFamily("Segoe UI Bold")});
            authorStyle.Setters.Add(new Setter { Property = Control.FontFamilyProperty, Value = new FontFamily("Times New Roman Bold") });
            calculateStyle.Setters.Add(new Setter { Property = Control.FontSizeProperty, Value = 20.0 });
            authorStyle.Setters.Add(new Setter { Property = Control.FontSizeProperty, Value = 18.0 });
            calculateStyle.Setters.Add(new Setter { Property = Control.ForegroundProperty, Value = new SolidColorBrush(Colors.DarkMagenta) });
            authorStyle.Setters.Add(new Setter { Property = Control.ForegroundProperty, Value = new SolidColorBrush(Colors.DarkSlateBlue) });
            caclulateButton.Style = calculateStyle;
            authorButton.Style = authorStyle;
        }
        private void Calculate_Click(object sender,RoutedEventArgs args)
        {
            try
            {
                Rectangle rect = (Rectangle)Resources["myRectangle"];
                square.Text = Convert.ToString(rect.Squre);
                perimeter.Text = Convert.ToString(rect.Perimeter);
            }
            catch
            {
                MessageBox.Show("Wrong data", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Author_Click(object sender, RoutedEventArgs args)
        {
            try
            {
                AboutAuthor aboutAuthor = new AboutAuthor();
                aboutAuthor.ShowDialog();
            }
            catch { }
        }
    }
}
