using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;

namespace lab1
{
    public class CalcArrInThread
    {
        public delegate void PercentProgress(int percent); 
        public double[] Arr { get; private set; }
        public Thread thread { get; private set; }
        public PercentProgress PercentProgressHandler { get; set; }
        //public int ProgressPercent { get; private set; } = 0;
        private MainWindow.keys Key;
        public CalcArrInThread(double[] Arr, MainWindow.keys Key)
        {
            this.Arr = Arr;
            this.Key = Key;
        }
        public void StartThread()
        {
            switch (Key)
            {
                case MainWindow.keys.Sum:
                    thread = new Thread(Sum);
                    thread.Start();
                    break;

                case MainWindow.keys.Min:
                    thread = new Thread(Min);
                    thread.Start();
                    break;
                case MainWindow.keys.Max:
                    thread = new Thread(Max);
                    thread.Start();
                    break;
                case MainWindow.keys.SortDesc:
                    thread = new Thread(SortDesc);
                    thread.Start();
                    break;
                case MainWindow.keys.SortIncr:
                    thread = new Thread(SortIncr);
                    thread.Start();
                    break;
                default:
                    break;
            }
        }
        public void StopThread()
        {
            
            thread.Abort();
        }
        public void Sum()
        {
            double sum = 0;
            for (int i = 0; i < Arr.Length; i++)
            {
                PercentProgressHandler(i + 1);
                sum += Arr[i];
            }
        }
        void Min()
        {
            double min = Arr[0];
            for (int i = 0; i < Arr.Length; i++)
            {
                PercentProgressHandler(i + 1);
                if (Arr[i] < min)
                    min = Arr[i];
            }
        }
        void Max()
        {
            double max = Arr[0];
            for (int i = 0; i < Arr.Length; i++)
            {
                PercentProgressHandler(i + 1);
                if (Arr[i] > max)
                    max = Arr[i];
            }
        }
        void SortDesc() 
        {
            double buf = 0;
            for (int i = 0; i < Arr.Length; i++)
            {
                PercentProgressHandler(i + 1);
                for (int j = 0; j < Arr.Length-1; j++)
                {
                    if(Arr[j] < Arr[j+1])
                    {
                        buf = Arr[j + 1];
                        Arr[j + 1] = Arr[j];
                        Arr[j] = buf;
                    }
                }
            }
        }
        void SortIncr()
        {
            double buf = 0;
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
        }
    }
}
