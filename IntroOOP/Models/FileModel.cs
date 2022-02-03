using IntroOOP.Models.Base;

namespace IntroOOP.Models;

public class FileModel : FileSystemItemModel
{
    private readonly FileInfo _File;

    public string Name => _File.Name;

    public string Extension => _File.Extension;

    public bool Exist => _File.Exists;

    public FileModel(string FilePath) : this(new FileInfo(FilePath))
    {

    }

    public FileModel(FileInfo File)
    {
        _File = File;
    }

    public IEnumerable<string> EnumerateLines()
    {
        if (!_File.Exists)
            throw new FileNotFoundException("Файл не найден", _File.FullName);

        using var reader = _File.OpenText();
        while (!reader.EndOfStream)
            yield return reader.ReadLine()!;
    }
}