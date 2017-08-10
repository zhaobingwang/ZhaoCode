using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyAndTransaction
{
    class Program
    {
        static void Main(string[] args)
        {
            //Database.SetInitializer(new Initializer());
            //using (var db=new Context())
            //{
            //    foreach (var user in db.Users)
            //    {
            //        Console.WriteLine(user.NickName);
            //    }
            //}

            //1.用户A获取ID=1的用户
            var user1 = GetUser(1);
            //2.用户B也获取ID=1的用户
            var user2 = GetUser(1);
            //3.用户A只更新这个实体的NickName字段
            user1.NickName = "用户A";
            UpdateUser(user1);
            //4.用户B只更新这个实体的简介字段
            //user2.Bio = "这是我的简介-B";
            //UpdateUser(user2);

            //在添加 RowVersion 字段后，以上代码修改为：
            try
            {
                user2.Bio = "这是我的简介-B";
                UpdateUser(user2);
                Console.WriteLine("应该发生并发异常！");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine("并发异常，信息：{0}",ex.Message);
            }
        }

        static User GetUser(int id)
        {
            using (var db=new Context())
            {
                return db.Users.Find(id);
            }
        }
        static void UpdateUser(User user)
        {
            using (var db=new Context())
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
