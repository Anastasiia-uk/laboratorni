using System;
using System.Threading;
using System.Windows;
using System.ComponentModel;
using System.Reflection;

namespace lab1
{
    public partial class MainWindow : Window
    {
        CalcArrInThread calcArrInThread1;
        CalcArrInThread calcArrInThread2;
        double[] arr;
        public MainWindow()
        {
            InitializeComponent();
            Exit1Button.IsEnabled = false;
            Exit2Button.IsEnabled = false;
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
            calcArrInThread1 = new CalcArrInThread(arr, keys.Max);
            calcArrInThread1.PercentProgressHandler = PercentToPgBar1;

            InitArr(10000);
            calcArrInThread2 = new CalcArrInThread(arr, keys.SortDesc);
            calcArrInThread2.PercentProgressHandler = PercentToPgBar2;

            calcArrInThread1.StartThread();
            calcArrInThread2.StartThread();
            Exit1Button.IsEnabled = Exit2Button.IsEnabled = true;
        }

        private void Exit1Button_Click(object sender, RoutedEventArgs e)
        {
            calcArrInThread1.StopThread();
            if (PbTh1.Value < 100)
                MessageBox.Show($"Thread canceled at {PbTh1.Value.ToString()}%");
            PbTh1.Value = 0;
            tb1.Text = "";
            Exit1Button.IsEnabled = false;
        }
        private void Exit2Button_Click(object sender, RoutedEventArgs e)
        {
            calcArrInThread2.StopThread();
            if (PbTh2.Value < 100)
                MessageBox.Show($"Thread canceled at {PbTh2.Value.ToString()}%");
            PbTh2.Value = 0;
            tb2.Text = "";
            Exit2Button.IsEnabled = false;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (Exit1Button.IsEnabled)
                calcArrInThread1.StopThread();
            if (Exit2Button.IsEnabled)
                calcArrInThread2.StopThread();
        }
    }
}
