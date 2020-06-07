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
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace WPF_Examen
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ResourceDictionary darkSkin = new ResourceDictionary() {Source=new Uri("Dark Skin.xaml", UriKind.Relative) };
        ResourceDictionary lightSkin;
        List<Rate> rates = new List<Rate>();
        HttpWebRequest req;
        HttpWebResponse resp;
        StreamReader reader;
        double scale = 0;
        double currencyRate = 0;
        const string currency = "http://www.nbrb.by/API/ExRates/Rates?onDate=DateTime.Now.ToShortDateString()&Periodicity=0";
        public MainWindow()
        {
            InitializeComponent();
            lightSkin = Resources.MergedDictionaries[0];
            ExchangeRates();
            scale = ((Rate)comboBox.SelectedItem).Scale;
            currencyRate = ((Rate)comboBox.SelectedItem).Currency;
        }
        private void ExchangeRates()
        {
            string result;
            try
            {
                req = (HttpWebRequest)WebRequest.Create(currency);
                resp = (HttpWebResponse)req.GetResponse();
                reader = new StreamReader
                                   (
                                    resp.GetResponseStream(),
                                    Encoding.UTF8
                                   );
                result = reader.ReadLine();
                string[] tmp = result.Split('{', '}');
                foreach (var item in tmp)
                {
                    string[] tmp2 = item.Split(',');
                    if (tmp2.Length > 4)
                    {
                        string[] abbString = tmp2[2].Split('"', '"');
                        string[] scaleString = tmp2[3].Split('"', '"');
                        string[] nameString = tmp2[4].Split('"', '"');
                        string[] rateString = tmp2[5].Split('"', '"', ':');
                        string abb = abbString[3].Replace('"', ' ').Trim();
                        double scale = Convert.ToDouble(scaleString[2].Replace(':', ' ').TrimStart());
                        string name = nameString[3];
                        double rate = Convert.ToDouble(rateString[3].Replace('.', ','));
                        Rate tmpCur = new Rate
                        {
                            ShortName = abb,
                            Scale = scale,
                            FullName = name,
                            Currency = rate
                        };
                        rates.Add(tmpCur);
                    }
                }
                comboBox.ItemsSource = rates;
                comboBox.DisplayMemberPath = "FullName";
                comboBox.SelectedIndex = 0;
                resp.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
        private SolidColorBrush BackGround()
        {
            System.Windows.Media.Color color = new System.Windows.Media.Color();
            ColorDialog colorDialog = new ColorDialog();
            if(colorDialog.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                color = System.Windows.Media.Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
            }
            return new SolidColorBrush(color);
        }
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            scale = ((Rate)comboBox.SelectedItem).Scale;
            currencyRate = ((Rate)comboBox.SelectedItem).Currency;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                resultText.Text = String.Format("{0:f0}", Convert.ToDouble(inputBox.Text) / (currencyRate / scale));
            }
            catch(FormatException)
            {
                System.Windows.MessageBox.Show("Введите правильные данные", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Resources.MergedDictionaries[0] = lightSkin;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Resources.MergedDictionaries[0] = darkSkin;
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            SolidColorBrush brush = BackGround();
            if (brush != null)
                tabControl.Background = brush;
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                label1.FontFamily = new System.Windows.Media.FontFamily(fd.Font.Name);
                label1.FontSize = fd.Font.Size;
                label1.FontWeight = fd.Font.Bold ? FontWeights.Bold : FontWeights.Regular;
                label1.FontStyle = fd.Font.Italic ? FontStyles.Italic : FontStyles.Normal;
                inputBox.FontFamily = new System.Windows.Media.FontFamily(fd.Font.Name);
                inputBox.FontSize = fd.Font.Size;
                inputBox.FontWeight = fd.Font.Bold ? FontWeights.Bold : FontWeights.Regular;
                inputBox.FontStyle = fd.Font.Italic ? FontStyles.Italic : FontStyles.Normal;
                comboBox.FontFamily = new System.Windows.Media.FontFamily(fd.Font.Name);
                comboBox.FontSize = fd.Font.Size;
                comboBox.FontWeight = fd.Font.Bold ? FontWeights.Bold : FontWeights.Regular;
                comboBox.FontStyle = fd.Font.Italic ? FontStyles.Italic : FontStyles.Normal;
                resultText.FontFamily = new System.Windows.Media.FontFamily(fd.Font.Name);
                resultText.FontSize = fd.Font.Size;
                resultText.FontWeight = fd.Font.Bold ? FontWeights.Bold : FontWeights.Regular;
                resultText.FontStyle = fd.Font.Italic ? FontStyles.Italic : FontStyles.Normal;
                convert.FontFamily = new System.Windows.Media.FontFamily(fd.Font.Name);
                convert.FontSize = fd.Font.Size;
                convert.FontWeight = fd.Font.Bold ? FontWeights.Bold : FontWeights.Regular;
                convert.FontStyle = fd.Font.Italic ? FontStyles.Italic : FontStyles.Normal;
                
            }
        }
    }
}
