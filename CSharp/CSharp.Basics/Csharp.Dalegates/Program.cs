using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
        delegate bool WriteMethod();
        static void Main(string[] args)
        {
            #region MyRegion
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
            #endregion

            #region Func Delegate
            Console.WriteLine("\nFunc Delegate:\n");

            OutPutTarget output = new OutPutTarget();
            // 调用自定义委托：WriteMethod
            //WriteMethod methodCall = output.SendToFile;
            // 调用Func<TResult>
            //Func<bool> methodCall = output.SendToFile;
            // 使用 Func<TResult> 委托与 C# 中的匿名方法
            //Func<bool> methodCall = delegate () { return output.SendToFile(); };
            // lambda 表达式 Func<T, TResult> 委托
            Func<bool> methodCall = () => output.SendToFile();
            if (methodCall())
            {
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine("File write operation failed");
            }

            Console.WriteLine("\nFunc Delegate示例:\n");
            LazyValue<int> lazyOne = new LazyValue<int>(() => ExpensiveOne());
            LazyValue<long> lazyTwo = new LazyValue<long>(() => ExpensiveTwo("hello"));
            Console.WriteLine("LazyValue objects has been created.");
            Console.WriteLine(lazyOne.Value);
            Console.WriteLine(lazyTwo.Value);
            #endregion

            #region Func<T1, T2, TResult> 委托
            Console.WriteLine("Func<T1, T2, TResult> 委托:");
            Func<string, int, bool> predicate = (str, index) => str.Length == index;
            string[] words = { "orange", "apple", "Article", "elephant", "star", "and" };
            IEnumerable<string> aWords = words.Where(predicate).Select(str => str);
            foreach (string word in aWords)
            {
                Console.WriteLine(word);
            }

            #endregion
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

        static int ExpensiveOne()
        {
            Console.WriteLine("\nExpensiveOne() is executing.");
            return 1;
        }
        static long ExpensiveTwo(string input)
        {
            Console.WriteLine("\nExpensiveTwo() is executing.");
            return (long)input.Length;
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

    public class OutPutTarget
    {
        public bool SendToFile()
        {
            try
            {
                string fn = Path.GetTempFileName();
                StringWriter sw = new StringWriter();
                sw.WriteLine("Hello,World!");
                sw.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    class LazyValue<T> where T : struct
    {
        private Nullable<T> val;
        private Func<T> getValue;

        // constructor
        public LazyValue(Func<T> func)
        {
            val = null;
            getValue = func;
        }
        public T Value
        {
            get
            {
                if (val == null)
                    val = getValue();
                return (T)val;
            }
        }
    }
}
