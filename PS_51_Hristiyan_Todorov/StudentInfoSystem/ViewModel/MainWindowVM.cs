using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using StudentInfoSystem.Model;

namespace StudentInfoSystem.ViewModel
{
    public class MainWindowVM : DependencyObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<string> StudStatusChoices { get; set; }

        public MainWindowVM()
        {
            Model = new StudentModel();
            StudentInfoContext = new StudentInfoContext();

            FillStudStatusChoices();

            if (TestStudentsIfEmpty())
            {
                CopyTestStudents();
            }
        }

        public StudentModel Model { get; }
        public Student CurrentStudent { get; set; }
        internal StudentInfoContext StudentInfoContext { get; }

        public Student StudentContent
        {
            get { return CurrentStudent; }
            set { CurrentStudent = value; PropChanged("StudentContent"); }
        }

        public void GetStudentInfo()
        {
            StudentContent = Model.GetTestStudent();
        }

        private void PropChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();

            using (IDbConnection connection = new SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery = @"SELECT StatusDescr FROM StudStatus";

                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();

                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();

                bool notEndOfResult;

                notEndOfResult = reader.Read();

                while (notEndOfResult)
                {
                    string s = reader.GetString(0);

                    StudStatusChoices.Add(s);

                    notEndOfResult = reader.Read();
                }
            }
        }

        private bool TestStudentsIfEmpty()
        {
            IEnumerable<Student> queryStudents = StudentInfoContext.Students;
            int countStudents = queryStudents.Count();

            if(countStudents == 0)
            {
                return true;
            }

            return false;
        }

        private void CopyTestStudents()
        {
            foreach(Student student in StudentData.TestStudents)
            {
                StudentInfoContext.Students.Add(student);
                StudentInfoContext.SaveChanges();
            }
        }
    }
}
