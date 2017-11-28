using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Temp
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
            Console.WriteLine($"Current Thread Id:{Thread.CurrentThread.ManagedThreadId}");
            Console.ReadLine();
        }
        static async Task Test()
        {
            await GetName();
        }
        static async Task GetName()
        {
            await Task.Delay(1000);
            Console.WriteLine($"Current Thread Id:{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine("In another thread ...");
        }
    }
}
