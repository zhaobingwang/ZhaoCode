using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Temp
{
    class Program
    {
        static void Main(string[] args)
        {
            //string test = "2:D121,D123;3D124;";
            string test = "2:D121";
            string[] arr = test.Replace('；', ';').Split(';');
            Dictionary<string, string> dict = new Dictionary<string, string>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!arr[i].Contains(":"))
                {
                    Console.WriteLine("异常");
                    break;
                }
                string _key = arr[i].Split(':')[1];
                string _value = arr[i].Split(':')[0];
                string[] arrkey = _key.Replace('，', ',').Split(',');
                for (int j = 0; j < arrkey.Length; j++)
                {
                    if (dict.ContainsKey(arrkey[j]))
                    {
                        Console.WriteLine("error");
                        break;
                    }
                    dict.Add(arrkey[j], _value);
                }
            }


            var testdata = "D121";
            string result = string.Empty;
            dict.TryGetValue(testdata, out result);
            Console.WriteLine(result);
        }
    }
}
