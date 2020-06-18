using System.Collections.Generic;
using System.Linq;

namespace StudentInfoSystem.Model
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
                        new Student(
                                "Иван",
                                "Иванов",
                                "Иванов",
                                "ФКСУ",
                                "КСТ",
                                "Бакалавър",
                                "Прекъснал",
                                "121212123",
                                "4",
                                "8",
                                "51")
                };
                }

                return _testStudents;
            }
            private set { }
        }

        public static Student IsThereStudent(string facNum)
        {
            StudentInfoContext context = new StudentInfoContext();

            Student result = (from st in context.Students where st.FacultyNumber == facNum select st).First();

            return result;
        }
    }
}
