using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace lecture_3_wpf_cmd
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

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            string srCommand = @"cmd /k ""sum\\lecture 3.exe"" ";

          string  srCommand2 = @"cmd /c ""sum\\lecture 3.exe"" ";

            var vrParams = "200 500 700";
                File.WriteAllText("sum.cmd", srCommand + vrParams, System.Text.Encoding.Default);
                var p = new Process();
                p.StartInfo.FileName = "sum.cmd";
                p.Start();
            p.WaitForExit();

            vrParams = "200 500 700";
            File.WriteAllText("sum.cmd", srCommand2 + vrParams, System.Text.Encoding.Default);
            p = new Process();
            p.StartInfo.FileName = "sum.cmd";
            p.Start();
            p.WaitForExit();


            vrParams = "200 500 700";
            File.WriteAllText("sum.cmd", srCommand2 + vrParams, System.Text.Encoding.Default);
            p = new Process();
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "sum.cmd";
            p.Start();
            p.WaitForExit();
        }
    }
}
