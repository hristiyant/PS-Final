using System.Windows;
using System.Windows.Controls;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();
            MainWindowVM vm = new MainWindowVM();
            this.DataContext = vm;
        }

        private void btnActivity_Click(object sender, RoutedEventArgs e)
        {
            PrintStudentInfo(null);
        }

        private void SetCurrent(Student student)
        {
            if (student != null)
            {
                EnableAllControls();
                PrintStudentInfo(student);
            }
            else
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
