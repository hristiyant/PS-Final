using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace StudentInfoSystem
{
    public class MainWindowVM : DependencyObject, INotifyPropertyChanged
    {
        private Student _currentStudent;
        public event PropertyChangedEventHandler PropertyChanged;
        public List<string> StudStatusChoices { get; set; }
        StudentInfoContext context = new StudentInfoContext();

        public MainWindowVM()
        {
            StudentModel model = new StudentModel();
            StudentContent = model.GetTestStudent();
            FillStudStatusChoices();
            //MessageBox.Show(TestStudentsIfEmpty().ToString());
            if (TestStudentsIfEmpty())
            {
                CopyTestStudents();
            }
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
            IEnumerable<Student> queryStudents = context.Students;
            int countStudents = queryStudents.Count();

            if(countStudents == 0)
            {
                return true;
            }

            return false;
        }

        public void CopyTestStudents()
        {
            foreach(Student student in StudentData.TestStudents)
            {
                context.Students.Add(student);
                context.SaveChanges();
            }
        }
    }
}
