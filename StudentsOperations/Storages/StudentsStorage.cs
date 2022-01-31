using StudentsOperations.Storages.Base;

namespace StudentsOperations.Storages;

public class StudentsStorage : Storage<Student>
{
    protected override void Copy(Student Source, Student Destination)
    {
        Destination.FirstName = Source.FirstName;
        Destination.LastName = Source.LastName;
        Destination.Patronymic = Source.Patronymic;
        Destination.Rating = Source.Rating;
        Destination.GroupId = Source.GroupId;
    }
}