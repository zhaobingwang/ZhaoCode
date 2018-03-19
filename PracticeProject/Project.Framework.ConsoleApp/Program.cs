using Project.Framework.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Framework.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("开始...");
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //for (int i = 0; i < 2; i++)
            //{
            //    Task t1 = ProduceData(10, 10, i.ToString() + "-A");
            //    Task t2 = ProduceData(10, 10, i.ToString() + "-B");
            //    Task t3 = ProduceData(10, 10, i.ToString() + "-C");
            //    Task t4 = ProduceData(10, 10, i.ToString() + "-D");
            //    Task t5 = ProduceData(10, 10, i.ToString() + "-E");
            //}
            //sw.Stop();
            //Console.WriteLine($"结束,耗时：{sw.Elapsed}");

        }

        //static async Task ProduceData(int count1, int count2, string taskId)
        //{
        //    Stopwatch sw = new Stopwatch();
        //    sw.Start();
        //    using (var db = new MySqlContext())
        //    {
        //        List<User> userList = new List<User>();
        //        for (int i = 0; i < count1; i++)
        //        {
        //            for (int j = 0; j < count2; j++)
        //            {
        //                var user = new User();
        //                user.Name = ChineseName.RandomName();
        //                System.Threading.Thread.Sleep(10);
        //                userList.Add(user);
        //            }
        //        }
        //        db.Users.AddRange(userList);
        //        await db.SaveChangesAsync();
        //        Console.WriteLine($"当前已有{db.Users.Count()}条记录");
        //    }
        //    sw.Stop();
        //    Console.WriteLine($"#{taskId} 耗时：{sw.Elapsed}");
        //}
    }
}
