using System.Security.Cryptography.X509Certificates;

using System.Linq;
using LectorsOperations.Storages;
using StudentsOperations;
using StudentsOperations.Base;
using StudentsOperations.Extensions;
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
    private static StudentsGroupStorage __GroupsStorage = new();

    public static void Main(string[] args)
    {
        var groups = Enumerable.Range(1, 10)
           .Select(i => new StudentsGroup
            {
                Id = i,
                Name = $"Группа-{i}",
            })
           .ToArray();

        var random = new Random(5);
        var students = Enumerable.Range(1, 100)
           .Select(i => new Student
            {
                //Id = i,
                LastName = $"Last name - {i}",
                FirstName = $"First name - {i}",
                Patronymic = $"Patronymic - {i}",
                Rating = random.NextDouble() * 100,
                GroupId = random.Next(groups.Length)
            })
           .ToArray();

        __StudentsStorage.AddRange(students);

        var best_students2 = __StudentsStorage.GetBestStudents();
        var best_students3 = students.GetBestStudents();

        Array.ForEach(groups, g => __GroupsStorage.Add(g));

        var best_students = __StudentsStorage.Count(student => student.Rating >= 90);

        var group_students = __GroupsStorage.Join(
            __StudentsStorage,
            group => group.Id,
            student => student.GroupId,
            (group, student) => (Group: group, Student: student));

        foreach (var (group, student) in group_students)
            group.Students.Add(student);

        var students_list = new List<Student>(students);

        //students_list.ForEach(s => Console.WriteLine(s));
        best_students3.Foreach(s => Console.WriteLine(s));
    }
}