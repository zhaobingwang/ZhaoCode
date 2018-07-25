using System;
using System.Diagnostics;
using System.Net;

namespace WithoutAsyncExample
{
    class WithoutAsyncExample
    {
        private static readonly Stopwatch watch = new Stopwatch();
        static void Main(string[] args)
        {
            watch.Start();

            const string url1 = "https://www.dotnetfoundation.org/";
            const string url2 = "https://www.dotnetfoundation.org/about";

            var result1 = CountCharacters(1, url1);
            var result2 = CountCharacters(2, url2);

            Console.WriteLine($" # [{url1}] 的字符数：{result1}");
            Console.WriteLine($" # [{url2}] 的字符数：{result2}");
            Console.WriteLine($" * [END] [{watch.ElapsedMilliseconds} ms]");

            Console.ReadLine();
        }

        private static int CountCharacters(int id, string url)
        {
            var wc = new WebClient();
            Console.WriteLine($" * 开始调用 id={id},[{watch.ElapsedMilliseconds} ms]");
            var result = wc.DownloadString((url));
            Console.WriteLine($" * 调用完成 id={id},[{watch.ElapsedMilliseconds} ms]");
            return result.Length;
        }
    }
}
