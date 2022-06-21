using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Net;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace lab3
{
    public partial class MainWindow : Window
    {
        bool downloadPending = false;
        Downloader downloader = null;
        string downloadMode = "File";
        public MainWindow()
        {
            InitializeComponent();
        }

        void GetProgress(int percent, long bytesReceived)
        {
            Dispatcher.Invoke(delegate ()
            {
                DownloadingProgressBar.Value = percent;
                InfoAboutDownloadingTextBLock.Text = $"Downloaded {((double)bytesReceived / 1048576).ToString("#.# Mb")}\n{percent}%/100%";
                if (DownloadingProgressBar.Value == 100)
                {
                    downloadPending = false;
                }
            });
        }
        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            string fileName = saveFileName();
            if (fileName != null)
            {
                Uri uri = new Uri(LinkToDownloadTextBox.Text);

                downloader = new Downloader(uri, fileName);

                DownloadButton.IsEnabled = false;
                downloader.ProgressHandler = GetProgress;
                if (downloadMode == "File")
                {
                    InfoAboutDownloadingTextBLock.Text = "Pending...";
                    downloader.DownloadFile();
                    downloadPending = true;
                }
                else
                    downloader.DownloadPage();
            }
            else
                MessageBox.Show("Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

        }
    
        string saveFileName()
        {
            var saveDg = new System.Windows.Forms.SaveFileDialog();
            saveDg.Filter = "All Files (*.*)|(*.*)";
            if (saveDg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                return saveDg.FileName;
            else
                return null;
        }

        private void LinkToDownloadTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex urlRegex = new Regex(@"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$");
            if (urlRegex.IsMatch(LinkToDownloadTextBox.Text))
                DownloadButton.IsEnabled = true;
            else
                DownloadButton.IsEnabled = false;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Forms.DialogResult dr = System.Windows.Forms.MessageBox.Show("Exit?", "Exit", System.Windows.Forms.MessageBoxButtons.YesNo);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                if (downloadPending)
                {
                    downloader.CancelDownloadingFile();
                }
            }
            else
                e.Cancel = true;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            downloadMode = ((ComboBoxItem)ComboBox.SelectedItem).Content.ToString();
        }
    }
}
