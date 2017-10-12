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
            using (var db = new Context())
            {
                var province = db.Province;
                foreach (var p in province)
                {
                    Console.WriteLine($"Id: {p.Id} \t Name{p.Name}");
                }
            }
            Console.WriteLine("数据播种完成");
            Console.ReadLine();
        }
    }
}
