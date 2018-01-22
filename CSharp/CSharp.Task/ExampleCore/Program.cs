using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExampleCore
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 等待一个或多个任务完成
            //Task taskA = Task.Run(() => Thread.Sleep(3000));
            //Console.WriteLine($"taskA Status:{taskA.Status}");
            //try
            //{
            //    taskA.Wait(1000);
            //    bool completed = taskA.IsCompleted;
            //    Console.WriteLine($"taskA completed:{completed},Status：{taskA.Status}");
            //    if (!completed)
            //        Console.WriteLine("Tiem out before taksA completed");
            //}
            //catch (AggregateException)
            //{
            //    Console.WriteLine("Exception in taskA");
            //} 
            #endregion

            #region 等待执行的一系列任务中的一个完成：WaitAny(Task[]) 
            //var tasks = new Task[3];
            //var rnd = new Random();
            //for (int ctr = 0; ctr <= 2; ctr++)
            //    tasks[ctr] = Task.Run(() => Thread.Sleep(rnd.Next(500, 3000)));
            //try
            //{
            //    int index = Task.WaitAny(tasks);
            //    Console.WriteLine($"Task #{tasks[index].Id} completed first.\n");
            //    Console.WriteLine("Status of all tasks:");
            //    foreach (var t in tasks)
            //        Console.WriteLine($"Task #{t.Id}:{t.Status}");
            //}
            //catch (AggregateException)
            //{
            //    Console.WriteLine("An exception occurred");
            //} 
            #endregion

            #region 等待执行的一系列任务中所有任务完成：WaitAll(Task[])
            //Task[] tasks = new Task[10];
            //for (int i = 0; i < 10; i++)
            //    tasks[i] = Task.Run(() => Thread.Sleep(3000));
            //try
            //{
            //    Task.WaitAll(tasks);    //Wait for all tasks to complete.
            //}
            //catch (AggregateException ae)
            //{
            //    Console.WriteLine("One or more exceptions occurred:");
            //    foreach (var ex in ae.Flatten().InnerExceptions)
            //        Console.WriteLine($"    {ex.Message}");
            //}
            //Console.WriteLine("Status of completed tasks:");
            //foreach (var t in tasks)
            //    Console.WriteLine($"    Task #{t.Id}:{t.Status}");
            #endregion

            #region 任务取消CancellationTokenSource
            //var source1 = new CancellationTokenSource();
            //var token1 = source1.Token;
            //source1.Cancel();
            //var source2 = new CancellationTokenSource();
            //var token2 = source2.Token;

            //Task[] tasks = new Task[12];
            //for (int i = 0; i < 12; i++)
            //{
            //    switch (i % 4)
            //    {
            //        case 0:
            //            tasks[i] = Task.Run(() => Thread.Sleep(2000));
            //            break;
            //        case 1:
            //            tasks[i] = Task.Run(() => Thread.Sleep(2000), token1);
            //            break;
            //        case 2:
            //            tasks[i] = Task.Run(() => { throw new NotSupportedException(); });
            //            break;
            //        case 3:
            //            tasks[i] = Task.Run(() =>
            //            {
            //                Thread.Sleep(2000);
            //                if (token2.IsCancellationRequested)
            //                    token2.ThrowIfCancellationRequested();
            //                Thread.Sleep(500);
            //            }, token2);
            //            break;
            //    }
            //}

            //Thread.Sleep(250);
            //source2.Cancel();
            //try
            //{
            //    Task.WaitAll(tasks);
            //}
            //catch (AggregateException ae)
            //{
            //    Console.WriteLine("One or more exceptions occurred");
            //    foreach (var ex in ae.InnerExceptions)
            //        Console.WriteLine($"    {ex.GetType().Name}:{ex.Message}");
            //}

            //Console.WriteLine("\nStatus of tasks:");
            //foreach (var t in tasks)
            //{
            //    Console.WriteLine($"    Task #{t.Id}:{t.Status}");
            //    if (t.Exception!=null)
            //    {
            //        foreach (var ex in t.Exception.InnerExceptions)
            //            Console.WriteLine($"        {ex.GetType().Name}:{ex.Message}");
            //    }
            //} 
            #endregion

            #region 示例
            Action<object> action = (object obj) =>
            {
                Console.WriteLine($"Task={Task.CurrentId},obj={obj},Thread={Thread.CurrentThread.ManagedThreadId}");
            };
            Task t1 = new Task(action, "alpha");
            Task t2 = Task.Factory.StartNew(action, "beta");
            t2.Wait();
            t1.Start();
            Console.WriteLine($"t1 has been launched.(Main Thread={Thread.CurrentThread.ManagedThreadId})");
            t1.Wait();

            string taskData = "gamma";
            Task t3 = Task.Run(() =>
            {
                Console.WriteLine($"Task={Task.CurrentId},obj={taskData},Thread={Thread.CurrentThread.ManagedThreadId}");
            });
            t3.Wait();
            Task t4 = new Task(action, "delta");
            t4.RunSynchronously();
            t4.Wait();
            #endregion
        }
    }
}
