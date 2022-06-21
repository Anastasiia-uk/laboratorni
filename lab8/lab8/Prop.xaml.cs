using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Reflection;

namespace lab8
{
    /// <summary>
    /// Interaction logic for FontProp.xaml
    /// </summary>
    public partial class Prop : Window
    {
        System.Drawing.Text.InstalledFontCollection fonts = new System.Drawing.Text.InstalledFontCollection();
        public Prop(List<string> listExt)
        {
            InitializeComponent();
            Binding binding = new Binding();
            foreach (System.Drawing.FontFamily font in fonts.Families)
                FontComboBox.Items.Add(font.Name);
            ColorBgComboBox.ItemsSource = typeof(Colors).GetProperties();
            ColorFgComboBox.ItemsSource = typeof(Colors).GetProperties();
            foreach (var ext in listExt)
                FileExComboBox.Items.Add(ext);
        }

        private void FontComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Owner.Resources.Remove("fontFamily");
            this.Owner.Resources.Add("fontFamily", new FontFamily(FontComboBox.SelectedItem.ToString()));
            this.Owner.FontFamily = new FontFamily(FontComboBox.SelectedItem.ToString());
        }

        private void ColorBgComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Owner.Background = new SolidColorBrush((Color)(ColorBgComboBox.SelectedItem
                                                            as PropertyInfo).GetValue(null, null));

        }
        private void ColorFgComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Owner.Resources.Remove("foregroundColor");
            this.Owner.Resources.Add("foregroundColor",
                new SolidColorBrush((Color)(ColorFgComboBox.SelectedItem
                                        as PropertyInfo).GetValue(null, null)));
        }
        private void FileExComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainWindow.Extension = FileExComboBox.SelectedItem.ToString();
        }
    }
}
