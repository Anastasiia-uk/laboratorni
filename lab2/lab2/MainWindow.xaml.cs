using System;
using System.Threading;
using System.Windows;
using System.ComponentModel;
using System.Reflection;

namespace lab2
{
    public partial class MainWindow : Window
    {
        CalcArrAsync calcArrAsync1;
        CalcArrAsync calcArrAsync2;
        double[] arr;
        public MainWindow()
        {
            InitializeComponent();
        }
        public enum keys
        {
            Sum,
            Min,
            Max,
            SortDesc,
            SortIncr
        };
        void InitArr(int size)
        {
            arr = new double[size];
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(-1000, 1000);
            }
        }
        void PercentToPgBar1(int percent)
        {
            Dispatcher.Invoke(delegate () {
                PbTh1.Value = (Convert.ToDouble(percent) / Convert.ToDouble(arr.Length)) * 100;
                tb1.Text = $"{PbTh1.Value}%/100%";
            });
        }
        void PercentToPgBar2(int percent)
        {
            Dispatcher.Invoke(delegate () {
                PbTh2.Value = (Convert.ToDouble(percent) / Convert.ToDouble(arr.Length)) * 100;
                tb2.Text = $"{PbTh2.Value}%/100%";
            });
        }
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            InitArr(100000);
            calcArrAsync1 = new CalcArrAsync(arr, keys.Max);
            calcArrAsync1.PercentProgressHandler = PercentToPgBar1;
            calcArrAsync1.StartAsync();

            InitArr(10000);
            calcArrAsync2 = new CalcArrAsync(arr, keys.Min);
            calcArrAsync2.PercentProgressHandler = PercentToPgBar2;
            calcArrAsync2.StartAsync();
        }
    }
}
