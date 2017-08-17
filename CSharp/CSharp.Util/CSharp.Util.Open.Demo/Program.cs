using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Util.Open.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;
            DateTime birthday = new DateTime(1999, 8, 8, 12, 12, 12);
            int age=Unclassified.GetAge(birthday, now);
            Console.WriteLine(age);
            Console.ReadKey();
        }
    }
}
