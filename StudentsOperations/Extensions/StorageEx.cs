using StudentsOperations.Base;
using StudentsOperations.Storages.Base.Interfaces;

namespace StudentsOperations.Extensions;

public static class StorageEx
{
    public static void AddRange<T>(this IStorage<T> Storage, IEnumerable<T> Items) where T : Entity
    {
        foreach (var entity in Items)
            Storage.Add(entity);
    }

    public static Student[] GetBestStudents(this IEnumerable<Student> Students, double Treshold = 75)
    {
        return Students.Where(student => student.Rating >= Treshold).ToArray();
    }
}