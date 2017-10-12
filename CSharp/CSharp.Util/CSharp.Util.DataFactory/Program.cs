using CSharp.Util.DataFactory.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Util.DataFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context();
            context.Database.CreateIfNotExists();
            Console.WriteLine("success");
        }
    }
}
