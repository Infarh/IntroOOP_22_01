using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroOOP.Infrastructure.Extensions
{
    public static class FileInfoExtensions
    {
        public static IEnumerable<string> EnumLines(this FileInfo file)
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
