using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlChanger
{
   public static class CollectionHelper
    {
        public static TValue GetValueOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key, TValue defaultVal = default)
        {
            return key == null ? defaultVal : dictionary.TryGetValue(key, out var ret) ? ret : defaultVal;
        }
    }
}
