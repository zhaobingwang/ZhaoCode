using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace temp
{
    class Program
    {
        static void Main(string[] args)
        {
            var t1 = new Task(() =>
            {
                Run1();
            });
            var t2 = Task.Factory.StartNew(() =>
            {
                Run2();
            });
            Console.WriteLine("-----调用Start()前-----");
            Console.WriteLine($"t1:{t1.Status}");
            Console.WriteLine($"t2:{t2.Status}");
            t1.Start();
            //t2.Start();

            Console.WriteLine("-----调用Start()后-----");
            Console.WriteLine($"t1:{t1.Status}");
            Console.WriteLine($"t2:{t2.Status}");

            Task.WaitAll(t1, t2);

            Console.WriteLine("-----任务执行完成后-----");
            Console.WriteLine($"t1:{t1.Status}");
            Console.WriteLine($"t2:{t2.Status}");

        }
        private static void Run1()
        {
            Thread.Sleep(1000);
            Console.WriteLine("\n run1.");
        }

        private static void Run2()
        {
            Thread.Sleep(1000);
            Console.WriteLine("\n run2.");
        }
    }
}
