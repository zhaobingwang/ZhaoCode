using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewsAndStoredProcedure
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 视图
            Database.SetInitializer(new Initializer());

            //using (var db = new UsersContext())
            //{
            //    var users = db.UserViews;
            //    foreach (var user in users)
            //    {
            //        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", user.UserId, user.UserNickName, user.RegTime, user.IsDelete, user.ProvinceName);
            //    }

            //    另一种方法
            //    var sql = @"SELECT UserId,UserNickName,RegTime,IsDelete,ProvinceName FROM dbo.UserViews WHERE ProvinceName={0}";
            //    var users = db.Database.SqlQuery<UserView>(sql, "杭州");
            //    foreach (var user in users)
            //    {
            //        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", user.UserId, user.UserNickName, user.RegTime, user.IsDelete, user.ProvinceName);
            //    }
            //}
            #endregion

            #region EF调用存储过程查询数据SqlQuery
            //using (var db = new UsersContext())
            //{
            //    var sql = "SelectUsers {0}";
            //    var users = db.Database.SqlQuery<UserFromStoreProcedure>(sql, "杭州");
            //    foreach (var user in users)
            //    {
            //        Console.WriteLine("{0}\t{1}\t{2}\t{3}", user.NickName, user.RegTime, user.IsDelete, user.ProvinceName);
            //    }
            //}
            #endregion

            #region EF调用存储过程之ExecuteSqlCommand方法
            //using (var db=new UsersContext())
            //{
            //    var sql = "UpdateUser {0},{1}";
            //    Console.WriteLine("执行存储过程前数据：");
            //    PrintUsers();
            //    var rowAffectd = db.Database.ExecuteSqlCommand(sql, "杭州-", 1);
            //    Console.WriteLine("影响的行数{0}", rowAffectd);
            //    Console.WriteLine("执行存储过程后的数据：");
            //    PrintUsers();
            //}
            #endregion

            #region 异步API
            Console.WriteLine(FindUserAsync(1).Result.NickName);
            #endregion
        }
        static void PrintUsers()
        {
            using (var db = new UsersContext())
            {
                var users = db.Users.Where(u => u.Province.Id == 1);
                foreach (User user in users)
                {
                    Console.WriteLine("{0}\t{1}", user.NickName, user.IsDelete);
                }
            }
        }

        #region 异步API

        //1.异步创建对象列表
        static async Task<IEnumerable<User>> GetUsersAsync()
        {
            using (var db = new UsersContext())
            {
                return await db.Users.ToListAsync();
            }
        }

        //2.异步创建一个新对象
        static async Task InsertUserAsync(User user)
        {
            using (var db = new UsersContext())
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
            }
        }

        //3.异步定位一条记录
        static async Task<User> FindUserAsync(int userId)
        {
            using (var db = new UsersContext())
            {
                return await db.Users.FindAsync(userId);
            }
        }

        //4.异步聚合函数
        static async Task<int> GetUserCountAsync()
        {
            using (var db = new UsersContext())
            {
                return await db.Users.CountAsync();
            }
        }

        //5.异步遍历查询结果
        static async Task LoopUsersAsync()
        {
            using (var db = new UsersContext())
            {
                await db.Users.ForEachAsync(u =>
                {
                    u.IsDelete = 0;
                });
            }
        }

        #endregion
    }
}
