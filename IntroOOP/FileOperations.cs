using System.IO;
using IntroOOP.Models;
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
}
