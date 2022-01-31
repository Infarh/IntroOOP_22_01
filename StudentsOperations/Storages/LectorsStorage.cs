using StudentsOperations;

namespace LectorsOperations.Storages;

public class LectorsStorage
{
    private int _LastFreeId = 1;
    private List<Lector> _Lectors = new();

    public IEnumerable<Lector> GetAll()
    {
        return _Lectors.AsReadOnly();
    }

    public Lector? GetById(int Id)
    {
        //foreach(var lector in _Lectors)
        //    if (lector.Id == Id)
        //        return lector;

        //return null;

        return _Lectors.FirstOrDefault(lector => lector.Id == Id);
    }

    /// <summary>Добавление нового лектора в хранилище</summary>
    /// <param name="Lector">Добавляемый лектор</param>
    /// <returns>Возвращает значение назначенного идентификатора</returns>
    /// <exception cref="ArgumentNullException">Если передана пустая ссылка <paramref name="Lector"/></exception>
    public int Add(Lector Lector)
    {
        if(Lector is null) throw new ArgumentNullException(nameof(Lector));

        if (_Lectors.Contains(Lector)) // только для данной реализации!!! Когда в БД будет - это писать НЕ НАДО!!!
            return Lector.Id;

        Lector.Id = _LastFreeId; 
        _LastFreeId++;
        _Lectors.Add(Lector);

        return Lector.Id;
    }

    public bool Edit(Lector Lector)
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

    public Lector? Remove(int Id)
    {
        var db_lector = GetById(Id);
        if (db_lector is null)
            return null;

        _Lectors.Remove(db_lector);

        return db_lector;
    }
}