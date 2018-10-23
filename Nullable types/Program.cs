using System;

namespace Nullable_types
{
    class NullCoalesce
    {
        static int? GetNullableInt()
        {
            return null;
        }
        static string GetStringValue()
        {
            return null;
        }
        static void Main(string[] args)
        {
            // 1.??运算符（null合并运算符）
            // ??左边的操作数不为null，则此运算符将返回左边的操作数，否则返回右边的操作数
            int? x = null;
            int y = x ?? 1;
            Console.WriteLine(y);   // 1
            int i = GetNullableInt() ?? default(int);
            Console.WriteLine(i);   // 0
            string s = GetStringValue();
            Console.WriteLine(s ?? "Unspecified");    // Unspecified
            

            // 2.HasValue()
            HasValueExample();
        }

        static void HasValueExample()
        {
            Console.WriteLine("----- Start of HasValue() -----");
            Nullable<int> n1 = new Nullable<int>(10);
            Nullable<int> n2 = null;
            Nullable<int> n3 = new Nullable<int>(20);
            n3 = null;
            Nullable<int>[] items = { n1, n2, n3 };
            foreach (var item in items)
            {
                Console.WriteLine($"Has a value:{item.HasValue}");
                if (item.HasValue)
                {
                    Console.WriteLine($"Type:{item.GetType().Name}");
                    Console.WriteLine($"Value:{item.Value}");
                }
                else
                {
                    Console.WriteLine($"Null:{item==null}");
                    Console.WriteLine($"Default Value:{item.GetValueOrDefault()}");
                }
            }
            Console.WriteLine("----- End of HasValue() -----");
        }
    }
}
