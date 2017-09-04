using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Temp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "10.1235";
            Console.WriteLine(a);
            Console.WriteLine(decimal.Parse(a).ToString("0.000"));
        }
    }
}
