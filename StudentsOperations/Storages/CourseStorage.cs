using StudentsOperations;
using StudentsOperations.Storages.Base;

namespace LectorsOperations.Storages;

public class CourseStorage : Storage<Course>
{
    protected override void Copy(Course Source, Course Destination)
    {
        Destination.Name = Source.Name;
        Destination.Description = Source.Description;
    }
}