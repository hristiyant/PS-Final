﻿namespace StudentInfoSystem.Model
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Faculty { get; set; }
        public string CourseName { get; set; }
        public string Degree { get; set; }
        public string Status { get; set; }
        public string FacultyNumber { get; set; }
        public string Year { get; set; }
        public string Stream { get; set; }
        public string Group { get; set; }

        public Student()
        {

        }

        public Student(string firstName, string secondName, string lastName, string faculty, string courseName, string degree, string status, string facultyNumber, string year, string stream, string group)
        {
            FirstName = firstName;
            SecondName = secondName;
            LastName = lastName;
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
