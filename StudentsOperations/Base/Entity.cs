namespace StudentsOperations.Base;

public abstract class Entity
{
    public int Id { get; set; }

    public override bool Equals(object? obj)
    {
        //if (ReferenceEquals(obj, null)) return false;
        if (obj is null) return false;

        if (GetType() != obj.GetType()) return false;

        var other_entity = (Entity)obj;

        //if (other_entity.Id != Id)
        //    return false;
        //else
        //    return true;

        return other_entity.Id == Id;
    }
}