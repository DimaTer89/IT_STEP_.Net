using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;

namespace WPF_Gallery
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            label.Content = DateTime.Now.ToLongTimeString();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ImageSourceConverter image = new ImageSourceConverter();
                currentImage.SetValue(Image.SourceProperty, image.ConvertFromString(((Image)sender).Tag.ToString()));
            }
            catch
            { MessageBox.Show("Blank image", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog open = new Microsoft.Win32.OpenFileDialog();
            open.Filter = ".jpg;.jpeg|*.jpg;*.jpeg;";
            ImageSourceConverter image = new ImageSourceConverter();
            try
            {
                if (open.ShowDialog() == true)
                {
                    if (image1.Source == null)
                    {
                        image1.SetValue(Image.SourceProperty, image.ConvertFromString(open.FileName));
                        image1.Tag = open.FileName;
                    }
                    else if (image2.Source == null)
                    {
                        image2.SetValue(Image.SourceProperty, image.ConvertFromString(open.FileName));
                        image2.Tag = open.FileName;
                    }
                    else if (image3.Source == null)
                    {
                        image3.SetValue(Image.SourceProperty, image.ConvertFromString(open.FileName));
                        image3.Tag = open.FileName;
                    }
                    else if (image4.Source == null)
                    {
                        image4.SetValue(Image.SourceProperty, image.ConvertFromString(open.FileName));
                        image4.Tag = open.FileName;
                    }
                    else
                        currentImage.SetValue(Image.SourceProperty, image.ConvertFromString(open.FileName));
                }
            }
            catch { MessageBox.Show("OOPS"); }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog save = new Microsoft.Win32.SaveFileDialog();
            save.Filter = ".jpg;.jpeg|*.jpg;*.jpeg;";
            try
            {
                if(save.ShowDialog()==true)
                {
                    JpegBitmapEncoder jpeg = new JpegBitmapEncoder();
                    jpeg.Frames.Add(BitmapFrame.Create(currentImage.Source as BitmapFrame));
                    using (FileStream file = new FileStream(save.FileName, FileMode.Create))
                    {
                        jpeg.Save(file);
                    }
                }
            }
            catch { }
        }
    }
}
