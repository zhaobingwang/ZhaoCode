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
            if (!dict.ContainsKey("Id"))
                dict.Add("Id", "10001");
            dict.Add("Name", "李四");
            if (!dict.ContainsKey("Name"))
                dict.Add("Name", "张三");
            else
                dict["Name"] = "张三";
            dict.AddOrReplace("Name", "李四");


            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key}:{item.Value}");
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
    }

}
