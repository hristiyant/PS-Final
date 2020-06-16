using System;
using System.ComponentModel;
using System.Windows;

namespace StudentInfoSystem
{
    public class MainWindowVM : DependencyObject, INotifyPropertyChanged
    {
        private Student _currentStudent;
        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowVM()
        {
            StudentModel model = new StudentModel();
            StudentContent = model.GetTestStudent();
        }

        public Student StudentContent
        {
            get { return _currentStudent; }
            set { _currentStudent = value; PropChanged("StudentContent"); }
        }

        public void PropChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
