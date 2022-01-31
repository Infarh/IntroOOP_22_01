using StudentsOperations.Base;

namespace StudentsOperations.Storages.Base;

public abstract class Storage<T> where T : Entity
{
    private int _LastFreeId = 1;
    private List<T> _Items = new();

    public IEnumerable<T> GetAll() => _Items.AsEnumerable();

    public T? GetById(int Id)
    {
        return _Items.FirstOrDefault(entity => entity.Id == Id);
    }

    public int Add(T NewItem)
    {
        if (NewItem is null) throw new ArgumentNullException(nameof(NewItem));

        if (_Items.Contains(NewItem)) // только для данной реализации!!! Когда в БД будет - это писать НЕ НАДО!!!
            return NewItem.Id;

        NewItem.Id = _LastFreeId;
        _LastFreeId++;
        _Items.Add(NewItem);

        return NewItem.Id;
    }

    public abstract bool Edit(T Item);

    public T? Remove(int Id)
    {
        var db_student = GetById(Id);
        if (db_student is null)
            return null;

        _Items.Remove(db_student);

        return db_student;
    }
}
