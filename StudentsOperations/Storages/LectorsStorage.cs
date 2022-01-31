using StudentsOperations;
using StudentsOperations.Storages.Base;

namespace LectorsOperations.Storages;

public class LectorsStorage : Storage<Lector>
{
    protected override void Copy(Lector Source, Lector Destination)
    {
        Destination.FirstName = Source.FirstName;
        Destination.LastName = Source.LastName;
        Destination.Patronymic = Source.Patronymic;
        Destination.Degree = Source.Degree;
        Destination.Position = Source.Position;
    }
}