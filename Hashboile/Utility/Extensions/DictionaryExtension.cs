using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashboile.Utility.Extensions
{
    public static class DictionaryExtension
    {
        public static TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, Func<TKey,TValue> factory)
        {
            if (!dict.TryGetValue(key, out TValue val))
            {
                val = factory(key);
                dict.Add(key, val);
            }

            return val;
        }
    }
}
