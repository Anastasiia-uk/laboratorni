using System.IO;
using System.Windows.Forms;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Input;

namespace lab8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string Extension { get; set; } = "txt";
        string fileName = "";
        DialogResult saveFileDialogResult;
        public MainWindow()
        {
            InitializeComponent();
            ChangeSaveButtonsStatus();
            TextBlockStatusBar.Text = "Line " + 1 + ", Char " + 1;
        }
        private void MainTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            ChangeSaveButtonsStatus();
            int row = MainTextBox.GetLineIndexFromCharacterIndex(MainTextBox.CaretIndex);
            int col = MainTextBox.CaretIndex - MainTextBox.GetCharacterIndexFromLineIndex(row);
            TextBlockStatusBar.Text = "Line " + (row + 1) + ", Char " + (col + 1);
            TextBlockStatusBar.Text += $"\t{fileName}";
        }
        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "TXT (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MainTextBox.Text = File.ReadAllText(openFileDialog.FileName);
                fileName = openFileDialog.FileName;
                TextBlockStatusBar.Text += openFileDialog.FileName;
            }
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (fileName != "")
                File.WriteAllText(fileName, MainTextBox.Text);
            else
                SaveFile();
        }
        private void SaveAs_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFile();
        }
        private void Exit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (SaveActive())
            {
                MessageBoxResult res = System.Windows.MessageBox.Show("Do you want to save changes?",
                    "Exit",
                    MessageBoxButton.YesNoCancel,
                    MessageBoxImage.Question);
                if (res == MessageBoxResult.No)
                {
                    System.Windows.Application.Current.Shutdown();
                }
                else if (res == MessageBoxResult.Yes)
                {
                    SaveFile();
                    if (saveFileDialogResult == System.Windows.Forms.DialogResult.OK)
                        System.Windows.Application.Current.Shutdown();
                }
            }else
            {
                if (System.Windows.MessageBox.Show("Do you want to exit?",
                    "Exit",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                    System.Windows.Application.Current.Shutdown();
            }
        }
        private void New_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBoxResult res = System.Windows.MessageBox.Show("Do you want to save changes?",
               "Save changes",
               MessageBoxButton.YesNoCancel,
               MessageBoxImage.Question);
            if (res == MessageBoxResult.No)
            {
                MainTextBox.Text = "";
                fileName = "";
            }
            else if (res == MessageBoxResult.Yes)
            {
                SaveFile();
                if (saveFileDialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    MainTextBox.Text = "";
                    fileName = "";
                }
            }
        }
        private void SaveFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = $"{Extension} (*.{Extension})|*.{Extension}|All files (*.*)|*.*";
            saveFileDialogResult = saveFileDialog.ShowDialog();
            if (saveFileDialogResult == System.Windows.Forms.DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, MainTextBox.Text);
                fileName = saveFileDialog.FileName;
            }
        }
        private void ChangeSaveButtonsStatus()
        {
            if (MainTextBox.Text.Length == 0)
                NewMenuItem.IsEnabled = NewButton.IsEnabled = SaveButton.IsEnabled = SaveAsButton.IsEnabled = SaveMenuItem.IsEnabled = SaveAsMenuItem.IsEnabled = false;
            else
                NewMenuItem.IsEnabled = NewButton.IsEnabled = SaveButton.IsEnabled = SaveAsButton.IsEnabled = SaveMenuItem.IsEnabled = SaveAsMenuItem.IsEnabled = true;
        }
        private bool SaveActive()
        {
            if (SaveButton.IsEnabled == true)
                return true;
            else
                return false;
        }
        private void PropButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> listExt = new List<string> { "txt", "xml","rtf", "dot", "doc" };
            Prop prop = new Prop(listExt);
            prop.Owner = this;
            prop.Show();
        }
    }
}
