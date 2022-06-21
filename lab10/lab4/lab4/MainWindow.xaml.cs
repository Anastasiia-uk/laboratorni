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

namespace lab4
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

        private void Change_button_Click(object sender, RoutedEventArgs e)
        {
            if (LeftTextBox.Text == "" && RightTextBox.Text == "")
            {
                MessageBox.Show("At least one field must contain text!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                string buf = LeftTextBox.Text;
                LeftTextBox.Text = RightTextBox.Text;
                RightTextBox.Text = buf;
            }
        }

        private void Exit_button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?",
                                "Exit",
                                MessageBoxButton.OKCancel,
                                MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                System.Windows.Application.Current.Shutdown();
            }
        }

        private void ChangeFontPropButton_Click(object sender, RoutedEventArgs e)
        {
            FontProp fontProp = new FontProp();
            fontProp.Owner = this;
            fontProp.Show();
        }
    }
}
