using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XmlChanger
{
   public static class ExtensionMethods
    {
        public static TValue GetValueOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key, TValue defaultVal = default)
        {
            return key == null ? defaultVal : dictionary.TryGetValue(key, out var ret) ? ret : defaultVal;
        }

        public static string ConvertToString(this XElement el)
        {
            var reader = el.CreateReader();
            reader.MoveToContent();
            return reader.ReadOuterXml();
        }
    }
}
