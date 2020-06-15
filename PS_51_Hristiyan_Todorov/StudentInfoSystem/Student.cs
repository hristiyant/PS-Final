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
    }
}
