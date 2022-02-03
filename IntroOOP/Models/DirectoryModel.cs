using IntroOOP.Models.Base;

namespace IntroOOP.Models;

public class DirectoryModel : FileSystemItemModel
{
    private readonly DirectoryInfo _Directory;

    public string Name => _Directory.Name;

    public string Extension => _Directory.Extension;

    public bool Exist => _Directory.Exists;

    public long TotalLength => _Directory
       .EnumerateFiles("*.*", SearchOption.AllDirectories)
       .Sum(f => f.Length);

    public long GetTotalLength() => _Directory
       .EnumerateFiles("*.*", SearchOption.AllDirectories)
       .Sum(f => f.Length);

    public DirectoryModel(string DirectoryPath) : this(new DirectoryInfo(DirectoryPath))
    {

    }

    public DirectoryModel(DirectoryInfo Directory) => _Directory = Directory;

    public DirectoryInfo[] GetDirectories(string? Mask = null)
    {
        if (Mask is null)
            return _Directory.GetDirectories();

        return _Directory.GetDirectories(Mask);
    }

    public FileInfo[] GetFiles(string? Mask = null)
    {
        if (Mask is null)
            return _Directory.GetFiles();

        return _Directory.GetFiles(Mask);
    }

    public IEnumerable<DirectoryModel> EnumerateDirectories(string? Mask = null)
    {
        //if (Mask is null)
        //    return _Directory.EnumerateDirectories();

        //return _Directory.EnumerateDirectories(Mask);

        var files = Mask is null
            ? _Directory.EnumerateDirectories()
            : _Directory.EnumerateDirectories(Mask);

        foreach (var directory in files)
            yield return (DirectoryModel)directory;
        //yield return new DirectoryModel(directory);
    }

    public IEnumerable<FileModel> EnumerateFiles(string? Mask = null)
    {
        if (Mask is null)
            return _Directory.EnumerateFiles().Select(file => new FileModel(file));

        return _Directory.EnumerateFiles(Mask).Select(file => new FileModel(file));
    }

    public IEnumerable<FileSystemItemModel> EnumerateContent(string? Mask = null)
    {
        //if (Mask is null)
        //    return _Directory.EnumerateFileSystemInfos();

        //return _Directory.EnumerateFileSystemInfos(Mask);

        var items = Mask is null
            ? _Directory.EnumerateFileSystemInfos()
            : _Directory.EnumerateFileSystemInfos(Mask);

        //foreach (var item in items)
        //    switch (item)
        //    {
        //        case FileInfo file:
        //            yield return new FileModel(file);
        //            break;

        //        case DirectoryInfo dir:
        //            yield return new DirectoryModel(dir);
        //            break;
        //    }

        return items.Select<FileSystemInfo, FileSystemItemModel>(item => item switch
        {
            FileInfo file => new FileModel(file),
            DirectoryInfo dir => new DirectoryModel(dir),
            _ => throw new InvalidOperationException("Неподдерживаемый тип данных " + item.GetType())
        });
    }

    public FileModel[] GetFiles(int Skip, int Count)
    {
        return EnumerateFiles()
           .Skip(Skip)
           .Take(Count)
           .ToArray();
    }

    public FilesPage GetFilesPage(int Index, int Size)
    {
        var all_files = EnumerateFiles();
        var page_files = all_files.Skip(Index * Size).Take(Size).ToArray();
        var total_count = all_files.Count();

        return new FilesPage(Index, page_files.Length, Size, page_files, total_count);
    }

    public static implicit operator DirectoryInfo(DirectoryModel model) => model._Directory;

    public static explicit operator DirectoryModel(DirectoryInfo dir) => new DirectoryModel(dir);
}

public class FilesPage
{
    public int Index { get; }

    public int Count { get; }

    public int Size { get; }

    public IEnumerable<FileModel> Files { get; }

    public int TotalCount { get; }

    public int PagesCount => (int)Math.Floor((double)TotalCount / Size);

    public FilesPage(int Index, int Count, int Size, IEnumerable<FileModel> Files, int TotalCount)
    {
        this.Index = Index;
        this.Count = Count;
        this.Size = Size;
        this.Files = Files;
        this.TotalCount = TotalCount;
    }
}