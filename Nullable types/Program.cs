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
            Console.WriteLine(s??"Unspecified");    // Unspecified
            Console.Read();
        }
    }
}
