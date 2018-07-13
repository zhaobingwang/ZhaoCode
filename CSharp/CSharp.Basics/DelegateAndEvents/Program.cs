using System;
using System.Linq;

namespace DelegateAndEvents
{
    class Program
    {
        static int Double(int x) { return x * 2; }
        static int Square(int x) { return x * x; }

        
        static void Main(string[] args)
        {
            //Example example = new Example();
            //example.Datafiltering();

            int[] values = { 1, 2, 3, 4, 5 };
            //Example.Calculate(values, Double);
            Example.Calculate(values, Square);
            foreach (var item in values)
            {
                Console.WriteLine(item);
            }
        }
    }

    public delegate int Calculator(int x);
    public class Example
    {
        public void Datafiltering()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Func<int, bool> foo = tmp => tmp > 5;
            var list = arr.Where(foo).ToList();
            // or
            var list2 = arr.Where(x => x > 5);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        public static void Calculate(int[] values, Calculator calculator)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = calculator(values[i]);
            }
        }
    }
}
