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
        public static int random = 10;
        static void Main(string[] args)
        {
            try
            {
                //Retry();
                //WaitandRetryForeverUntilSuccess();
                //WaitAndRetry();
                var circuitBreaker = Policy.Handle<DivideByZeroException>()
                    .CircuitBreaker(3, TimeSpan.FromMinutes(1))
                    .Execute(() => DivideByZero(10));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"失败信息：{ex.Message}");
            }

        }

        /// <summary>
        /// Retry
        /// </summary>
        public static void Retry()
        {
            var retry = Policy
                .Handle<DivideByZeroException>()
                .Retry(3, (exception, retryCount) =>
                {
                    Console.WriteLine($"执行异常,重试次数：{retryCount},【异常来自：{exception.GetType().Name}】.");
                });
            retry.Execute(() => { DivideByZero(random); });
        }

        /// <summary>
        /// Wait and retry
        /// </summary>
        public static void WaitAndRetry()
        {
            var retry = Policy
                .Handle<DivideByZeroException>()
                .WaitAndRetry(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(1, retryAttempt)),
                (exception, timespan, retryCount, context) =>
                {
                    Console.WriteLine($"重试,[当前随机数为{random}] [retrycount{retryCount}] [异常来自：{exception.GetType().Name}] [{timespan}]");
                    random = new Random().Next(10, 50);
                    if (random == 25)
                        Console.WriteLine($"成功,随机数为{random}");
                });
            retry.Execute(() => DivideByZero(random));
        }

        /// <summary>
        /// Wait and retry forever (until succeeds)
        /// </summary>
        public static void WaitandRetryForeverUntilSuccess()
        {
            var retryForever = Policy
                        .Handle<DivideByZeroException>()
                        .WaitAndRetryForever(retryAttempt => TimeSpan.FromSeconds(Math.Pow(1, retryAttempt)), (exception, timespan) =>
                        {
                            Console.WriteLine($"重试,[当前随机数为{random}][异常来自：{exception.GetType().Name}] [{timespan}]");
                            random = new Random().Next(10, 50);
                            if (random == 25)
                                Console.WriteLine($"成功,随机数为{random}");
                        });
            retryForever.Execute(() => { DivideByZero(random); });
        }

        public static int DivideByZero(int random)
        {
            //int a = 0;
            if (random != 25) random = 0;
            return 100 / random;
        }
    }
}
