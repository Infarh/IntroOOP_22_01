using StudentsOperations;
using StudentsOperations.Storages.Base;

namespace LectorsOperations.Storages;

public class LectorsStorage : Storage<Lector>
{
    public override bool Edit(Lector Lector)
    {
        if (Lector is null) throw new ArgumentNullException(nameof(Lector));

        //if (_Lectors.Contains(Lector)) // закомментировано в связи с тем, что класс Entity реализует метод Equals, сравнивающий объекты по их идентификаторам
        //    return false;

        var db_lector = GetById(Lector.Id);
        if (db_lector is null)
            return false;

        db_lector.FirstName = Lector.FirstName;
        db_lector.LastName = Lector.LastName;
        db_lector.Patronymic = Lector.Patronymic;
        db_lector.Degree = Lector.Degree;
        db_lector.Position = Lector.Position;

        // SaveChanges();

        return true;
    }
}