using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace AsyncAndAwaitNetCore
{
    class Program
    {
        //创建计时器
        private static readonly Stopwatch Watch = new Stopwatch();
        static void Main(string[] args)
        {
            //启动计时器
            Watch.Start();
            const string url1 = "http://blog.csdn.net";
            const string url2 = "http://blog.csdn.net/zhaobw831";

            //var result1 = CountCharacter(1, url1);
            //var result2 = CountCharacter(2, url2);

            //以上代码改为如下异步调用
            Task<int> t1 = CountCharacter(1, url1);
            Task<int> t2 = CountCharacter(2, url2);

            for (int i = 0; i < 3; i++)
            {
                ExtraOperation(i + 1);
            }
            //Console.WriteLine($"url1的字符个数:{result1}");
            //Console.WriteLine($"url2的字符个数:{result2}");

            //以上输出代码改为如下异步输出：
            Console.WriteLine($"url1的字符个数:{t1.Result}");
            Console.WriteLine($"url2的字符个数:{t2.Result}");

            Console.ReadKey();
        }

        //private static int CountCharacter(int id, string address)
        //{
        //    var wc = new WebClient();
        //    Console.WriteLine($"开始调用id={id}:{Watch.ElapsedMilliseconds} ms");
        //    var result = wc.DownloadString(address);
        //    Console.WriteLine($"调用完成id={id}:{Watch.ElapsedMilliseconds} ms");
        //    return result.Length;
        //}

        //将以上方法改为异步：
        private static async Task<int> CountCharacter(int id, string address)
        {
            var wc = new WebClient();
            Console.WriteLine($"开始调用id={id}:{Watch.ElapsedMilliseconds} ms");
            var result = await wc.DownloadStringTaskAsync(address);
            Console.WriteLine($"调用完成id={id}:{Watch.ElapsedMilliseconds} ms");
            return result.Length;
        }

        private static void ExtraOperation(int id)
        {
            var str = "";
            for (int i = 0; i < 10000; i++)
            {
                str += i;
            }
            Console.WriteLine($"id={id}的ExtraOperation()完成：{Watch.ElapsedMilliseconds} ms");
        }
    }
}
