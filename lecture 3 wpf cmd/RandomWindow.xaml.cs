using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace lecture_3_wpf_cmd
{
    /// <summary>
    /// Interaction logic for RandomWindow.xaml
    /// </summary>
    public partial class RandomWindow : Window
    {
        public RandomWindow()
        {
            InitializeComponent();
        }

        Dictionary<long, long> dicNumbers = new Dictionary<long, long>();

        private void btnRandomNumberGenerator_Click(object sender, RoutedEventArgs e)
        {
            startDateTimer();
            Task.Factory.StartNew(() => { initNumbers(); });
        }

        private void initNumbers()
        {
            Random myRand = new Random();
            for (int i = 0; i < 100000000; i++)
            {
                var vr1 = myRand.RandomLong();
                var vr2 = myRand.RandomLong();
                if (!dicNumbers.ContainsKey(vr1))
                {
                    dicNumbers.Add(vr1, vr2);
                }
            }
        }

        private void startDateTimer()
        {
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            lblTime.Content = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
