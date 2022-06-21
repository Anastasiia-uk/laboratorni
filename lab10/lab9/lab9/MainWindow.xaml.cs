using System.Windows;
using System.Windows.Input;
using System.IO;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;
using System.Collections.Generic;

namespace lab9
{
    public partial class MainWindow : Window
    {
        public static string Extension { get; set; } = "jpg";
        string fileName = "";
        DialogResult saveFileDialogResult;
        string editingMode = "";

        Line line;
        Rectangle rect;
        Ellipse ellipse;

        Brush brushColor = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        public MainWindow()
        {
            InitializeComponent();
            ChangeSaveButtonsStatus();

        }
        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG)|*.bmp;*.jpg;*.gif; *.tif; *.png";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var bmi = new BitmapImage();
                bmi.BeginInit();
                bmi.CacheOption = BitmapCacheOption.OnLoad;
                bmi.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                bmi.UriSource = new Uri(openFileDialog.FileName);
                bmi.EndInit();
                MainImage.Source = bmi;
                TextBlockStatusBar.Text += openFileDialog.FileName;
                ChangeSaveButtonsStatus();
                fileName = openFileDialog.FileName;
            }
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (fileName != "")
            {
                int marg = int.Parse(inkCanvas.Margin.Left.ToString());
                RenderTargetBitmap rtb =
                        new RenderTargetBitmap((int)this.inkCanvas.ActualWidth - marg,
                                (int)this.inkCanvas.ActualHeight - marg, 0, 0,
                            PixelFormats.Default);
                rtb.Render(this.inkCanvas);
                BmpBitmapEncoder encoder = new BmpBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(rtb));
                FileStream fileStream = new FileStream(fileName, FileMode.Create);
                encoder.Save(fileStream);
                fileStream.Close();
            }
            else
                SaveFile();
        }
        private void SaveAs_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFile();
        }
        private void Exit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (SaveButton.IsEnabled == true)
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
            }
            else
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
                inkCanvas.Strokes.Clear();
                inkCanvas.Children.Clear();
                TextBlockStatusBar.Text = fileName = "";
            }
            else if (res == MessageBoxResult.Yes)
            {
                SaveFile();
                if (saveFileDialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    inkCanvas.Strokes.Clear();
                    inkCanvas.Children.Clear();
                    TextBlockStatusBar.Text = fileName = "";
                }

            }
        }
        private void SaveFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = $"{Extension} files (*.{Extension})|*.{Extension}";
            saveFileDialogResult = saveFileDialog.ShowDialog();
            if (saveFileDialogResult == System.Windows.Forms.DialogResult.OK)
            {
                int marg = int.Parse(inkCanvas.Margin.Left.ToString());
                RenderTargetBitmap rtb =
                        new RenderTargetBitmap((int)this.inkCanvas.ActualWidth - marg,
                                (int)this.inkCanvas.ActualHeight - marg, 0, 0,
                            PixelFormats.Default);
                rtb.Render(this.inkCanvas);
                BmpBitmapEncoder encoder = new BmpBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(rtb));
                FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create);
                encoder.Save(fileStream);
                fileStream.Close();
            }
        }
        private void ChangeSaveButtonsStatus()
        {
            if (inkCanvas.Children.Count > 1 || inkCanvas.Strokes.Count > 0 || MainImage.Source != null)
                NewMenuItem.IsEnabled = NewButton.IsEnabled = SaveButton.IsEnabled =
                    SaveAsButton.IsEnabled = SaveMenuItem.IsEnabled = SaveAsMenuItem.IsEnabled = true;
            else
                NewMenuItem.IsEnabled = NewButton.IsEnabled = SaveButton.IsEnabled =
                    SaveAsButton.IsEnabled = SaveMenuItem.IsEnabled = SaveAsMenuItem.IsEnabled = false;
        }

        private void inkCanvas_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ChangeSaveButtonsStatus();
            var curpos = e.MouseDevice.GetPosition(inkCanvas);
            int px = (int)curpos.X;
            int py = (int)curpos.Y;
            TextBlockStatusBar.Text = $"X: {px}, Y: {py}\t{fileName}";
            switch (editingMode)
            {
                case "line":
                    if (line != null)
                    {
                        line.X2 = px;
                        line.Y2 = py;
                    }
                    break;
                case "rect":
                    if(rect != null)
                    {
                        rect.Width = px;
                        rect.Height = py;
                    }
                    break;
                case "ell":
                    if(ellipse != null)
                    {
                        ellipse.Width = px;
                        ellipse.Height = py;
                    }
                    break;
            }
        }

        private void inkCanvas_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            TextBlockStatusBar.Text = fileName;
        }

        private void PointButton_Click(object sender, RoutedEventArgs e)
        {
            editingMode = "";
            inkCanvas.EditingMode = System.Windows.Controls.InkCanvasEditingMode.Ink;
        }

        private void ColorButton_Click(object sender, RoutedEventArgs e)
        {
            if (ColorPicker.Visibility == Visibility.Visible)
                ColorPicker.Visibility = Visibility.Hidden;
            else
                ColorPicker.Visibility = Visibility.Visible;
        }
        private void BrushButton_Click(object sender, RoutedEventArgs e)
        {
            if (BrushPicker.Visibility == Visibility.Visible)
                BrushPicker.Visibility = Visibility.Hidden;
            else
                BrushPicker.Visibility = Visibility.Visible;
        }
        private void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<System.Windows.Media.Color?> e)
        {
            inkCanvas.DefaultDrawingAttributes.Color = (Color)ColorPicker.SelectedColor;
        }
        private void BrushPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            brushColor = new SolidColorBrush((Color)BrushPicker.SelectedColor);
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            editingMode = "";
            inkCanvas.EditingMode = System.Windows.Controls.InkCanvasEditingMode.Select;
        }

        private void LineButton_Click(object sender, RoutedEventArgs e)
        {
            editingMode = "line";
            inkCanvas.EditingMode = InkCanvasEditingMode.None;
        }
        private void RectButton_Click(object sender, RoutedEventArgs e)
        {
            editingMode = "rect";
            inkCanvas.EditingMode = InkCanvasEditingMode.None;
        }
        private void EllipseButton_Click(object sender, RoutedEventArgs e)
        {
            editingMode = "ell";
            inkCanvas.EditingMode = InkCanvasEditingMode.None;
        }
        private void inkCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            switch (editingMode)
            {
                case "line":
                    line = null;
                    break;
                case "rect":
                    rect = null;
                    break;
                case "ell":
                    ellipse = null;
                    break;
            }
        }
        private void inkCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            switch (editingMode)
            {
                case "line":
                    {
                        line = new Line();
                        var pos = Mouse.GetPosition(inkCanvas);
                        line.X1 = pos.X;
                        line.Y1 = pos.Y;
                        line.X2 = pos.X;
                        line.Y2 = pos.Y;
                        line.Stroke = new SolidColorBrush(inkCanvas.DefaultDrawingAttributes.Color);
                        inkCanvas.Children.Add(line);
                    }

                    break;
                case "rect":
                    {
                        rect = new Rectangle();
                        var pos = Mouse.GetPosition(inkCanvas);
                        rect.Margin = new Thickness(pos.X, pos.Y, 0, 0);
                        rect.Width = pos.X;
                        rect.Height = pos.Y;
                        rect.Fill = brushColor;                        
                        rect.Stroke = new SolidColorBrush(inkCanvas.DefaultDrawingAttributes.Color);
                        inkCanvas.Children.Add(rect);

                    }
                    break;
                case "ell":
                    {
                        ellipse = new Ellipse();
                        var pos = Mouse.GetPosition(inkCanvas);
                        ellipse.Margin = new Thickness(pos.X, pos.Y, 0, 0);
                        ellipse.Width = pos.X;
                        ellipse.Height = pos.Y;
                        ellipse.Fill = brushColor;
                        ellipse.Stroke = new SolidColorBrush(inkCanvas.DefaultDrawingAttributes.Color);
                        inkCanvas.Children.Add(ellipse);
                    }
                    break;
            }
        }
        private void PropButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> listExt = new List<string> { "bmp", "png", "gif", "jpg", "tif" };
            Prop prop = new Prop(listExt);
            prop.Owner = this;
            prop.Show();
        }
    }
}