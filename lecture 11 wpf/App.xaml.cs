using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace lecture_11_wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()//main constructor of the entire application
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;

            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);

            Application.Current.DispatcherUnhandledException +=
                new DispatcherUnhandledExceptionEventHandler(Application_DispatcherUnhandledException);

            TaskScheduler.UnobservedTaskException += new EventHandler<UnobservedTaskExceptionEventArgs>(Application_DispatcherUnhandledException2);

            AppDomain.CurrentDomain.FirstChanceException += OnFirstChanceException;
        }

        private static void writeMessage(Exception e, string srWhichHandle)
        {
            //.? means null check. if not null
            //string srMsg;
            //if (e.InnerException != null)
            //    srMsg = e.InnerException?.Message;

            string srMsg = e.InnerException?.Message;
            //2019103039
            if (!string.IsNullOrEmpty(srMsg))
            {
                srMsg += "\r\n\r\nStack\r\n" + e.InnerException?.StackTrace;
            }

            if (string.IsNullOrEmpty(srMsg))
            {
                srMsg = e.Message + "\r\n\r\nStack\r\n" + e.StackTrace;
            }//update

            srMsg += $"\r\n\r\n****{srWhichHandle}*****\r\n\r\n";

            File.AppendAllText("global_errors.txt", srMsg);

        }

        private volatile bool _insideFirstChanceExceptionHandler;//inform the JIT compiler that the value of the variable should never be cached 

        // ...

    


        private static void Application_DispatcherUnhandledException2(object o, UnobservedTaskExceptionEventArgs e)
        {
            writeMessage(e.Exception, "UnobservedTaskException");
            e.SetObserved();
        }

        private static void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            writeMessage(e.Exception, "DispatcherUnhandledExceptionEventHandler");
            e.Handled = true;//prevents application crash
        }

        private static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            writeMessage(e, "UnhandledExceptionEventHandler");
        }

        private void OnFirstChanceException(object sender, FirstChanceExceptionEventArgs args)
        {
            if (_insideFirstChanceExceptionHandler)
            {
                // Prevent recursion if an exception is thrown inside this method
                return;
            }

            _insideFirstChanceExceptionHandler = true;
            try
            {
                writeMessage(args.Exception, "FirstChanceExceptionEventArgs");
            }
            catch
            {
                // You have to catch all exceptions inside this method
            }
            finally
            {
                _insideFirstChanceExceptionHandler = false;
            }
        }
    }
}
