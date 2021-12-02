using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

namespace lecture_7_wpf
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

        private void btnBeginInvoke_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                Stopwatch sw1 = new Stopwatch();
                sw1.Start();
                for (int i = 0; i < 100000; i++)
                {
                    //lstBox1.Items.Add(i.ToString("N0"));//'The calling thread cannot access this object because a different thread owns it.'

                    Dispatcher.BeginInvoke((Action)(() =>
                    {
                        lstBox1.Items.Add(i.ToString("N0"));
                    }));
                }
                sw1.Stop();
                MessageBox.Show("begin invoke took: " + sw1.ElapsedMilliseconds.ToString("N0") + " ms");
            });
        }

        private void btnInvoke_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                Stopwatch sw1 = new Stopwatch();
                sw1.Start();
                for (int i = 0; i < 100000; i++)
                {
                    //lstBox1.Items.Add(i.ToString("N0"));//'The calling thread cannot access this object because a different thread owns it.'

                    Dispatcher.Invoke((Action)(() =>
                    {
                        lstBox1.Items.Add(i.ToString("N0"));
                    }));
                }

                sw1.Stop();
                MessageBox.Show("invoke took: " + sw1.ElapsedMilliseconds.ToString("N0") + " ms");
            });
        }
    }
}
