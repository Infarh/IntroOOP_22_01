namespace StudentsOperations.Base;

public abstract class Entity
{
    public int Id { get; set; }
}

public abstract class NamedEntity : Entity
{
    public string Name { get; set; }
}

public abstract class PersonEntity : Entity
{
    public string LastName { get; set; }

    public string FirstName { get; set; }

    public string Patronymic { get; set; }
}