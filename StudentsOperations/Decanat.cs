namespace StudentsOperations;

public class Decanat
{
    // CRUD = Create - Read - ?Update? - Delete

    private int _LastFreeStudentId = 1;
    private int _LastFreeGroupId = 1;
    private int _LastFreeCourseId = 1;
    private int _LastFreeLectorId = 1;

    private readonly List<Student> _Students = new();

    private readonly List<StudentsGroup> _Groups = new();

    private readonly List<Course> _Courses = new();

    private readonly List<Lector> _Lectors = new();

    public int AddStudent(Student Student, StudentsGroup Group)
    {
        if (_Students.Contains(Student))
            return Student.Id;

        //if (_Students.Count == 0)
        //    Student.Id = 1;
        //else
            //Student.Id = _Students.Max(s => s.Id) + 1;
        Student.Id = _LastFreeStudentId++;
        
        //var i = 0;
        //var j = i++ + ++i;
        //var m = i++; // 0 <- { m = i; i = i + 1; }
        //var k = ++i; // 2 <- { i = i + 1; k = i; }

        _Students.Add(Student);

        AddGroup(Group);
        Group.Students.Add(Student);

        return Student.Id;
    }

    public int AddGroup(StudentsGroup Group)
    {
        if (_Groups.Contains(Group))
            return Group.Id;

        Group.Id = _LastFreeGroupId++;
        _Groups.Add(Group);

        return Group.Id;
    }

    public int AddCourse(Course Course)
    {
        if (_Courses.Contains(Course))
            return Course.Id;

        Course.Id = _LastFreeCourseId++;
        _Courses.Add(Course);

        return Course.Id;
    }

    public int AddLector(Lector Lector)
    {
        if (_Lectors.Contains(Lector))
            return Lector.Id;

        Lector.Id = _LastFreeLectorId++;
        _Lectors.Add(Lector);

        return Lector.Id;
    }

    public Student? RemoveStudent(int Id)
    {
        var student = _Students.FirstOrDefault(s => s.Id == Id);
        if (student is null)
            return null;

        _Students.Remove(student);
        var group = _Groups.FirstOrDefault(g => g.Students.Contains(student));
        if (group != null)
            group.Students.Remove(student);

        return student;
    }

    public IEnumerable<Student> GetAllStudents() => _Students;

    public Student? GetStudentById(int Id)
    {
        var student = _Students.FirstOrDefault(s => s.Id == Id);
        return student;
    }

    public IEnumerable<StudentsGroup> GetAllGroups() => _Groups;

    public StudentsGroup? GetGroupById(int Id)
    {
        var student = _Groups.FirstOrDefault(s => s.Id == Id);
        return student;
    }

    public IEnumerable<Lector> GetAllLectors() => _Lectors;

    public Lector? GetLectorById(int Id)
    {
        var student = _Lectors.FirstOrDefault(s => s.Id == Id);
        return student;
    }

    public IEnumerable<Course> GetAllCourses() => _Courses;

    public Course? GetCourseById(int Id)
    {
        var student = _Courses.FirstOrDefault(s => s.Id == Id);
        return student;
    }
}