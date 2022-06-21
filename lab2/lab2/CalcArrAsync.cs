using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;

namespace lab2
{
    public class CalcArrAsync
    {
        public delegate void PercentProgress(int percent);
        public PercentProgress PercentProgressHandler { get; set; }
        public double[] Arr { get; private set; }
        private MainWindow.keys Key;

        public CalcArrAsync(double[] Arr, MainWindow.keys Key)
        {
            this.Arr = Arr;
            this.Key = Key;
        }
        public void StartAsync()
        {
            switch (Key)
            {
                case MainWindow.keys.Sum:
                    Sum();
                    break;
                case MainWindow.keys.Min:
                    Min();
                    break;
                case MainWindow.keys.Max:
                    Max();
                    break;
                case MainWindow.keys.SortDesc:
                    SortDesc();
                    break;
                case MainWindow.keys.SortIncr:
                    SortIncr();
                    break;
                default:
                    break;
            }
        }
        async void Sum()
        {
            double sum = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < Arr.Length; i++)
                {
                    PercentProgressHandler(i + 1);
                    sum += Arr[i];
                }
            });
        }
        async void Min()
        {
            double min = Arr[0];
            await Task.Run(() => 
            {
                for (int i = 0; i < Arr.Length; i++)
                {
                    PercentProgressHandler(i + 1);
                    if (Arr[i] < min)
                        min = Arr[i];
                }
            });
        }
        async void Max()
        {
            double max = Arr[0];
            await Task.Run(() =>
            {
                for (int i = 0; i < Arr.Length; i++)
                {
                    PercentProgressHandler(i + 1);
                    if (Arr[i] > max)
                        max = Arr[i];
                }
            });
        }
        async void SortDesc()
        {
            double buf = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < Arr.Length; i++)
                {
                    PercentProgressHandler(i + 1);
                    for (int j = 0; j < Arr.Length - 1; j++)
                    {
                        if (Arr[j] < Arr[j + 1])
                        {
                            buf = Arr[j + 1];
                            Arr[j + 1] = Arr[j];
                            Arr[j] = buf;
                        }
                    }
                }
            });
        }
        async void SortIncr()
        {
            double buf = 0;
            await Task.Run(() => 
            {
                for (int i = 0; i < Arr.Length; i++)
                {
                    PercentProgressHandler(i + 1);
                    for (int j = 0; j < Arr.Length - 1; j++)
                    {
                        if (Arr[j] > Arr[j + 1])
                        {
                            buf = Arr[j + 1];
                            Arr[j + 1] = Arr[j];
                            Arr[j] = buf;
                        }
                    }
                }
            });
        }
    }
}
