using System;

namespace Csharp7.Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            (int x,int y) point = (1, 2);
            Console.WriteLine($"x:{point.x},y:{point.y}");
        }
    }
}
