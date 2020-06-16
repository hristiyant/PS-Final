using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class Student
    {
        public string FirstName;
        public string SecondName;
        public string LastName;
        public string Faculty;
        public string CourseName;
        public string Degree;
        public string Status;
        public string FacultyNumber;
        public string Year;
        public string Stream;
        public string Group;

        public Student(string firstName, string lastName, string facultyNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            FacultyNumber = facultyNumber;
        }

        public Student(string firstName, string secondName, string lastName, string faculty, string courseName, string degree, string status, string facultyNumber, string year, string stream, string group) : this(firstName, secondName, lastName)
        {
            Faculty = faculty;
            CourseName = courseName;
            Degree = degree;
            Status = status;
            FacultyNumber = facultyNumber;
            Year = year;
            Stream = stream;
            Group = group;
        }
    }
}
