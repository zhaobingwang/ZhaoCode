using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 异步编程基础
            //CallerWithAsync();
            //CallerWithContinuationTask();

            //MultipleAsyncMethods(); //耗时：6008ms
            //MultipleAsyncMethodsWithCombinators1(); //耗时：3008ms
            //MultipleAsyncMethodsWithCombinators2(); //耗时：3007ms

            //Task.Delay(10000).Wait();
            //Console.WriteLine("END"); 
            #endregion

        }
        #region 异步编程基础
        private async static void MultipleAsyncMethodsWithCombinators2()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Task<string> t1 = GreetingAsync("Steven");
            Task<string> t2 = GreetingAsync("Mike");
            string[] result = await Task.WhenAll(t1, t2);
            sw.Stop();
            Console.WriteLine($"t1:{result[0]} \n t2:{result[1]} 耗时：{sw.ElapsedMilliseconds} ms");
        }
        private async static void MultipleAsyncMethodsWithCombinators1()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Task<string> t1 = GreetingAsync("Steven");
            Task<string> t2 = GreetingAsync("Mike");
            await Task.WhenAll(t1, t2);
            sw.Stop();
            Console.WriteLine($"t1:{t1.Result} \n t2:{t2.Result} 耗时：{sw.ElapsedMilliseconds} ms");
        }
        private async static void MultipleAsyncMethods()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string s1 = await GreetingAsync("Steven");
            string s2 = await GreetingAsync("Mike");
            sw.Stop();
            Console.WriteLine($"s1:{s1} \n s2:{s2} 耗时：{sw.ElapsedMilliseconds} ms");
        }
        private static void CallerWithContinuationTask()
        {
            Task<string> t1 = GreetingAsync("Mike");
            t1.ContinueWith(t =>
            {
                string result = t.Result;
                Console.WriteLine(result + "任务完成");
            });
        }

        private async static void CallerWithAsync()
        {
            string result = await GreetingAsync("Jack");
            Console.WriteLine(result);
        }
        static Task<string> GreetingAsync(string name)
        {
            return Task.Run<string>(() =>
            {
                return Greeting(name);
            });
        }
        static string Greeting(string name)
        {
            Task.Delay(3000).Wait();
            return $"Hello,{name}";
        }

        #endregion
    }
}
