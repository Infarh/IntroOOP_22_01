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

        var random = new Random(5);
        var students = Enumerable.Range(1, 100).Select(
            i => new Student
            {
                //Id = i,
                LastName = $"Last name - {i}",
                FirstName = $"First name - {i}",
                Patronymic = $"Patronymic - {i}",
                Rating = random.NextDouble() * 100,
            }).ToArray();

        foreach (var student in students)
            __StudentsStorage.Add(student);

        
    }
}