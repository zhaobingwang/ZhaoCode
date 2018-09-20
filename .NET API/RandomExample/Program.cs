using System;

namespace RandomExample
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Random.NextBytes
            /*
             * 1.NextBytes()方法来使用随机字节值填充的字节数组
             * 2.字节数组的每个元素设置为随机数字大于或等于 0，且小于或等于MaxValue(255)
             * 3.若要生成适用于创建随机密码的加密安全随机数字，请使用一种方法如RNGCryptoServiceProvider.GetBytes。
             */
            Random rnd = new Random();
            byte[] b = new byte[10];
            rnd.NextBytes(b);
            Console.WriteLine("The Random bytes are:");
            for (int i = 0; i <= b.GetUpperBound(0); i++)
            {
                Console.WriteLine($"{i}:{b[i]}");
            }
            #endregion
        }
    }
}
