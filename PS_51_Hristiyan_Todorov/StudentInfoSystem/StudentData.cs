using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    static class StudentData
    {
        private static List<Student> _testStudents;

        internal static List<Student> TestStudents
        {
            get
            {
                if (_testStudents == null)
                {
                    _testStudents = new List<Student>
                    {
                        new Student("Hrisko","Drisko", "12121212")
                    };
                }

                return _testStudents;
            }
            private set { }
        }
    }
}
