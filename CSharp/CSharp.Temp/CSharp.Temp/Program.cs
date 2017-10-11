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


            var testdata = "D1213";
            string result = string.Empty;
            dict.TryGetValue(testdata, out result);
            //在工作中用到这个方法,做了个不严谨的操作,当执行完这段代码后,如果值不在字典中,最后out一个控制,没有进行非空校验就进行后续操作;
            //update2017-10-11
            if (!string.IsNullOrEmpty(result))
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("测试数据不在字典中");
            }

        }
    }
}
