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
            var vectors = Enumerable.Range(1, 1000)
               .Select(
                    i => new Vector2D(
                        X: (Random.Shared.NextDouble() - 0.5) * 200,
                        Y: (Random.Shared.NextDouble() - 0.5) * 200))
               .ToList();

            vectors.Sort();

            //string[] last_names;
            //string[] first_names;
            //string[] patronymics;

            //GetFIOs(__NamesFileName, out last_names, out first_names, out patronymics);

            //var (lasts, firsts, patrons) = GetFIOs(__NamesFileName);

            GetFIOs(__NamesFileName, out var last_names, out var first_names, out var patronymics);

            var students_file = CreateStudents(__StudentsFileName, __StudentsCount, last_names, first_names, patronymics);

            var students = EnumStudents(students_file);

            //foreach (var (id, last, first, patronymic) in students/*.Where(student => student.Rating > 94)*/)
            foreach (var student in students/*.Where(student => student.Rating > 94)*/)
                if (student.Rating > 94)
                {
                    //Console.WriteLine("[{0,4}] {1} {2} {3} - {4:0.0#}",
                    //    student.Id,
                    //    student.LastName, student.FirstName, student.Patronymic,
                    //    student.Rating);
                    Console.WriteLine(student);

                    //var (id, last, first, patronymic) = student;
                    //student.Deconstruct(out var id, out var last, out var first, out var patron);
                }

            //foreach (var (_, last_name, _, _) in students)
            //{
            //    Console.WriteLine(last_name);
            //}

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

                    //last_names.Add(elements[0]);
                    //first_names.Add(elements[1]);
                    //patronymics.Add(elements[2]);

                    var (last, first, patron) = elements;

                    last_names.Add(last);
                    first_names.Add(first);
                    patronymics.Add(patron);
                }

            LastNames = last_names.ToArray();
            FirstNames = first_names.ToArray();
            Patronymics = patronymics.ToArray();
        }

        public readonly struct FIOs
        {
            public string[] LastNames { get; init; }
            public string[] FirstNames { get; init; }
            public string[] Patronymics { get; init; }

            public void Deconstruct(out string[] LastNames, out string[] FirstNames, out string[] Patronymics)
            {
                LastNames = this.LastNames;
                FirstNames = this.FirstNames;
                Patronymics = this.Patronymics;
            }
        }

        //private static FIOs GetFIOs(string SourceFilePath)
        //{
        //    if (!File.Exists(SourceFilePath))
        //        throw new FileNotFoundException("Файл с данными ФИО не найден", SourceFilePath);

        //    var last_names = new List<string>();
        //    var first_names = new List<string>();
        //    var patronymics = new List<string>();


        //    using (var file = File.OpenText(SourceFilePath))
        //        while (!file.EndOfStream)
        //        {
        //            var line = file.ReadLine();
        //            if (line!.Length == 0) continue;

        //            var elements = line.Split(' ');
        //            //if (elements.Length != 3) throw new FormatException("Неверный формат файла!");

        //            if (elements.Length < 3) continue;

        //            last_names.Add(elements[0]);
        //            first_names.Add(elements[1]);
        //            patronymics.Add(elements[2]);
        //        }

        //    //LastNames = last_names.ToArray();
        //    //FirstNames = first_names.ToArray();
        //    //Patronymics = patronymics.ToArray();

        //    return new FIOs
        //    {
        //        LastNames = last_names.ToArray(),
        //        FirstNames = first_names.ToArray(),
        //        Patronymics = patronymics.ToArray(),
        //    };
        //}

        //public readonly struct FIOs
        //{
        //    public string[] LastNames { get; init; }
        //    public string[] FirstNames { get; init; }
        //    public string[] Patronymics { get; init; }
        //}

        //public record struct FIOs(string[] LastNames, string[] FirstNames, string[] Patronymics);

        //private static FIOs GetFIOs(string SourceFilePath)
        //{
        //    if (!File.Exists(SourceFilePath))
        //        throw new FileNotFoundException("Файл с данными ФИО не найден", SourceFilePath);

        //    var last_names = new List<string>();
        //    var first_names = new List<string>();
        //    var patronymics = new List<string>();


        //    using (var file = File.OpenText(SourceFilePath))
        //        while (!file.EndOfStream)
        //        {
        //            var line = file.ReadLine();
        //            if (line!.Length == 0) continue;

        //            var elements = line.Split(' ');
        //            //if (elements.Length != 3) throw new FormatException("Неверный формат файла!");

        //            if (elements.Length < 3) continue;

        //            last_names.Add(elements[0]);
        //            first_names.Add(elements[1]);
        //            patronymics.Add(elements[2]);
        //        }

        //    //LastNames = last_names.ToArray();
        //    //FirstNames = first_names.ToArray();
        //    //Patronymics = patronymics.ToArray();

        //    return new FIOs(last_names.ToArray(), first_names.ToArray(), patronymics.ToArray());
        //    //{
        //    //    LastNames = last_names.ToArray(),
        //    //    FirstNames = first_names.ToArray(),
        //    //    Patronymics = patronymics.ToArray(),
        //    //};
        //}

        private static (string[] LastNames, string[] FirstNames, string[] Patronymics) GetFIOs(string SourceFilePath)
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

            //LastNames = last_names.ToArray();
            //FirstNames = first_names.ToArray();
            //Patronymics = patronymics.ToArray();

            return (last_names.ToArray(), first_names.ToArray(), patronymics.ToArray());
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

        //private static IEnumerable<Student> EnumStudents(FileInfo StudentsFile)
        //{
        //    //foreach (var line in EnumLines(StudentsFile))
        //    foreach (var line in StudentsFile.EnumLines())
        //    {
        //        if (line is null || line.Length == 0) continue;

        //        var elements = line.Split(',');
        //        if (elements.Length != 5) continue;

        //        var student = new Student
        //        {
        //            Id = int.Parse(elements[0]),
        //            LastName = elements[1],
        //            FirstName = elements[2],
        //            Patronymic = elements[3],
        //            Rating = double.Parse(elements[4], CultureInfo.InvariantCulture),
        //        };

        //        yield return student;
        //    }
        //}

        private static IEnumerable<Student> EnumStudents(FileInfo StudentsFile) =>
            StudentsFile
               .EnumLines()
               .Where(line => line != null && line.Length > 0)
               .Select(line => line.Split(','))
               .Where(elements => elements.Length == 5)
               .Select(elements => new Student
               {
                   Id = int.Parse(elements[0]),
                   LastName = elements[1],
                   FirstName = elements[2],
                   Patronymic = elements[3],
                   Rating = double.Parse(elements[4], CultureInfo.InvariantCulture),
               });

        //private static IEnumerable<string> EnumLines(FileInfo file)
        //{
        //    //if (!file.Exists)
        //    //    throw new FileNotFoundException("Файл данных не найден", file.FullName);
        //    if (!file.Exists || file.Length == 0)
        //        yield break;

        //    using var reader = file.OpenText();
        //    while (!reader.EndOfStream)
        //        yield return reader.ReadLine()!;
        //}
    }
}