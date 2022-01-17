using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using StudentsOperations;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace IntroOOP
{
    /// <summary>Класс главной программы</summary>
    public static class Program
    {
        private const string __NamesFileName = "FIO.txt";
        private const string __StudentsFileName = "students.txt";
        private const int __StudentsCount = 1000;

        public static void Main(string[] args)
        {
            //string[] last_names;
            //string[] first_names;
            //string[] patronymics;

            //GetFIOs(__NamesFileName, out last_names, out first_names, out patronymics);

            GetFIOs(__NamesFileName, out var last_names, out var first_names, out var patronymics);

            var students_file = CreateStudents(__StudentsFileName, __StudentsCount, last_names, first_names, patronymics);

            var students = EnumStudents(students_file);

            foreach (var student in students/*.Where(student => student.Rating > 94)*/)
                if (student.Rating > 94)
                {
                    //Console.WriteLine("[{0,4}] {1} {2} {3} - {4:0.0#}",
                    //    student.Id,
                    //    student.LastName, student.FirstName, student.Patronymic,
                    //    student.Rating);
                    Console.WriteLine(student);
                }

            var best_students_count = students.Count(s => s.Rating > 75);
            var last_students_count = students.Count(s => s.Rating < 30);

            var top_5_students = students.OrderByDescending(s => s.Rating).Take(5).ToArray();

            Console.ReadLine();
        }

        private static void GetFIOs(
            string SourceFilePath,
            out string[] LastNames,
            out string[] FirstNames,
            out string[] Patronymics)
        {
            if (!File.Exists(SourceFilePath))
                throw new FileNotFoundException("Файл с данными ФИО не найден", SourceFilePath);

            var last_names = new List<string>();
            var first_names = new List<string>();
            var patronymics = new List<string>();


            using (var file = File.OpenText(SourceFilePath))
                while (!file.EndOfStream)
                {
                    var line = file.ReadLine();
                    if (line!.Length == 0) continue;

                    var elements = line.Split(' ');
                    //if (elements.Length != 3) throw new FormatException("Неверный формат файла!");

                    if (elements.Length < 3) continue;

                    last_names.Add(elements[0]);
                    first_names.Add(elements[1]);
                    patronymics.Add(elements[2]);
                }

            LastNames = last_names.ToArray();
            FirstNames = first_names.ToArray();
            Patronymics = patronymics.ToArray();
        }

        private static FileInfo CreateStudents(
            string StudentsFilePath,
            int Count,
            string[] LastNames,
            string[] FirstNames,
            string[] Patronymics)
        {
            var rnd = new Random();

            var serialize_options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true,
            };

            //using (var file = new StreamWriter(new BufferedStream(new FileStream(StudentsFilePath, FileMode.Create, FileAccess.Write, FileShare.Read)), Encoding.UTF8, 1024))
            //using (var file = new StreamWriter(new FileStream(StudentsFilePath, FileMode.Create, FileAccess.Write, FileShare.Read), Encoding.UTF8, 1024))
            //using (var file = new StreamWriter(StudentsFilePath))
            using (var json = File.CreateText(Path.ChangeExtension(StudentsFilePath, ".json")))
            using (var file = File.CreateText(StudentsFilePath))
            {
                json.WriteLine('[');

                for (var i = 0; i < Count; i++)
                {
                    var student = new Student
                    {
                        Id = i + 1,
                        LastName = LastNames[rnd.Next(LastNames.Length)],
                        FirstName = FirstNames[rnd.Next(FirstNames.Length)],
                        Patronymic = Patronymics[rnd.Next(Patronymics.Length)],
                        Rating = rnd.NextDouble() * 100
                    };

                    file.WriteLine(string.Join(",",
                        student.Id,
                        student.LastName, student.FirstName, student.Patronymic,
                        student.Rating.ToString("0.0#", CultureInfo.InvariantCulture)));

                    var json_string = JsonSerializer.Serialize(student, serialize_options);
                    if (i > 0)
                        json.WriteLine(',');
                    json.Write(json_string);
                }

                json.Write("\r\n]");
            }

            return new FileInfo(StudentsFilePath);
        }

        private static IEnumerable<Student> EnumStudents(FileInfo StudentsFile)
        {
            foreach (var line in EnumLines(StudentsFile))
            {
                if (line is null || line.Length == 0) continue;

                var elements = line.Split(',');
                if (elements.Length != 5) continue;

                var student = new Student
                {
                    Id = int.Parse(elements[0]),
                    LastName = elements[1],
                    FirstName = elements[2],
                    Patronymic = elements[3],
                    Rating = double.Parse(elements[4], CultureInfo.InvariantCulture),
                };

                yield return student;
            }
        }

        private static IEnumerable<string> EnumLines(FileInfo file)
        {
            //if (!file.Exists)
            //    throw new FileNotFoundException("Файл данных не найден", file.FullName);
            if (!file.Exists || file.Length == 0)
                yield break;

            using var reader = file.OpenText();
            while (!reader.EndOfStream)
                yield return reader.ReadLine()!;
        }
    }
}