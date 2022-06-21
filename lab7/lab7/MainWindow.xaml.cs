using System.Windows;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace lab7
{
    public partial class MainWindow : Window
    {
        public static string Extension { get; set; }
        BinaryFormatter formatter = new BinaryFormatter();
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(BankPayment));
        Regex regexNum = new Regex(@"\D");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (FieldsEmpt())
            {
                System.Windows.MessageBox.Show("Fill in all the fields");
            }
            else
            {
                BankPayment bp = new BankPayment(
                    SenderTextBox.Text,
                    RecipientTextBox.Text,
                    double.Parse(SumTextBox.Text),
                    PruposeOfPaymentTextBox.Text);
                if (ComboBoxForm.SelectionBoxItem.ToString() == "BIN" || Extension == "BIN")
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.DefaultExt = "dat";
                    saveFileDialog.Filter = "dat files (*.dat)|*.dat";
                    if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        SerializeToBin(bp, saveFileDialog.FileName);
                }
                else if (ComboBoxForm.SelectionBoxItem.ToString() == "XML" || Extension == "XML")
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.DefaultExt = "xml";
                    saveFileDialog.Filter = "xml files (*.xml)|*.xml";
                    if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        SerializeToXml(bp, saveFileDialog.FileName);
                }else
                    System.Windows.MessageBox.Show("Choose extension");
            }
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "xml files (*.xml)|*.xml|dat files (*.dat)|*.dat";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (Path.GetExtension(openFileDialog.FileName) == ".dat")
                {
                    DeserializeToBin(openFileDialog.FileName);
                }
                else if (Path.GetExtension(openFileDialog.FileName) == ".xml")
                {
                    DeserializeToXml(openFileDialog.FileName);
                }
            }
        }
        public void printData(BankPayment bankPayment)
        {
            SenderTextBox.Text = bankPayment.Sender;
            RecipientTextBox.Text = bankPayment.Recipient;
            SumTextBox.Text = bankPayment.Sum.ToString();
            PruposeOfPaymentTextBox.Text = bankPayment.PruposeOfPayment;
            System.Windows.MessageBox.Show(
                "Date of payment: " + bankPayment.PaymentCreationDate,
                "Date of payment",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
//======================================SerializeBin======================================//
        public void SerializeToBin(BankPayment bp, string pathToBinFile)
        {
            using (FileStream fs = new FileStream(pathToBinFile, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, bp);
            }
        }
        public void DeserializeToBin(string pathToBinFile)
        {
            using (FileStream fs = new FileStream(pathToBinFile, FileMode.OpenOrCreate))
            {
                BankPayment newPayment = (BankPayment)formatter.Deserialize(fs);
                printData(newPayment);
            }
        }
//======================================SerializeXml======================================//
        public void SerializeToXml(BankPayment bp, string pathToXamlFile)
        {
            using (FileStream fs = new FileStream(pathToXamlFile, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, bp);
            }
        }
        public void DeserializeToXml(string pathToXamlFile)
        {
            using (FileStream fs = new FileStream(pathToXamlFile, FileMode.OpenOrCreate))
            {
                BankPayment newPayment = (BankPayment)xmlSerializer.Deserialize(fs);
                printData(newPayment);
            }
        }
//======================================TextBoxTextChanged======================================//
        private void SumTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (regexNum.IsMatch(SumTextBox.Text))
            {
                System.Windows.MessageBox.Show("Enter only numbers!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                SumTextBox.Text = "";
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            SenderTextBox.Text = "";
            RecipientTextBox.Text = "";
            SumTextBox.Text = "";
            PruposeOfPaymentTextBox.Text = "";
        }
        public bool FieldsEmpt()
        {
            if (SenderTextBox.Text == "" ||
                RecipientTextBox.Text == "" ||
                SumTextBox.Text == "" ||
                PruposeOfPaymentTextBox.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void PropButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> listExt = new List<string> {"BIN", "XML"};
            Prop prop = new Prop(listExt);
            prop.Owner = this;
            prop.Show();
        }
    }
}