using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Temp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //string a = "10.1235";
            //Console.WriteLine(a);
            //Console.WriteLine(decimal.Parse(a).ToString("0.000"));
            //Console.WriteLine("********************\n");

            //string str = "1,2,3,";
            //string str2 = "";
            //Console.WriteLine(str.IndexOf('4'));

            //Console.WriteLine("a");
            //Console.WriteLine(str.Trim(','));
            //Console.WriteLine(str2.Trim(',')+"A");
            var key=GetKeyFromDict("AGE");
            if (string.IsNullOrEmpty(key))
            {
                Console.WriteLine("1");
            }
            Console.WriteLine(key);
        }
        public static string GetKeyFromDict(string sourcekey)
        {
            string result = string.Empty;
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("NAME", "Name");
            dict.Add("AGE", "Age");
            dict.TryGetValue(sourcekey, out result);
            return result;
        }
    }
}
