using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_HomeWork4_Tereshchenko
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ResourceDictionary dakrSkin = new ResourceDictionary() { Source = new Uri("DarkSkin.xaml",UriKind.Relative)};
        ResourceDictionary notdarkSkin;
        public MainWindow()
        {
            InitializeComponent();
            notdarkSkin = Resources.MergedDictionaries[0];
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Resources.MergedDictionaries[0] = dakrSkin;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Resources.MergedDictionaries[0] = notdarkSkin;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double weight1 = Convert.ToDouble(weight.Text);
                double height1 = Convert.ToDouble(height.Text)/100;
                double imt = weight1 / (height1 * height1);
                rec.Text = (imt < 18) ? "Вес недостаточен, опасно для здоровья" : (imt >= 18 && imt <= 20) ? "Вес слегка снижен, неопасно для здоровья" : (imt >= 20.1 && imt <= 25.9) ? "Вес нормальный" : (imt >= 26 && imt <= 27.9) ? " Вес излишний" : (imt >= 28 && imt <= 30.9) ? "Ожирение 1 степени" : (imt >= 31 && imt <= 35.9) ? "Ожирение 2 степени" : (imt >= 36 && imt <= 40.9) ? "Ожирение 3 степени" : "Ожирение 4 степени";
            }
            catch { }
        }
        private SolidColorBrush BackgraoundColor()
        {
            Color color = new Color();
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                color = Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
            }
            return new SolidColorBrush(color);
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            SolidColorBrush brush = BackgraoundColor();
            if (brush != null)
                stackPanel.Background = brush;
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                label1.FontFamily = new FontFamily(fd.Font.Name);
                label1.FontSize = fd.Font.Size;
                label1.FontWeight = fd.Font.Bold ? FontWeights.Bold : FontWeights.Regular;
                label1.FontStyle = fd.Font.Italic ? FontStyles.Italic : FontStyles.Normal;
                label2.FontFamily = new FontFamily(fd.Font.Name);
                label2.FontSize = fd.Font.Size;
                label2.FontWeight = fd.Font.Bold ? FontWeights.Bold : FontWeights.Regular;
                label2.FontStyle = fd.Font.Italic ? FontStyles.Italic : FontStyles.Normal;
                label3.FontFamily = new FontFamily(fd.Font.Name);
                label3.FontSize = fd.Font.Size;
                label3.FontWeight = fd.Font.Bold ? FontWeights.Bold : FontWeights.Regular;
                label3.FontStyle = fd.Font.Italic ? FontStyles.Italic : FontStyles.Normal;
                weight.FontFamily = new FontFamily(fd.Font.Name);
                weight.FontSize = fd.Font.Size;
                weight.FontWeight = fd.Font.Bold ? FontWeights.Bold : FontWeights.Regular;
                weight.FontStyle = fd.Font.Italic ? FontStyles.Italic : FontStyles.Normal;
                height.FontFamily = new FontFamily(fd.Font.Name);
                height.FontSize = fd.Font.Size;
                height.FontWeight = fd.Font.Bold ? FontWeights.Bold : FontWeights.Regular;
                height.FontStyle = fd.Font.Italic ? FontStyles.Italic : FontStyles.Normal;
                rec.FontFamily = new FontFamily(fd.Font.Name);
                rec.FontSize = fd.Font.Size;
                rec.FontWeight = fd.Font.Bold ? FontWeights.Bold : FontWeights.Regular;
                rec.FontStyle = fd.Font.Italic ? FontStyles.Italic : FontStyles.Normal;
            }
        }
    }
}
