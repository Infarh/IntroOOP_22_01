using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

using StudentsOperations;

namespace IntroOOP;

internal static class SerializersTest
{
    public static void Run()
    {
        var student = new Student
        {
            Id = 45,
            LastName = "Иванов",
            FirstName = "Иван",
            Patronymic = "Иванович",
            Rating = 78.5,
            GroupId = 15,
        };

        var xml_serializer = new XmlDataSerializer<Student>();
        var json_serializer = new JsonSerializer<Student>();
        var bin_serializer = new BinarySerializer<Student>();

        Serialize(student, xml_serializer, "student.xml");
        Serialize(student, json_serializer, "student.json");
        Serialize(student, bin_serializer, "student.bin");

        var stud1 = Deserialize("student.xml", xml_serializer);
        var stud2 = Deserialize("student.json", json_serializer);
        var stud3 = Deserialize("student.bin", bin_serializer);
    }

    private static void Serialize(Student student, DataSerializer<Student> Serializer, string FileName)
    {
        using var data_stream = File.Create(FileName);
        Serializer.Serialize(student, data_stream);
    }

    public static void SerializeUniversal(Student student, DataSerializer<Student> Serializer, string FileName)
    {
        var ext = Path.GetExtension(FileName);

        switch (ext.ToLower())
        {
            case ".xml":
                Serialize(student, new XmlDataSerializer<Student>(), FileName);
                break;

            case ".json":
                Serialize(student, new JsonSerializer<Student>(), FileName);

                break;

            case ".bin":
                Serialize(student, new BinarySerializer<Student>(), FileName);
                break;

            default:
                throw new InvalidOperationException("Непонятное расширение файла - " + ext);
        }
    }

    private static Student Deserialize(string FileName, DataSerializer<Student> Serializer)
    {
        using (var data_stream = File.Open(FileName, FileMode.Open, FileAccess.Read))
        {
            return Serializer.Deserialize(data_stream);
        }
    }

    private static Student DeserializeUniversal(string FileName)
    {
        var ext = Path.GetExtension(FileName);

        switch (ext.ToLower())
        {
            case ".xml":
                return Deserialize(FileName, new XmlDataSerializer<Student>());

            case ".json":
                return Deserialize(FileName, new JsonSerializer<Student>());

            case ".bin":
                return Deserialize(FileName, new BinarySerializer<Student>());

            default:
                throw new InvalidOperationException("Непонятное расширение файла - " + ext);
        }
    }
}

public abstract class DataSerializer<T>
{
    public abstract void Serialize(T value, Stream stream);

    public abstract T Deserialize(Stream stream);
}

public class XmlDataSerializer<T> : DataSerializer<T>
{
    private readonly XmlSerializer _Serializer = new(typeof(T));

    public override void Serialize(T value, Stream stream)
    {
        _Serializer.Serialize(stream, value);
    }

    public override T Deserialize(Stream stream)
    {
        return (T)_Serializer.Deserialize(stream)!;
    }
}

public class JsonSerializer<T> : DataSerializer<T>
{
    public override void Serialize(T value, Stream stream)
    {
        var writer = new Utf8JsonWriter(stream);
        JsonSerializer.Serialize(writer, value);
    }

    public override T Deserialize(Stream stream)
    {
        return JsonSerializer.Deserialize<T>(stream)!;
    }
}

public class BinarySerializer<T> : DataSerializer<T>
{
    private readonly BinaryFormatter _Serializer = new BinaryFormatter();

    public override void Serialize(T value, Stream stream)
    {
        _Serializer.Serialize(stream, value);
    }

    public override T Deserialize(Stream stream)
    {
        return (T)_Serializer.Deserialize(stream);
    }
}