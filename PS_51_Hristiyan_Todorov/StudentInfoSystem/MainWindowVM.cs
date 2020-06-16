using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Data;
using System.Data.SqlClient;

namespace StudentInfoSystem
{
    public class MainWindowVM : DependencyObject, INotifyPropertyChanged
    {
        private Student _currentStudent;
        public event PropertyChangedEventHandler PropertyChanged;
        public List<string> StudStatusChoices { get; set; }

        public MainWindowVM()
        {
            StudentModel model = new StudentModel();
            StudentContent = model.GetTestStudent();
            FillStudStatusChoices();
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
    }
}
