using System.Collections.ObjectModel;

namespace StudentInfoSystem
{
    public class StudentModel
    {
        ObservableCollection<Student> _data = new ObservableCollection<Student>();
        public ObservableCollection<Student> GetData()
        {
            _data.Add(new Student(
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
                ));

            return _data;
        }
    }
}
