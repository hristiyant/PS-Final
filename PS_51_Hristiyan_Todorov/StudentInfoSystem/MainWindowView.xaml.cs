using StudentInfoSystem.View;
using StudentInfoSystem.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        private MainWindowVM Vm { get; }

        public MainWindowView()
        {
            InitializeComponent();
            Vm = new MainWindowVM();
            this.DataContext = Vm;
        }

        private void btnFillInStudentInfo_Click(object sender, RoutedEventArgs e)
        {
            Vm.GetStudentInfo();
        }

        private void btnClearStudentInfo_Click(object sender, RoutedEventArgs e)
        {
            ClearAllContent();
        }

        private void btnOpenSecondWindow_Click(object sender, RoutedEventArgs e)
        {
            SecondWindowView w2 = new SecondWindowView();
            w2.Show();
        }

        private void btnEnableControls_Click(object sender, RoutedEventArgs e)
        {
            EnableAllControls();
        }

        private void btnDisableControls_Click(object sender, RoutedEventArgs e)
        {
            DisableAllControls();
        }

        private void EnableAllControls()
        {
            gridPersonalInfo.IsEnabled = true;
            gridStudentInfo.IsEnabled = true;
        }

        private void DisableAllControls()
        {
            gridPersonalInfo.IsEnabled = false;
            gridStudentInfo.IsEnabled = false;
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
                if (item.GetType() == typeof(System.Windows.Controls.TextBox))
                {
                    ((System.Windows.Controls.TextBox)item).Clear();
                }
            }
        }

        private void StudentInfoMainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(System.Windows.Forms.MessageBox.Show("Are you sure you want to exit the application?", "Confirm", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            } else
            {
                System.Windows.Forms.Application.Exit();
            }
        }
    }
}
