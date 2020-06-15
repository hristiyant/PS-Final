using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
    class StudentValidation
    {
        public Student GetStudentDataByUser(User user)
        {
            foreach (Student student in StudentData.TestStudents)
            {
                if (user.FakNum.Equals(student.FacultyNumber))
                {
                    return student;
                }

            }

            //No matching record has been found.
            Console.WriteLine("Не е намерен студент с посочения факултетен номер.");
            return null;
        }
    }
}
