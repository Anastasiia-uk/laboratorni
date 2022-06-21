using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

namespace lab5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Regex regex = new Regex(@"\D");

        public MainWindow()
        {
            InitializeComponent();
        }

        //////////////////////// CHECKED ////////////////////////

        private void CheckBoxBold_Checked(object sender, RoutedEventArgs e)
        {
            MainTextBox.FontWeight = FontWeights.Bold;
        }
        private void CheckBoxItalics_Checked(object sender, RoutedEventArgs e)
        {
            MainTextBox.FontStyle = FontStyles.Italic;
        }
        private void CheckBoxUnderline_Checked(object sender, RoutedEventArgs e)
        {
            MainTextBox.TextDecorations = TextDecorations.Underline;
        }

        //////////////////////// UNCHECKED ////////////////////////

        private void CheckBoxBold_UnChecked(object sender, RoutedEventArgs e)
        {
            MainTextBox.FontWeight = FontWeights.Normal;

        }

        private void CheckBoxItalics_UnChecked(object sender, RoutedEventArgs e)
        {
            MainTextBox.FontStyle = FontStyles.Normal;

        }

        private void CheckBoxUnderline_UnChecked(object sender, RoutedEventArgs e)
        {
            MainTextBox.TextDecorations = null;

        }
        private void FontSizeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (regex.IsMatch(FontSizeTextBox.Text) || FontSizeTextBox.Text == " ")
            {
                System.Windows.MessageBox.Show("Enter only numbers!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                FontSizeTextBox.Text = "";
                FontSizeTextBox.SelectionStart = FontSizeTextBox.Text.Length;
            }
            else if(FontSizeTextBox.Text == ""){}
            else
            {
                MainTextBox.FontSize = double.Parse(FontSizeTextBox.Text);
            }
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDg = new SaveFileDialog();
            saveDg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveDg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.WriteAllText(saveDg.FileName, MainTextBox.Text);
            }
        }
        private void Exit_button_Click(object sender, RoutedEventArgs e)
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
