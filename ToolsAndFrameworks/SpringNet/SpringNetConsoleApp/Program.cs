using Spring.Context;
using Spring.Context.Support;
using SpringNetConsoleApp.Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IApplicationContext ctx = ContextRegistry.GetContext();
            DemoBase demo = (DemoBase)ctx.GetObject("DemoBase");
            IDemoBase idemo = (IDemoBase)ctx.GetObject("DemoBase");
            Console.WriteLine($"{demo.EasyReturn()}\n{idemo.EasyReturn()}");
        }
    }
}
