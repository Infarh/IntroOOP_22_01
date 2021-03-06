using System.Diagnostics;
using StudentsOperations.Base;

namespace StudentsOperations
{
    //[DebuggerDisplay("[{Id}] {LastName} {FirstName} {Patronymic} - {Rating}")]
    [Serializable]
    public class Student : PersonEntity, IComparable<Student>
    {
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

        public override int GetHashCode()
        {
            //return HashCode.Combine(Id, LastName, FirstName, Patronymic, Rating, GroupId);

            unchecked
            {
                var hash = Id.GetHashCode();
                hash = (hash * 397) ^ LastName.GetHashCode(); // ^ - оператор "исключающее или" - побитовый
                hash = (hash * 397) ^ FirstName.GetHashCode(); // X != Y;
                hash = (hash * 397) ^ Patronymic.GetHashCode();
                hash = (hash * 397) ^ Rating.GetHashCode();
                hash = (hash * 397) ^ GroupId.GetHashCode();

                return hash;
            }
        }
    }
}
