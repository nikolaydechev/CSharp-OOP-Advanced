using System.Collections.Generic;
using System.Linq;

namespace _07.CustomList
{
    public class Sorter
    {
        public static IList<T> Sort<T>(IList<T> list)
        {
            return list.OrderBy(x => x).ToList();
        }
    }
}
