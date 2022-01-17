using System.Diagnostics;

namespace StudentsOperations
{
    //[DebuggerDisplay("[{Id}] {LastName} {FirstName} {Patronymic} - {Rating}")]
    public class Student
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        public double Rating { get; set; }

        public int GroupId { get; set; }

        public override string ToString() => $"[{Id,4}] {LastName} {FirstName} {Patronymic} - {Rating:0.0#}";
    }
}
