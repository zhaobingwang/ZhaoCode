using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceTools.Polly
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //var retryTwoTimesPolicy = Policy
                //    .Handle<DivideByZeroException>()
                //    .Retry(3, (ex, count) =>
                //    {
                //        Console.WriteLine($"失败，重试次数{count}");
                //        Console.WriteLine($"异常来自{ex.GetType().Name}");
                //    });
                //retryTwoTimesPolicy.Execute(() =>
                //{
                //    Compute();
                //});

                var politicaWaitAndRetry = Policy
                    .Handle<DivideByZeroException>()
                    .WaitAndRetry(new[] {
                        TimeSpan.FromSeconds(1),
                        TimeSpan.FromSeconds(3),
                        TimeSpan.FromSeconds(5),
                        TimeSpan.FromSeconds(7),
                    }, ReportError);
                politicaWaitAndRetry.Execute(() =>
                {
                    //ZeroException();
                });
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"失败信息：{ex.Message}");
            }
        }

        static int Compute()
        {
            int a = 0;
            return 1 / a;
        }
        static void ZeroException()
        {
            throw new DivideByZeroException();
        }
        static void ReportError(Exception e,TimeSpan ts,int intento,Context context)
        {
            Console.WriteLine($"异常{intento:00}[调用耗时：{ts.Seconds}秒] [执行时间：{DateTime.Now}]");
        }
    }
}
