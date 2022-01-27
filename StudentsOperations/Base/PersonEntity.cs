namespace StudentsOperations.Base;

public abstract class PersonEntity : Entity
{
    public string LastName { get; set; }

    public string FirstName { get; set; }

    public string Patronymic { get; set; }
}