using System;

namespace ValueTypeAndReferenceType
{
    class Program
    {
        private string str = "Program.str";
        private int i = 0;
        static void StringConvert(string str)
        {
            str = "string being converted";
        }
        static void StringConvert(Program p)
        {
            p.str = "string being converted";
        }
        static void Add(int i)
        {
            i++;
        }
        static void AddWithRef(ref int i)
        {
            i++;
        }

        static void Main(string[] args)
        {
            int i1 = 10, i2 = 20;
            string str = "str";
            Program p = new Program();
            Add(i1);
            AddWithRef(ref i2);
            Add(p.i);
            StringConvert(str);
            StringConvert(p);
            System.Console.WriteLine(i1);
            System.Console.WriteLine(i2);
            System.Console.WriteLine(p.i);
            System.Console.WriteLine(str);
            System.Console.WriteLine(p.str);
        }
    }
}
