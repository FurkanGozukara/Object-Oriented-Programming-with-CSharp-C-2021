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
           // lstBox1.Visibility = Visibility.Collapsed;
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            string srCommand = @"cmd /k ""sum\\lecture 3.exe"" ";

            string srCommand2 = @"cmd /c ""sum\\lecture 3.exe"" ";

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

        private void btnMergeAndShow_Click(object sender, RoutedEventArgs e)
        {
            int irIndex = 0;

            if (Int32.TryParse(txtListboxindex.Text, out irIndex))
            {
                if (lstBox1.Items.Count >= irIndex)
                    lstBox1.Items.Insert(irIndex, txt1.Text);
            }

            MessageBox.Show($"{txt1.Text} \t {txt2.Text} \n gg", "entered values");


        }

        private void btnSplit_Click(object sender, RoutedEventArgs e)
        {
            lstBox1.Items.Add(txt1.Text);

            foreach (var item in txt1.Text.Split(txtSplit.Text))
            {
                lstBox2.Items.Add(item);
            }
        }

        private void lstBox2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(lstBox2.SelectedItem.ToString());
        }

        private void btnClearListBox_Click(object sender, RoutedEventArgs e)
        {
            lstBox1.Items.Clear();
            lstBox2.Items.Clear();
        }

        private void lstBox1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtListboxindex.Text = lstBox1.SelectedItem?.ToString();
        }

        private void lstBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstBox1_MouseDown(null, null);
        }

        private void txtSplit_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtEventBox != null)
                txtEventBox.Text = txtSplit.Text;
        }

        private void btnChangeVisibility_Click(object sender, RoutedEventArgs e)
        {
            switch (lstBox1.Visibility)
            {
                case Visibility.Visible:
                    lstBox1.Visibility = Visibility.Hidden;
                    break;
                case Visibility.Hidden:
                    lstBox1.Visibility = Visibility.Visible;
                    break;
                case Visibility.Collapsed:
                    break;
                default:
                    break;
            }
        }

        private void btnRandomWindow_Click(object sender, RoutedEventArgs e)
        {
            RandomWindow r1 = new RandomWindow();
            r1.Show();
            RandomWindow r2 = new RandomWindow();
            r2.Show();
        }
    }
}
