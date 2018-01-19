using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExampleCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Task taskA = Task.Run(() => Thread.Sleep(3000));
            Console.WriteLine($"taskA Status:{taskA.Status}");
            try
            {
                taskA.Wait(1000);
                bool completed = taskA.IsCompleted;
                Console.WriteLine($"taskA completed:{completed},Status：{taskA.Status}");
                if (!completed)
                    Console.WriteLine("Tiem out before taksA completed");
            }
            catch (AggregateException)
            {
                Console.WriteLine("Exception in taskA");
            }
        }
    }
}
