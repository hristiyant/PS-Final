namespace StudentInfoSystem
{
    public class StudentModel
    {
        private Student _testStudent;
        public Student GetTestStudent()
        {
            _testStudent = new Student(
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
                "51"
                );

            return _testStudent;
        }
    }
}
