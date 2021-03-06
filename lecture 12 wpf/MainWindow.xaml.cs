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
            for (int i = 0; i < 8; i++)
            {
                lstBoxStatus.Items.Add("");
            }
        }

        private static System.Threading.Timer sysTimer;

        private void btnStart10Task_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");


            sysTimer = new System.Threading.Timer
            (threadTimer, null, new TimeSpan(0), new TimeSpan(0, 0, 1));

            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                lstBoxStatus.Items[0] = $"Number of Created tasks: {lstTasks.Where(pr => pr.Status == TaskStatus.Created).Count<Task>()}";
            }));
            Dispatcher.BeginInvoke((Action)(() =>
            {
                lstBoxStatus.Items[1] = $"Number of WaitingForActivation tasks: {lstTasks.Where(pr => pr.Status == TaskStatus.WaitingForActivation).Count<Task>()}";
            }));
            Dispatcher.BeginInvoke((Action)(() =>
            {
                lstBoxStatus.Items[2] = $"Number of WaitingToRun tasks: {lstTasks.Where(pr => pr.Status == TaskStatus.WaitingToRun).Count<Task>()}";
            }));
            Dispatcher.BeginInvoke((Action)(() =>
            {
                lstBoxStatus.Items[3] = $"Number of Running tasks: {lstTasks.Where(pr => pr.Status == TaskStatus.Running).Count<Task>()}";
            }));
            Dispatcher.BeginInvoke((Action)(() =>
            {
                lstBoxStatus.Items[4] = $"Number of Canceled tasks: {lstTasks.Where(pr => pr.Status == TaskStatus.Canceled).Count<Task>()}";
            }));
            Dispatcher.BeginInvoke((Action)(() =>
            {
                lstBoxStatus.Items[5] = $"Number of Faulted tasks: {lstTasks.Where(pr => pr.Status == TaskStatus.Faulted).Count<Task>()}";
            }));
            Dispatcher.BeginInvoke((Action)(() =>
            {
                lstBoxStatus.Items[6] = $"Number of RanToCompletion tasks: {lstTasks.Where(pr => pr.Status == TaskStatus.RanToCompletion).Count<Task>()}";
            }));
            Dispatcher.BeginInvoke((Action)(() =>
            {
                lstBoxStatus.Items[7] = DateTime.Now.ToString("mm-ss-fff");
            }));
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
                var vrTask = Task.Factory.StartNew(() => randomTask(local_i_CopyForDataRacingProblem, localTaskId, token), token).ContinueWith(t => { Debug.WriteLine($"task error happened : {t.Id} + \t " + t.Exception); },
          TaskContinuationOptions.OnlyOnFaulted).ContinueWith(t => { Debug.WriteLine($"task completed: {t.Id}"); });
                lstTasks.Add(vrTask);

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
                int irWait = myRand.Next(1000, 100000);

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
            lock (lockSwErrors)
            {
                swLogErrors.WriteLine(srMsg + $"\n{E?.Message}\n{E?.InnerException?.Message}\n{E?.StackTrace}\n\n");
                swLogErrors.Flush();
            }
        }
    }
}
