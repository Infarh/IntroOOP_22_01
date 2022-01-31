using System.Security.Cryptography.X509Certificates;

using StudentsOperations;
using StudentsOperations.Base;
using StudentsOperations.Storages;
using StudentsOperations.Storages.Base;

namespace IntroOOP;

public static class Program
{
    private static void Print(NamedEntity entity)
    {
        Console.WriteLine("[{0,5}] {1}", entity.Id, entity.Name);
    }

    private static StudentsStorage __StudentsStorage = new();

    public static void Main(string[] args)
    {

        var course = new Course
        {
            Id = 1,
            Name = "Алгебра",
        };

        var group = new StudentsGroup
        {
            Id = 1,
            Name = "Математики",
        };

        Print(course);
        Print(group);

        var students = Enumerable.Range(1, 100).Select(
            i => new Student
            {
                //Id = i,
                LastName = $"Last name - {i}",
                FirstName = $"First name - {i}",
                Patronymic = $"Patronymic - {i}",
            }).ToArray();

        foreach (var student in students)
            __StudentsStorage.Add(student);

        var students_first_name_dict = students.ToDictionary(s => s.LastName, s => s.FirstName);

        var test_student = students_first_name_dict["Last name - 53"];
        //var test_student = students.First(stud => stud.LastName == "Last name - 53");

        var decanat = new Decanat();

        var group1 = new StudentsGroup { Name = "Группа-1" };

        decanat.AddStudent(new Student
        {
            LastName = "Иванов",
            FirstName = "Иван",
            Patronymic = "Иванович",
        }, group1);

        decanat.AddStudent(new Student
        {
            LastName = "Петров",
            FirstName = "Пётр",
            Patronymic = "Петрович",
        }, group1);

        decanat.AddStudent(new Student
        {
            LastName = "Сидоров",
            FirstName = "Сидор",
            Patronymic = "Сидорович",
        }, new StudentsGroup { Name = "Группа-2" });


        var students_ratings = new Dictionary<Student, double>();

        var students_set = new HashSet<Student>();

        Console.ReadLine();
    }
}