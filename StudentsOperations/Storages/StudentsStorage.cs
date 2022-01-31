using StudentsOperations.Storages.Base;

namespace StudentsOperations.Storages;

public class StudentsStorage : Storage<Student>
{
    public override bool Edit(Student Student)
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
}