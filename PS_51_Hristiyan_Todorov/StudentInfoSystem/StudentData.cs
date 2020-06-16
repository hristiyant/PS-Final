using System.Collections.Generic;

namespace StudentInfoSystem
{
    //Not Used
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
                        //new Student()
                    };
                }

                return _testStudents;
            }
            private set { }
        }
    }
}
