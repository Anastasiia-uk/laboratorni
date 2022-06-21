using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System;

namespace lab6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItemOpen_Click(object sender, RoutedEventArgs e)
        {
            if(ListBox.Items.Count == 19)
                ListBox.Items.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BitmapImage image = new BitmapImage(new Uri(openFileDialog.FileName));
                MainImage.Source = image;
                UpdateStatusBar(openFileDialog.FileName);
                AddListBoxItem(openFileDialog.FileName);
            }
        }

        private void UpdateStatusBar(string path)
        {
            StatusBarTextBlock.Text = path;
        }

        private void AddListBoxItem(string path)
        {
            ListBoxItem item = new ListBoxItem();
            item.Content = Path.GetFileNameWithoutExtension(path);
            item.IsSelected = true;
            item.IsEnabled = false;
            ListBox.Items.Add(item);
            Separator spr = new Separator();
            ListBox.Items.Add(spr);
        }

        private void MenuItemClose_Click(object sender, RoutedEventArgs e)
        {
            MainImage.Source = null;
            UpdateStatusBar("");
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            if (System.Windows.MessageBox.Show("Do you want to exit?",
                                "Exit",
                                MessageBoxButton.OKCancel,
                                MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                System.Windows.Application.Current.Shutdown();
            }
        }
        private void PropButton_Click(object sender, RoutedEventArgs e)
        {
            Prop prop = new Prop();
            prop.Owner = this;
            prop.Show();
        }
    }
}
