using StudentsOperations;
using StudentsOperations.Storages.Base;

namespace LectorsOperations.Storages;

public class StudentsGroupStorage : Storage<StudentsGroup>
{
    protected override void Copy(StudentsGroup Source, StudentsGroup Destination)
    {
        Destination.Name = Source.Name;
        Destination.CreationTime = Source.CreationTime;
    }
}