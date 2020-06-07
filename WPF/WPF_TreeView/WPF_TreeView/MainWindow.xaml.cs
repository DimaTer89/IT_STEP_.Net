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
using System.Windows.Forms;
using System.IO;

namespace WPF_TreeView
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FolderBrowserDialog folderDialog = new FolderBrowserDialog();
        TreeViewItem root = new TreeViewItem();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            progressBar.Value = 0;
            treeView.Items.Clear();
            root.Items.Clear();
            if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                root.Foreground = new SolidColorBrush(Colors.DarkCyan);
                treeView.Visibility = Visibility.Visible;
                progressBar.Visibility = Visibility.Visible;
                image.Visibility = Visibility.Collapsed;
                Title = folderDialog.SelectedPath;
                string[] titleName=folderDialog.SelectedPath.Split('\\');
                root.Header = titleName[titleName.Length-1];
                treeView.Items.Add(root);
                BuildTree(folderDialog.SelectedPath,root);
                root.IsExpanded = true;
            }
        }
        private void BuildTree(string path, TreeViewItem node)
        {
            try
            {
                DirectoryInfo info = new DirectoryInfo(path);
                DirectoryInfo[] infoDir = info.GetDirectories();
                foreach (DirectoryInfo item in infoDir)
                {
                    TreeViewItem newItem = new TreeViewItem();
                    newItem.Tag = item;
                    newItem.Header = item.Name;
                    newItem.Foreground = new SolidColorBrush(Colors.DarkCyan);
                    newItem.Items.Add(item);
                    node.Items.Add(newItem);
                    BuildTree(item.FullName, newItem);
                }
                progressBar.Value++;
                FileInfo[] files = info.GetFiles();
                foreach (FileInfo file in files)
                {
                    TreeViewItem newFile = new TreeViewItem();
                    newFile.Tag = "Имя файла: "+ file.Name+"\nДата создания файла: "+file.CreationTime+"\nРазмер файла(кБ) : "+file.Length;
                    newFile.Header = file.Name;
                    newFile.Foreground = new SolidColorBrush(Colors.DarkOliveGreen);
                    newFile.Selected += NewFile_Selected;
                    node.Items.Add(newFile);
                }

            }
            catch { }
        }

        private void NewFile_Selected(object sender, RoutedEventArgs e)
        {
            popupText.Text = ((TreeViewItem)sender).Tag.ToString();           
            popup.IsOpen = true;
        }

       
    }
}
