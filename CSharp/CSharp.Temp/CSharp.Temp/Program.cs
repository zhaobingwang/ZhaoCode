using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CSharp.Temp
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Name", "李四");
            string v = "defaultValue";


            //if (dict.ContainsKey("Name"))
            //{
            //    v = dict["Name"];
            //}

            //dict.TryGetValue("Name1", out v);

            string resullt = dict.GetValue("Nam1e");

            var dict1 = new Dictionary<string, string>().AddOrReplace("name1", "zhansgasn");
            var dict2 = new Dictionary<string, string>().AddOrReplace("name2", "lisi");
            dict.AddRange(dict1, false).AddRange(dict2, true);
            foreach (var item in dict)
            {
                Console.WriteLine(item.Value);
            }
        }
    }

    public static class DictionaryExtension
    {
        public static Dictionary<TKey, TValue> TryAdd<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            if (!dict.ContainsKey(key))
                dict.Add(key, value);
            return dict;
        }

        public static Dictionary<TKey, TValue> AddOrReplace<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            dict[key] = value;
            return dict;
        }

        public static TValue GetValue<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value = default(TValue))
        {
            return dict.ContainsKey(key) ? dict[key] : value;
        }

        public static Dictionary<TKey, TValue> AddRange<TKey, TValue>(this Dictionary<TKey, TValue> dict, IEnumerable<KeyValuePair<TKey, TValue>> values, bool replaceExisted)
        {
            foreach (var item in values)
            {
                if (!dict.ContainsKey(item.Key)  || replaceExisted)
                    dict[item.Key] = item.Value;
            }
            return dict;
        }
    }

}
