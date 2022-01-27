using StudentsOperations.Base;

namespace StudentsOperations;

public class StudentsGroup : NamedEntity
{
    public DateTime CreationTime { get; set; } = DateTime.Now;

    public List<Student> Students { get; } = new();
}