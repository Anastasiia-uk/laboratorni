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
using System.Windows.Shapes;
using System.Reflection;

namespace lab6
{
    /// <summary>
    /// Interaction logic for FontProp.xaml
    /// </summary>
    public partial class Prop : Window
    {
        System.Drawing.Text.InstalledFontCollection fonts = new System.Drawing.Text.InstalledFontCollection();
        public Prop()
        {
            InitializeComponent();
            Binding binding = new Binding();
            foreach (System.Drawing.FontFamily font in fonts.Families)
                FontComboBox.Items.Add(font.Name);
            ColorBgComboBox.ItemsSource = typeof(Colors).GetProperties();
            ColorFgComboBox.ItemsSource = typeof(Colors).GetProperties();
        }

        private void FontComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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
    }
}
