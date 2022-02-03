using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroOOP.Infrastructure.Extensions
{
    internal static class ArraysExtensions
    {
        public static void Deconstruct<T>(this T[] array, out T arg0, out T arg1, out T arg2)
        {
            if (array.Length < 3)
                throw new ArgumentOutOfRangeException(nameof(array));

            arg0 = array[0];
            arg1 = array[1];
            arg2 = array[2];
        }
    }
}
