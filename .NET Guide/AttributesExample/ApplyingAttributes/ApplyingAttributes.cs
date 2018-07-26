using System;

namespace ApplyingAttributes
{
    class ApplyingAttributes
    {
        static void Main(string[] args)
        {
            int i = Example.Add(1, 2);
            Console.WriteLine(i);
        }
    }
    class Example
    {
        [Obsolete("将在下一个版本中删除")]
        public static int Add(int a, int b)
        {
            return (a + b);
        }
    }
}
