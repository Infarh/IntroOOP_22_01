using System.IO;

using static System.Net.WebRequestMethods;

namespace IntroOOP
{
    public static class FileOperations
    {
        public static void Test()
        {
            //var file = new FileInfo(@"c:\123\file.txt");

            var dir = new DirectoryModel("C:\\123");

            var files = dir.EnumerateFiles();

            //var large_files = files.Where(f => f.Length > 1024 * 1024 * 100);

            //var large_files_count = large_files.Count();
            //var large_files_total_length = large_files.Sum(f => f.Length);
        }
    }

    internal abstract class FileSystemItemModel
    {

    }

    internal class DirectoryModel : FileSystemItemModel
    {
        private readonly DirectoryInfo _Directory;

        public string Name => _Directory.Name;

        public string Extension => _Directory.Extension;

        public bool Exist => _Directory.Exists;

        //public long TotalLength => 

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

        public static implicit operator DirectoryInfo(DirectoryModel model) => model._Directory;

        public static explicit operator DirectoryModel(DirectoryInfo dir) => new DirectoryModel(dir);
    }

    internal class FileModel : FileSystemItemModel
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
}
