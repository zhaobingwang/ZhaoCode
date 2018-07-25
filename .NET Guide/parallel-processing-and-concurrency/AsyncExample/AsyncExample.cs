using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace AsyncExample
{
    class AsyncExample
    {
        private static readonly Stopwatch watch = new Stopwatch();
        static void Main(string[] args)
        {
            watch.Start();

            const string url1 = "https://www.dotnetfoundation.org/";
            const string url2 = "https://www.dotnetfoundation.org/about";

            var result1 = CountCharacters(1, url1);
            var result2 = CountCharacters(2, url2);


            Console.WriteLine($" # [{url1}] 的字符数：{result1.Result}");
            Console.WriteLine($" # [{url2}] 的字符数：{result2.Result}");
            Console.WriteLine($" * [END] [{watch.ElapsedMilliseconds} ms]");
            Console.ReadLine();
        }

        private static async Task<int> CountCharacters(int id, string url)
        {
            var wc = new WebClient();
            Console.WriteLine($" * 开始调用 id={id},[{watch.ElapsedMilliseconds} ms]");
            var result = await wc.DownloadStringTaskAsync((url));
            Console.WriteLine($" * 调用完成 id={id},[{watch.ElapsedMilliseconds} ms]");
            return result.Length;
        }
    }
}
