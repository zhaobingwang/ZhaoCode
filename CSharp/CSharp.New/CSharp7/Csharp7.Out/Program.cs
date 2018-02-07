using System;

namespace Csharp7.Out
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========Csharp7之前out的用法========");
            Console.WriteLine("请输入一个数字：");
            string input = Console.ReadLine();
            int numericResult;
            if (int.TryParse(input, out numericResult))
            {
                Console.WriteLine(numericResult);
            }
            else
            {
                Console.WriteLine("Could not parse input");
            }

            Console.WriteLine("========Csharp7中out的用法========");
            Console.WriteLine("请输入一个数字：");
            input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Could not parse input");
            }

            Console.WriteLine($"convert:{TypeHandler.ParseInt32(input)}");
        }
    }

    public class TypeHandler
    {
        public static int? ParseInt32(string s)
        {
            if (!int.TryParse(s, out int result))
            {
                return null;
            }
            return result;
        }
    }
    public class Extension
    {

    }
}
