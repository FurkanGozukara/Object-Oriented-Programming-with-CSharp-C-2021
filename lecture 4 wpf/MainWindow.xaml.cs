using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lecture_4_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        long irCounter = 0;
        long irCounter2 = 0;
        long irCounter3 = 0;

        public MainWindow()
        {
            InitializeComponent();
            Debug.WriteLine("thread id of main window : " + Thread.CurrentThread.ManagedThreadId);
        }

        private void btnExampleSingle_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("thread id of example button click : " + Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 10000; i++)
            {
                lstNumbers.Items.Add(DateTime.Now.ToString("HH-mm-ss fff"));
                var vrMs = new Random().Next(100, 900);
                Debug.WriteLine($"i={i} , sleeping {vrMs}");
                System.Threading.Thread.Sleep(vrMs);

            }
        }

        private void btnSingleSubThread_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("thread id of btnSingleSubThread_Click : " + Thread.CurrentThread.ManagedThreadId);
            var vrStartedTask = Task.Factory.StartNew(() =>
            {
                Debug.WriteLine("thread id of Task.Factory under  btnSingleSubThread_Click: " + Thread.CurrentThread.ManagedThreadId);
                UpdateDates();

            });
        }

        private void UpdateDates()
        {
            Debug.WriteLine("thread id of UpdateDates : " + Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 10000; i++)
            {
                irCounter++;
                //BeginInvoke non blocking
                //Invoke blocking
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    lstNumbers.Items.Add(DateTime.Now.ToString("HH-mm-ss fff") + " id: " + irCounter);
                    Debug.WriteLine("thread id of Dispatcher : " + Thread.CurrentThread.ManagedThreadId);
                }));

                var vrMs = new Random().Next(100, 900);
                Debug.WriteLine($"i={i} , sleeping {vrMs}");
                System.Threading.Thread.Sleep(vrMs);

            }
        }

        private void btnDataRacing_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() =>
            {

                irCounter = 0; irCounter2 = 0; irCounter3 = 0;
                List<Task> lstTasks = new List<Task>();
                for (int i = 0; i < 100; i++)
                {
                    var vrStartedTask = Task.Factory.StartNew(() =>
                    {
                        updateCounterValue();
                        updateCounterValueSync1();
                        updateCounterValueSync2();
                    });


                    vrStartedTask.ContinueWith(faultedTask =>
                    {

                        updateInterface("task id: " + faultedTask.Id + " faulted");

                    }, TaskContinuationOptions.OnlyOnFaulted
                    );

                    vrStartedTask.ContinueWith(completedTask =>
                    {

                        updateInterface("completed task id : " + completedTask.Id + " " + DateTime.Now.ToString("mm-ss-fff"));


                    });

                    vrStartedTask.ContinueWith(completedTask =>
                    {

                        updateInterface("succcessfully completed task id : " + completedTask.Id + " " + DateTime.Now.ToString("mm-ss-fff"));


                    }, TaskContinuationOptions.OnlyOnRanToCompletion);

                    lstTasks.Add(vrStartedTask);
                }
                Task.WaitAll(lstTasks.ToArray());

                updateInterface("counter 1 value: " + irCounter.ToString("N0"));
                updateInterface("counter 2 value: " + irCounter2.ToString("N0"));
                updateInterface("counter 3 value: " + irCounter3.ToString("N0"));

            });

        }

        void updateInterface(string srMsg)
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                lstNumbers.Items.Add(srMsg);
            }));
        }

        void updateCounterValue()
        {
            for (int i = 0; i < 1000000; i++)
            {
                irCounter++;
            }

            if (new Random().Next(1, 4) == 1)
            {
                throw new Exception();
            }
        }

        void updateCounterValueSync1()
        {
            for (int i = 0; i < 1000000; i++)
            {
                Interlocked.Increment(ref irCounter2);
            }
        }

        private static object _lockCounter3 = new object();

        void updateCounterValueSync2()
        {
            for (int i = 0; i < 1000000; i++)
            {
                lock (_lockCounter3)
                {
                    irCounter3++;
                }

            }
        }
    }
}
