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
using System.Windows.Threading;

namespace lecture_12_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private static System.Threading.Timer sysTimer;

        private void btnStart10Task_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");


            sysTimer = new System.Threading.Timer
            (threadTimer, null, new TimeSpan(0), new TimeSpan(0, 0, 1));


        }

        private static List<Task> lstTasks = new List<Task>();
        private static int irMaxTaskCount = 10;
        private static bool blTimerBusy = false;

        private void threadTimer(Object state)
        {
            Debug.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");

            if (blTimerBusy == true)
            {
                return;
            }
            blTimerBusy = true;

            //this removes completed tasks
            lstTasks = lstTasks.Where(pr => (pr.Status != TaskStatus.RanToCompletion && pr.Status != TaskStatus.Faulted && pr.Status != TaskStatus.Canceled)).ToList();

            Random myRand = new Random();


            for (int i = 0; i < irMaxTaskCount - lstTasks.Count; i++)
            {
                var tokenSource = new CancellationTokenSource();
                var token = tokenSource.Token;

                Task.Factory.StartNew(() => randomTask(token), token);

                if (myRand.Next(1, 4) == 1)
                {
                    tokenSource.Cancel();
                }

            }

            blTimerBusy = false;

        }

        private void randomTask(CancellationToken ct)
        {
            Random myRand = new Random();
            int irWait = myRand.Next(1, 10000);

            if (myRand.Next(1, 4) == 1)
            {
                throw new Exception();
            }
            ct.ThrowIfCancellationRequested(); // throw OperationCancelledException if requested
            System.Threading.Thread.Sleep(irWait);
        }
    }
}
