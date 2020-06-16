using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Security.RightsManagement;
using System.Windows;
using System.Windows.Input;

namespace StudentInfoSystem
{
    public class MainWindowVM : DependencyObject, INotifyPropertyChanged
    {
        public Student currentStudent;
        private ObservableCollection<Student> _BackingProperty;
        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowVM()
        {
            StudentModel model = new StudentModel();
            BoundProperty = model.GetData();
            currentStudent = model.GetData()[0];
        }

        public ObservableCollection<Student> BoundProperty
        {
            get { return _BackingProperty; }
            set { _BackingProperty = value; PropChanged("BoundProperty"); }
        }

        public void PropChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public Student StudentContent
        {
            get
            {
                return currentStudent;
            }
        }
        public string TxtFirstNameContent
        {
            get
            {
                return BoundProperty[0].FirstName;
            }
        }

        public string TxtSecondNameContent
        {
            get
            {
                return BoundProperty[0].SecondName;
            }
        }

        public string TxtLastName
        {
            get
            {
                return BoundProperty[0].LastName;
            }
        }
        public string TxtFacultyContent
        {
            get
            {
                return BoundProperty[0].Faculty;
            }
        }
        public string TxtCourseNameContent
        {
            get
            {
                return BoundProperty[0].CourseName;
            }
        }
        public string TxtDegreeContent
        {
            get
            {
                return BoundProperty[0].Degree;
            }
        }
        public string TxtStatusContent
        {
            get
            {
                return BoundProperty[0].Status;
            }
        }
        public string TxtFakNumContent
        {
            get
            {
                return BoundProperty[0].FacultyNumber;
            }
        }
        public string TxtYearContent
        {
            get
            {
                return BoundProperty[0].Year;
            }
        }
        public string TxtStreamContent
        {
            get
            {
                return BoundProperty[0].Stream;
            }
        }
        
        //Group
    }
}
