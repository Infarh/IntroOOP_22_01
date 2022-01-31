namespace StudentsOperations.Storages;

public class StudentsStorage
{
    private int _LastFreeId = 1;
    private List<Student> _Students = new();

    public IEnumerable<Student> GetAll()
    {
        return _Students.AsReadOnly();
    }

    public Student? GetById(int Id)
    {
        //foreach(var student in _Students)
        //    if (student.Id == Id)
        //        return student;

        //return null;

        return _Students.FirstOrDefault(student => student.Id == Id);
    }

    /// <summary>Добавление нового студента в хранилище</summary>
    /// <param name="Student">Добавляемый студент</param>
    /// <returns>Возвращает значение назначенного идентификатора</returns>
    /// <exception cref="ArgumentNullException">Если передана пустая ссылка <paramref name="Student"/></exception>
    public int Add(Student Student)
    {
        if(Student is null) throw new ArgumentNullException(nameof(Student));

        if (_Students.Contains(Student)) // только для данной реализации!!! Когда в БД будет - это писать НЕ НАДО!!!
            return Student.Id;

        Student.Id = _LastFreeId; 
        _LastFreeId++;
        _Students.Add(Student);

        return Student.Id;
    }

    public bool Edit(Student Student)
    {
        if (Student is null) throw new ArgumentNullException(nameof(Student));

        //if (_Students.Contains(Student)) // закомментировано в связи с тем, что класс Entity реализует метод Equals, сравнивающий объекты по их идентификаторам
        //    return false;

        var db_student = GetById(Student.Id);
        if (db_student is null)
            return false;

        db_student.FirstName = Student.FirstName;
        db_student.LastName = Student.LastName;
        db_student.Patronymic = Student.Patronymic;
        db_student.Rating = Student.Rating;
        db_student.GroupId = Student.GroupId;

        // SaveChanges();

        return true;
    }

    public Student? Remove(int Id)
    {
        var db_student = GetById(Id);
        if (db_student is null)
            return null;

        _Students.Remove(db_student);

        return db_student;
    }
}