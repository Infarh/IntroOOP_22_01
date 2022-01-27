using System.Security.Cryptography.X509Certificates;
using StudentsOperations;
using StudentsOperations.Base;

namespace IntroOOP;

public static class Program
{
    public static void Main(string[] args)
    {
        var stud1 = new Student
        {
            Id = 1,
            LastName = "Иванов",
            FirstName = "Иван",
            Patronymic = "Иванович",
            Rating = 95,
        };

        var stud2 = new Student
        {
            Id = 2,
            LastName = "Петров",
            FirstName = "Пётр",
            Patronymic = "Петрович",
        };

        var stud3 = new Student
        {
            Id = 1,
            LastName = "Сидоров",
            FirstName = "Сидор",
            Patronymic = "Сидорович",
        };

        var is_stud1_eq_stud2 = stud1.Equals(stud2);
        var is_stud1_eq_stud3 = Equals(stud1, stud3);

        var students_list = new List<Student>
        {
            stud1,
            stud2,
        };

        var is_list_contains_stud3 = students_list.Contains(stud3);

        /* --------------------------------------------- */

        var course1 = new Course
        {
            Id = 1,
            Name = "Информатика",
        };

        var course2 = new Course
        {
            Id = 2,
            Name = "Информатика",
        };

        var course3 = new Course
        {
            Id = 3,
            Name = "Матан",
        };

        var is_course1_eq_course2 = object.Equals(course1, course2);
        var is_course1_eq_course2_2 = course1.Equals(course2);


        Console.ReadLine();
    }
}