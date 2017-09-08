using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Util.Open.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //DateTime now = DateTime.Now;
            //DateTime birthday = new DateTime(1999, 8, 8, 12, 12, 12);
            //int age=Unclassified.GetAge(birthday, now);
            //Console.WriteLine(age);
            //Console.ReadKey();

            #region 汉字处理
            Console.WriteLine("************随机姓名**********");
            //Encoding gb = Encoding.GetEncoding("gb2312");
            //byte[] bytes = gb.GetBytes("中");
            //string lowCode = Convert.ToString(bytes[0], 16);    //取出元素1编码内容（两位16进制）
            //string hightCode = Convert.ToString(bytes[1], 16);    //取出元素2编码内容（两位16进制）
            //Console.WriteLine($"{lowCode}\t{hightCode}");

            for (int j = 0; j < 20; j++)
            {
                //姓
                string surname = ChineseName.GetSurname();
                //获取GB2312编码页（表）
                Encoding gb = Encoding.GetEncoding("gb2312");
                //调用函数产生4个随机中文汉字编码
                object[] bytes = ChineseName.CreateRegionCode(2, true);
                //根据汉字编码的字节数组解码出中文汉字
                string name = string.Empty;
                for (int i = 0; i < bytes.Length; i++)
                {
                    name += gb.GetString((byte[])Convert.ChangeType(bytes[i], typeof(byte[])));
                }
                Console.WriteLine($"{surname} {name}");
                Thread.Sleep(100);
            }

            #endregion
        }
    }
}
