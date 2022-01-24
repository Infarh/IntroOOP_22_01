using System.Diagnostics;

namespace StudentsOperations
{
    //[DebuggerDisplay("[{Id}] {LastName} {FirstName} {Patronymic} - {Rating}")]
    [Serializable]
    public class Student : IComparable<Student>
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        public double Rating { get; set; }

        public int GroupId { get; set; }

        public int CompareTo(Student? other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));

            return Rating.CompareTo(other.Rating);
        }

        public void Deconstruct(out int Id, out string LastName, out string FirstName, out string Patronymic)
        {
            Id = this.Id;
            LastName = this.LastName;
            FirstName = this.FirstName;
            Patronymic = this.Patronymic;
        }

        public override string ToString() => $"[{Id,4}] {LastName} {FirstName} {Patronymic} - {Rating:0.0#}";
    }
}
