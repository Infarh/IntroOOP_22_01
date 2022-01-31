using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsOperations.Extensions
{
    public static class EnumerableEx
    {
        public static void Foreach<T>(this IEnumerable<T> items, Action<T> action)
        {
            switch (items)
            {
                case T[] array:
                    for(var i = 0; i < array.Length; i++)
                        action(array[i]);
                    break;

                case List<T> list:
                    for (var i = 0; i < list.Count; i++)
                        action(list[i]);
                    break;

                case IList<T> list:
                    for (var i = 0; i < list.Count; i++)
                        action(list[i]);
                    break;

                default:
                    foreach (var item in items)
                    {
                        action(item);
                    }
                    break;
            }
        }
    }
}
