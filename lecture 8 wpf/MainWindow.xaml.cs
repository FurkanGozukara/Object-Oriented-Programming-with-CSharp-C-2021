using System;
using System.Collections.Generic;
using System.Globalization;
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
using lecture_8_dll_example;

namespace lecture_8_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static string _student
        {
            get
            {
                CultureInfo currentCulture = CultureInfo.CurrentCulture;

                if (currentCulture.Name == "tr-TR")
                    return "Öğrenci";

                return "Student";
            }
            set { }
        }

        public MainWindow()
        {
            InitializeComponent();
            CultureInfo.CurrentCulture = new CultureInfo("tr-TR");
            initStudentList();

            lstbox1.ItemsSource = lstStudents;
            lstbox1.DisplayMemberPath = "displayStudent";
            lstbox1.SelectedValuePath = "studentId";

            lstbox1.SelectionChanged += Lstbox1_SelectionChanged;
            lstbox1.MouseDoubleClick += Lstbox1_MouseDoubleClick;

            listBox2.ItemsSource = lstStudents;
            listBox2.DisplayMemberPath = "displayStudent";
            listBox2.SelectedValuePath = "registerDate";

            lstbox1.LostFocus += Lstbox1_LostFocus;
            listBox2.LostFocus += ListBox2_LostFocus;
        }

        private void ListBox2_LostFocus(object sender, RoutedEventArgs e)
        {
            doubleClickGeneric(sender, null);
        }

        private void Lstbox1_LostFocus(object sender, RoutedEventArgs e)
        {
            doubleClickGeneric(sender, null);
        }

        private void Lstbox1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var vrSelected = ((students)lstbox1.SelectedItem);
      
            MessageBox.Show($"Id: {vrSelected.studentId} - {vrSelected.displayStudent} - {vrSelected.registerDate.ToLongDateString()}");
        }

        private void doubleClickGeneric(object sender, MouseButtonEventArgs e)
        {        
            var vrSelected = ((ListBox)sender);

            MessageBox.Show(vrSelected.SelectedValue.ToString());
        }

        private void Lstbox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblSelectedVal.Content = lstbox1.SelectedValue;
        }

        List<students> lstStudents = new List<students>();

        private void initStudentList()
        {
            lstStudents.Add(new students { firstName = "ahmet", lastName = "demirci", registerDate = new DateTime(2000, 1, 1), studentId = 1 });

            for (int i = 0; i < 10; i++)
            {
                lstStudents.Add(new students { firstName = $"{_student} " + i, lastName = "surname " + i, registerDate = new DateTime(2000 + i, 1 + i, 1 + i), studentId = 1 + i });
            }
        }

        public class students
        {
            public string firstName { get; set; }

            public string lastName { get; set; }

            public int studentId { get; set; }

            public DateTime registerDate { get; set; }

            public string displayStudent
            {

                get { return (this.firstName + " " + this.lastName); }

                set { }
            }
        }

        private void btnTestdll_Click(object sender, RoutedEventArgs e)
        {
            lecture_8_dll_example.listBoxExtensions myExt = new listBoxExtensions();
            var vrVal = myExt.displayValue(lstbox1);
            MessageBox.Show(vrVal);
        }
    }
}
