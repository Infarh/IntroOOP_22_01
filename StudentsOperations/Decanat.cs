using StudentsOperations.Storages.Base.Interfaces;

namespace StudentsOperations;

public class Decanat
{
    private readonly IStorage<Student> _Students;
    private readonly IStorage<Lector> _Lectors;
    private readonly IStorage<Course> _Courses;
    private readonly IStorage<StudentsGroup> _StudentsGroups;

    public Decanat(
        IStorage<Student> Students,
        IStorage<Lector> Lectors,
        IStorage<Course> Courses,
        IStorage<StudentsGroup> StudentsGroups)
    {
        _Students = Students;
        _Lectors = Lectors;
        _Courses = Courses;
        _StudentsGroups = StudentsGroups;
    }

    public int AddStudent(Student Student, StudentsGroup Group)
    {
        if (_Students.GetById(Student.Id) is not null)
            return Student.Id;

        //if (_Students.Count == 0)
        //    Student.Id = 1;
        //else
            //Student.Id = _Students.Max(s => s.Id) + 1;
        //Student.Id = _LastFreeStudentId++;
        
        //var i = 0;
        //var j = i++ + ++i;
        //var m = i++; // 0 <- { m = i; i = i + 1; }
        //var k = ++i; // 2 <- { i = i + 1; k = i; }

        _Students.Add(Student);

        AddGroup(Group);
        Group.Students.Add(Student);
        Student.GroupId = Group.Id;

        return Student.Id;
    }

    public int AddGroup(StudentsGroup Group)
    {
        if (_StudentsGroups.GetById(Group.Id) is not null)
            return Group.Id;

        _StudentsGroups.Add(Group);

        return Group.Id;
    }

    public int AddCourse(Course Course)
    {
        if (_Courses.GetById(Course.Id) is not null)
            return Course.Id;

        _Courses.Add(Course);

        return Course.Id;
    }

    public int AddLector(Lector Lector)
    {
        if (_Lectors.GetById(Lector.Id) is not null)
            return Lector.Id;

        _Lectors.Add(Lector);

        return Lector.Id;
    }

    public Student? RemoveStudent(int Id)
    {
        return _Students.Remove(Id);
    }

    public IEnumerable<Student> GetAllStudents() => _Students;

    public Student? GetStudentById(int Id)
    {
        return _Students.GetById(Id);
    }

    public IEnumerable<StudentsGroup> GetAllGroups() => _StudentsGroups;

    public StudentsGroup? GetGroupById(int Id)
    {
        return _StudentsGroups.GetById(Id);
    }

    public IEnumerable<Lector> GetAllLectors() => _Lectors;

    public Lector? GetLectorById(int Id)
    {
        return _Lectors.GetById(Id);
    }

    public IEnumerable<Course> GetAllCourses() => _Courses;

    public Course? GetCourseById(int Id)
    {
        return _Courses.GetById(Id);
    }
}