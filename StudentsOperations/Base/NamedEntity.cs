namespace StudentsOperations.Base;

public abstract class NamedEntity : Entity
{
    public string Name { get; set; }

    public new bool Equals(object? obj)
    {
        if (obj is null) return false;

        if (GetType() != obj.GetType()) return false;

        var other_entity = (NamedEntity)obj;
        return /*other_entity.Id == Id && */other_entity.Name == Name;
    }
}