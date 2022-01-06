using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            swLogErrors = new StreamWriter("ErrorLogs.txt");
        }

        private static System.Threading.Timer sysTimer;

        private void btnStart10Task_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");


            sysTimer = new System.Threading.Timer
            (threadTimer, null, new TimeSpan(0), new TimeSpan(0, 0, 1));


        }

        private static List<Task> lstTasks = new List<Task>();
        private static int irMaxTaskCount = 100;
        private static bool blTimerBusy = false;
        private static long irTaskId = 0;

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
                Interlocked.Increment(ref irTaskId);
                var tokenSource = new CancellationTokenSource();
                var token = tokenSource.Token;
                var local_i_CopyForDataRacingProblem = i;//this prevents i to be shared among different tasks and prevents data racing problem
                var localTaskId = Interlocked.Read(ref irTaskId);
                Task.Factory.StartNew(() => randomTask(local_i_CopyForDataRacingProblem, localTaskId, token), token).ContinueWith(t => { Debug.WriteLine($"task error happened : {t.Id} + \t " + t.Exception); },
        TaskContinuationOptions.OnlyOnFaulted).ContinueWith(t => { Debug.WriteLine($"task completed: {t.Id}"); });

                if (myRand.Next(1, 40) == 1)
                {
                    tokenSource.Cancel();
                }

            }

            blTimerBusy = false;

        }
        //modify this below method to log error happened task ids and the error itself
        private void randomTask(int irNumber, long lrTaskId, CancellationToken ct)
        {
            try
            {
                Debug.WriteLine("value irnnumber = " + irNumber);
                Random myRand = new Random();
                int irWait = myRand.Next(1, 10000);

                if (myRand.Next(1, 40) == 1)
                {
                    throw new Exception();
                }
                ct.ThrowIfCancellationRequested(); // throw OperationCancelledException if requested
                System.Threading.Thread.Sleep(irWait);
            }
            catch (Exception E)
            {
                logErrors(E, "task unhandled exception occurd in task global id " + lrTaskId);
            }
        
        }

        private static StreamWriter swLogErrors;
        private static object lockSwErrors = new object();
        private static void logErrors(Exception E, string srMsg)
        {
            lock(lockSwErrors)
            {
                swLogErrors.WriteLine(srMsg + $"\n{E?.Message}\n{E?.InnerException?.Message}\n{E?.StackTrace}\n\n");
                swLogErrors.Flush();
            }         
        }
    }
}
