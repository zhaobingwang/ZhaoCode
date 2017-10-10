using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.New.CSharp7
{
    class Program
    {
        static void Main(string[] args)
        {
            Csharp7New.LocalFunctions();
        }
    }
    class Csharp7New
    {
        /// <summary>
        /// 局部函数(Local functions)
        /// </summary>
        public static void LocalFunctions()
        {
            Console.WriteLine("------- 局部函数 开始 -------");
            Console.WriteLine(Add(1, 3));
            string Add(int a, int b)
            {
                return $"{a}+{b}={a + b}";
            }

            Stopwatch watch = new Stopwatch();
            watch.Start();
            Int64 f1 = Factorial(10000);
            Console.WriteLine($"局部函数递归耗时:{watch.ElapsedTicks}");
            watch.Reset();
            watch.Start();
            Int64 f2 = Factorial2(10000);
            Console.WriteLine($"递归耗时:{watch.ElapsedTicks}");
            Console.WriteLine("------- 局部函数 结束 -------");
        }

        /// <summary>
        /// 阶乘
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Int64 Factorial(int number)
        {
            if (number < 0)
                throw new ArgumentException($"negative number:{nameof(number)}");
            else if (number == 0)
                return 1;
            Int64 result = number;
            while (number > 1)
            {
                Muitiply(number - 1);
                number--;
            }
            void Muitiply(int x) => result *= x;
            return result;
        }
        /// <summary>
        /// 阶乘2
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static Int64 Factorial2(int number)
        {
            if (number < 0)
                throw new ArgumentException("nagative number", nameof(number));
            return number == 0 ? 1 : number * Factorial2(number - 1);
        }
    }
}
