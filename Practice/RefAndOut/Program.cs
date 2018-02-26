using System;

namespace RefAndOut
{
    class Program
    {
        static void Method(ref int i)
        {
            i = 1;
        }
        static void Method2(out int i)
        {
            i =2;
        }
        static void Main(string[] args)
        {
            int val=0;
            Method(ref val);
            System.Console.WriteLine(val);

            int val2;
            Method2(out val2);
            System.Console.WriteLine(val2);
        }
    }
}
