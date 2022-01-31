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

    public bool Edit(T Item)
    {
        if (Item is null) throw new ArgumentNullException(nameof(Item));

        //if (_Students.Contains(Student)) // закомментировано в связи с тем, что класс Entity реализует метод Equals, сравнивающий объекты по их идентификаторам
        //    return false;

        var db_item = GetById(Item.Id);
        if (db_item is null)
            return false;

        Copy(Item, db_item);

        // SaveChanges();

        return true;
    }

    protected abstract void Copy(T Source, T Destination);

    public T? Remove(int Id)
    {
        var db_student = GetById(Id);
        if (db_student is null)
            return null;

        _Items.Remove(db_student);

        return db_student;
    }
}
