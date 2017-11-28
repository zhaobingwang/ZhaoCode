using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Basics.Multithreading
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 进程
            //Process[] process = Process.GetProcesses(); //获取当前运行的所有进程
            //Process.Start("notepad");   //通过进程打开应用程序：记事本
            //Process.Start("calc");   //通过进程打开应用程序：计算器
            //Process.Start("chrome", "www.baidu.com");   //通过chrome访问百度

            ////通过一个进程打开指定文件
            //ProcessStartInfo processStartInfo = new ProcessStartInfo(@"D:\新建文本文档.txt");
            ////1.创建进程对象
            //Process p = new Process();
            //p.StartInfo = processStartInfo;
            //p.Start(); 
            #endregion



            #region 线程
            Thread thread = new Thread(() => { Console.WriteLine("a"); });
            thread.IsBackground = true; //设置为后台线程
            thread.Start(); 
            #endregion

            Console.Read();
        }
    }
}
