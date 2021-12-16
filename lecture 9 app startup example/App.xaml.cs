using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.IO; 

namespace lecture_9_app_startup_example
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            int ir1 = 1;

            if (File.Exists("a.txt"))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            else
            {
                SecondWindow otherWindow = new SecondWindow();
                otherWindow.Show();
            }
        }
    }


}
