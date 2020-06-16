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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public Student currentStudent;

        public MainWindowView()
        {
            InitializeComponent();
        }

        private void btnActivity_Click(object sender, RoutedEventArgs e)
        {
            //MainGrid.IsEnabled = false;
            //ClearAllContent();
            PrintStudentInfo(null);
        }

        private void SetCurrent(Student student)
        {
            if(student != null)
            {
                EnableAllControls();
                PrintStudentInfo(student);
            } else
            {
                ClearAllContent();
                DisableAllControls();
            }
        }

        private void DisableAllControls()
        {
            gridMain.IsEnabled = false;
        }

        private void EnableAllControls()
        {
            gridMain.IsEnabled = true;
        }

        private void ClearAllContent()
        {
            ClearGridContent(gridPersonalInfo);
            ClearGridContent(gridStudentInfo);
        }

        private void ClearGridContent(Grid grid)
        {
            foreach (var item in grid.Children)
            {
                if (item.GetType() == typeof(TextBox))
                {
                    ((TextBox)item).Clear();
                }
            }
        }

        private void PrintStudentInfo(Student student)
        {
            txtFirstName.Text = student.FirstName;
            txtSecondName.Text = student.SecondName;
            txtLastName.Text = student.LastName;
            txtFaculty.Text = student.Faculty;
            txtCourseName.Text = student.CourseName;
            txtDegree.Text = student.Degree;
            txtStatus.Text = student.Status;
            txtFakNum.Text = student.FacultyNumber;
            txtYear.Text = student.Year;
            txtStream.Text = student.Stream;
            txtGroup.Text = student.Group;
        }
    }
}
