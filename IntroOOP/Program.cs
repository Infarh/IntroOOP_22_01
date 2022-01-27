using System.Security.Cryptography.X509Certificates;

using StudentsOperations;
using StudentsOperations.Base;

namespace IntroOOP;

public static class Program
{
    public static void Main(string[] args)
    {
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


        Console.ReadLine();
    }
}