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
        private static bool _isDone = false;
        private static object _lock = new object();
        static SemaphoreSlim _sem = new SemaphoreSlim(3);  //限制能同时访问的线程数量是3
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
            //Thread thread = new Thread(() => { Console.WriteLine("a"); });
            //thread.IsBackground = true; //设置为后台线程
            //thread.Start(); 
            #endregion

            #region async & await 的前世今生（Updated）
            // 创建
            //new Thread(Go).Start();  // .NET 1.0开始就有的
            //Task.Factory.StartNew(Go);  // .NET 4.0 引入了 TPL
            //Task.Run(new Action(Go));  // .NET 4.5 新增了一个Run的方法

            //线程池
            //Console.WriteLine($"我是主线程：ThreadId:{Thread.CurrentThread.ManagedThreadId}");
            //ThreadPool.QueueUserWorkItem(Go);

            //传入参数
            //new Thread(Go).Start("arg1");  // 没有匿名委托之前，我们只能这样传入一个object的参数
            //new Thread(delegate ()  //有了匿名委托之后...
            //{
            //    GoGoGo("arg1", "arg2", "arg3");
            //});
            //new Thread(() => //当然,还有 Lambada
            //{
            //    GoGoGo("arg1", "arg2", "arg3");
            //});
            //Task.Run(() =>  //Task能这么灵活，也是因为有了Lambda呀。
            //{    
            //    GoGoGo("arg1", "arg2", "arg3");
            //});

            //返回值
            //var dayName = Task.Run(() => { return GetDate(); });
            //Console.WriteLine($"今天是{dayName.Result}");

            //共享数据
            //new Thread(Done).Start();
            //new Thread(Done).Start();

            //线程安全
            //new Thread(Done2).Start();
            //Thread.Sleep(1000);
            //new Thread(Done2).Start();

            //锁
            //new Thread(Done3).Start();
            //new Thread(Done3).Start();

            //Semaphore 信号量
            //for (int i = 0; i < 5; i++)
            //{
            //    new Thread(Enter).Start(i);
            //    //Console.ReadLine();
            //}

            //异常处理
            //try
            //{
            //    new Thread(GoException).Start();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Exception");
            //}

            //try
            //{
            //    var task = Task.Run(() => { GoException(); });
            //    task.Wait();    // 在调用了这句话之后，主线程才能捕获task里面的异常

            //    // 对于有返回值的Task, 我们接收了它的返回值就不需要再调用Wait方法了
            //    // GetName 里面的异常我们也可以捕获到
            //    var task2 = Task.Run(() => { return GetName(); });
            //    var name = task2.Result;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Exception");
            //}


            //一个小例子认识async & await
            //Test(); //这个方法其实是多余的, 本来可以直接写下面的方法,但是由于控制台的入口方法不支持async,所有我们在入口方法里面不能 用 await
            //Console.WriteLine($"当先主线程Id: {Thread.CurrentThread.ManagedThreadId}");

            //Console.WriteLine($"当先主线程Id: {Thread.CurrentThread.ManagedThreadId}");
            //Test2();

            Test3();
            #endregion

            Console.Read();
        }

        /// <summary>
        /// 只有async方法在调用前才能加await么？
        /// </summary>
        private static async void Test3()
        {
            Task<string> task = Task.Run(() =>
            {
                Thread.Sleep(5000);
                return "Hello,world!";
            });
            string str = await task;    //5s后才会执行到这里
            Console.WriteLine(str);
        }

        private static async Task Test2()
        {
            Console.WriteLine($"Before calling GetTime,Thread Id :{Thread.CurrentThread.ManagedThreadId}");
            var time = GetTime2();   //我们这里没有用 await,所以下面的代码可以继续执行
            // 但是如果上面是 await GetName()，下面的代码就不会立即执行，输出结果就不一样了
            Console.WriteLine($"End calling GetTime");
            Console.WriteLine($"Get result from GetName:{await time}");
        }
        private static async Task<string> GetTime2()
        {
            //这里还是主线程
            Console.WriteLine($"Before calling Task.Run(),Thread Id :{Thread.CurrentThread.ManagedThreadId}");
            return await Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine($"GetTime Thread Id: {Thread.CurrentThread.ManagedThreadId}");
                return DateTime.Now.ToLongTimeString();
            });
        }


        private static async Task Test()
        {
            //方法上打上async关键字，就可以用await调用同样打上async关键字的方法
            Console.WriteLine($"Before calling GetTime,Thread Id :{Thread.CurrentThread.ManagedThreadId}");
            await GetTime();
        }

        private static async Task GetTime()
        {
            //Delay方法来自于.net 4.5
            await Task.Delay(1000); //返回值前面加上async之后，方法里就可以调用await了
            Console.WriteLine($"Current time:{DateTime.Now.ToLongTimeString()}");
            Console.WriteLine($"Current Thread Id: {Thread.CurrentThread.ManagedThreadId}");
        }

        static void GoException()
        {
            throw null;
        }
        static string GetName() { throw null; }

        private static void Enter(object id)
        {
            Console.WriteLine($"{id}开始排队...");
            _sem.Wait();
            Console.WriteLine($"{id}开始执行");
            Thread.Sleep(1000 * (int)id);
            Console.WriteLine($"{id}执行完毕，离开");
            _sem.Release();
        }

        private static void Done3()
        {
            lock (_lock)
            {
                if (!_isDone)
                {
                    Console.WriteLine("Done");
                    _isDone = true;
                }
            }
        }
        static void Done2()
        {
            if (!_isDone)
            {
                Console.WriteLine("Done");
                _isDone = true; //第二个线程来的时候，就不会再执行了(也不是绝对的，取决于计算机的CPU数量以及当时的运行情况)
            }
        }
        static void Done()
        {
            if (!_isDone)
            {
                _isDone = true; //第二个线程来的时候，就不会再执行了(也不是绝对的，取决于计算机的CPU数量以及当时的运行情况)
                Console.WriteLine("Done");
            }
        }

        //public static void Go() {
        //    Console.WriteLine("另一个线程");
        //}
        public static void Go(object data)
        {
            Console.WriteLine($"我是另一个线程：Thread Id: {Thread.CurrentThread.ManagedThreadId}");
        }
        public static void GoGoGo(string arg1, string arg2, string arg3)
        {
            // TODO
        }
        public static string GetDate()
        {
            return DateTime.Now.ToShortDateString();
        }
    }
}
