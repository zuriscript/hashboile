using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashboile.Utility.Extensions
{
    static class IEnumerableExtension
    {
        public static Queue<T> ToQueue<T>(this IEnumerable<T> input)
        {
            return input == null ?
                null :
                new Queue<T>(input);
        }
    }
}
