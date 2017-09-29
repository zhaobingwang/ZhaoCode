using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceTools.Polly.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var retryPolicy = Policy
                    .Handle<DivideByZeroException>()
                    .Retry(3, (exception, retryCount) =>
                    {
                        Console.WriteLine($"执行异常,重试次数：{retryCount},【异常来自：{exception.GetType().Name}】.");
                    });
                retryPolicy.Execute(() => { PollyDemo.DivideByZero(); });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"失败信息：{ex.Message}");
            }

        }
    }

    class PollyDemo
    {
        public static int DivideByZero()
        {
            int a = 0;
            return 1 / a;
        }
    }
}
