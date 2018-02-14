using System;

/// <summary>
/// 委托
/// </summary>
namespace Csharp.Dalegates
{
    class Program
    {
        public delegate void Del(string message);
        public delegate void Del2(int i, double j);
        public delegate void Del3();
        delegate void CustomDel(string s);
        static void Main(string[] args)
        {
            Del handler = DelegateMethod;
            handler("Hello");

            MethodWithCallback(1, 2, handler);
            MethodWithCallback(3, 4, handler);
            MethodWithCallback(5, 6, handler);

            MethodClass obj = new MethodClass();
            Del d1_1 = obj.Metrhod1;
            Del d1_2 = obj.Metrhod2;
            Del d1_3 = DelegateMethod;

            Del allMethodsDelegate = d1_1 + d1_2;
            allMethodsDelegate += d1_3;
            int invocationCount = allMethodsDelegate.GetInvocationList().Length;//.GetLength(0);
            Console.WriteLine($"count:{invocationCount}");

            Del2 d2 = obj.MultipyNumbers;
            Console.WriteLine("Invoking the delegate using 'MultiplyNumbers':");
            for (int i = 1; i <= 5; i++)
            {
                d2(i, 2);
            }

            Console.WriteLine("委托映射到静态方法和实例方法，并返回来自两种方法的具体信息:");
            Del3 d3_1 = obj.InstancaMethod;
            d3_1();
            Del3 d3_2 = MethodClass.StaticMethod;
            d3_2();

            Console.WriteLine("multicast delegates(多播委托):");
            CustomDel hiDel, byeDel, multiDel, multiMinusHiDel;
            hiDel = Hello;
            byeDel = Goodbye;
            multiDel = hiDel + byeDel;
            multiMinusHiDel = multiDel - hiDel;
            Console.WriteLine("Invoke delegate hiDel:");
            hiDel("A");
            Console.WriteLine("Invoke delegate byDel:");
            byeDel("B");
            Console.WriteLine("Invoke delegate multiDel:");
            multiDel("C");
            Console.WriteLine("Invoke delegate multiMinusHiDel:");
            multiMinusHiDel("D");
        }

        public static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }

        public static void MethodWithCallback(int parm1, int parm2, Del callback)
        {
            callback($"The number is:{(parm1 + parm2).ToString()}");
        }

        static void Hello(string s)
        {
            Console.WriteLine($"    Hello,{s}!");
        }
        static void Goodbye(string s)
        {
            Console.WriteLine($"    Goodbye,{s}");
        }
    }

    public class MethodClass
    {
        public void Metrhod1(string message) { }
        public void Metrhod2(string message) { }

        public void MultipyNumbers(int m, double n)
        {
            Console.WriteLine($"{m * n}  ");
        }

        public void InstancaMethod()
        {
            Console.WriteLine("A message from the instance method.");
        }

        public static void StaticMethod()
        {
            Console.WriteLine("A message from the static method");
        }
    }
}
