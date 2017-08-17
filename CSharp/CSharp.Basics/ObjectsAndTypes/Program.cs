using System;

namespace ObjectsAndTypes
{
    class Program
    {
        static void Main(string[] args)
        {

            //User user = new User();
            //Console.WriteLine(user.Age);  //result:18

            //命名的参数
            //int z = Sum(a: 1, b: 2);
            //Console.WriteLine(z);   //result :3

            //可选参数
            //TestMethod(10); //20
            //TestMethod(10, 30); //40

            //个数可变的参数
            AnyNumberOfArguments(1, 2, 3, 4, 5, 6);
        }

        static void AnyNumberOfArguments(params int[] data)
        {
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
        }
        static void TestMethod(int a, int b = 10)
        {
            Console.WriteLine(a + b);
        }
        static int Sum(int a,int b)
        {
            return a + b;
        }
    }

    class User
    {
        public int Age { get; set; } = 18;
    }
}
