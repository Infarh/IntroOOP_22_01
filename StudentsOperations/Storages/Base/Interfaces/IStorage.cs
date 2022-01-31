using StudentsOperations.Base;

namespace StudentsOperations.Storages.Base.Interfaces;

public interface IStorage<T> : IEnumerable<T> where T : Entity
{
    IEnumerable<T> GetAll();

    T? GetById(int Id);

    int Add(T NewItem);

    bool Edit(T Item);

    T? Remove(int Id);
}