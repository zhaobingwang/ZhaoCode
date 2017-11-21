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
            //https://www.cnblogs.com/mq0036/p/3707474.html
            //Console.BackgroundColor = ConsoleColor.Blue; //设置背景色
            //Console.ForegroundColor = ConsoleColor.White; //设置前景色，即字体颜色
            //Console.WriteLine("第一行白蓝.");
            //Console.ResetColor(); //将控制台的前景色和背景色设为默认值
            //Console.BackgroundColor = ConsoleColor.Green;
            //Console.ForegroundColor = ConsoleColor.DarkGreen;
            //string str = "第三行 绿暗绿";
            //Console.WriteLine(str.PadRight(Console.BufferWidth - (str.Length % Console.BufferWidth))); //设置一整行的背景色
            //Console.ResetColor();
            Console.Write("这是一个");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("测试");
            Console.ResetColor();
            Console.Write("内容");
            Console.ResetColor();
            Console.Read();
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
