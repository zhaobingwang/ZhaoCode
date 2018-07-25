using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncExample
{
    class CancelTask
    {
        static void Main(string[] args)
        {
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;
            var t = Do.ExcuteAsync(token);

            //Thread.Sleep(3000);
            //source.Cancel();

            t.Wait();
            Console.WriteLine($" #{nameof(token.IsCancellationRequested)}:{token.IsCancellationRequested}");
            Console.ReadLine();
        }
    }
    class Do
    {
        public static async Task ExcuteAsync(CancellationToken token)
        {
            if (token.IsCancellationRequested)
            {
                return;
            }
            await Task.Run(() => CircleOutput(token), token);
        }

        private static void CircleOutput(CancellationToken token)
        {
            Console.WriteLine($" #{nameof(CircleOutput)} 方法开始调用");
            const int num = 5;
            for (int i = 0; i < num; i++)
            {
                if (token.IsCancellationRequested)
                {
                    return;
                }
                Console.WriteLine($" * {i + 1}/{num} 完成.");
                Thread.Sleep(1000);
            }
        }
    }
}
