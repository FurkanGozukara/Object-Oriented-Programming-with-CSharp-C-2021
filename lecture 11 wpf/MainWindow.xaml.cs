using System;
using System.Collections.Generic;
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

namespace lecture_11_wpf
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

        private void btnMainthreadEx_Click(object sender, RoutedEventArgs e)
        {
            ggexception();
        }

        private void taskUnhandled_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() =>
            {

                ggexception();

            });
        }

        private void ggexception()
        {
            Convert.ToInt32("add23");
        }

        private void threadExceptionn_Click(object sender, RoutedEventArgs e)
        {
            //unhandles exceptions in threads causes parent thread crash as well
            Thread thread1 = new Thread(ggexception);
            thread1.IsBackground = true;
            thread1.Start();
        }

        private void btnDispatcherBeginInvoke_Click(object sender, RoutedEventArgs e)
        {
            dispatcherERror();
        }

        private void dispatcherERror()
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                Convert.ToInt32("123test");
            }));
        }

        private void TaskDispatcher_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                dispatcherERror();
            });
        }

        private void ThreadDisatcer_Copy_Click(object sender, RoutedEventArgs e)
        {
         
            Thread thread1 = new Thread(dispatcherERror);
            thread1.IsBackground = true;
            thread1.Start();
        }
    }
}
