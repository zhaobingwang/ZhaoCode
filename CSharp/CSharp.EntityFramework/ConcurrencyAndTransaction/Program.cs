using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

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

            ////1.用户A获取ID=1的用户
            //var user1 = GetUser(1);
            ////2.用户B也获取ID=1的用户
            //var user2 = GetUser(1);
            ////3.用户A只更新这个实体的NickName字段
            //user1.NickName = "用户A";
            //UpdateUser(user1);
            ////4.用户B只更新这个实体的简介字段
            ////user2.Bio = "这是我的简介-B";
            ////UpdateUser(user2);

            //在添加 RowVersion 字段后，以上代码修改为：
            //try
            //{
            //    user2.Bio = "这是我的简介-B";
            //    UpdateUser(user2);
            //    Console.WriteLine("应该发生并发异常！");
            //}
            //catch (DbUpdateConcurrencyException ex)
            //{
            //    Console.WriteLine("并发异常，信息：{0}",ex.Message);
            //}


            #region EF默认的事务处理
            //EF的默认行为是，无论何时执行任何涉及Create，Update或Delete的查询，都会默认创建事务。当DbContext类上的SaveChanges()方法被调用时，事务就会提交
            //int outputId = 1, inputId = 1;
            //decimal transferAmount = 10000m;
            //using (var db=new Context())
            //{
            //    //1.检索事务中涉及的账户
            //    var outputAccount = db.OutputAccount.Find(outputId);
            //    var inputAccount = db.InputAccount.Find(inputId);
            //    //2.从输出账户上扣除10000
            //    outputAccount.Balance -= transferAmount;
            //    //3.输入账户上增加10000
            //    inputAccount.Balance += transferAmount;
            //    //4.提交事务
            //    db.SaveChanges();
            //}
            #endregion

            #region 使用TransactionScope处理事务
            //int outputId = 1, inputId = 1;
            //decimal transferAmount = 10000m;
            //using (var ts=new TransactionScope(TransactionScopeOption.Required))
            //{
            //    var db1 = new Context();
            //    var db2 = new Context();
            //    //1.检索事务中涉及的账户
            //    var outputAccount = db1.OutputAccount.Find(outputId);
            //    var inputAccount = db2.InputAccount.Find(inputId);
            //    //2.从输出账户上扣除10000
            //    outputAccount.Balance -= transferAmount;
            //    //3.输入账户上增加10000
            //    inputAccount.Balance += transferAmount;
            //    db1.SaveChanges();
            //    db2.SaveChanges();
            //    ts.Complete();
            //}
            #endregion

            #region 使用EF6管理事务
            //int outputId = 1, inputId = 1;
            //decimal transferAmount = 10000m;
            //using (var db=new Context())
            //{
            //    using (var trans=db.Database.BeginTransaction())
            //    {
            //        try
            //        {
            //            var sql = "Update OutputAccounts set Balance=Balance-@amountToDebit where id=@outputId";
            //            db.Database.ExecuteSqlCommand(sql, new SqlParameter("@amountToDebit", transferAmount), new SqlParameter("@outputId", outputId));
            //            var inputAccount = db.InputAccount.Find(inputId);
            //            inputAccount.Balance += transferAmount;
            //            db.SaveChanges();
            //            trans.Commit();
            //        }
            //        catch (Exception ex)
            //        {
            //            trans.Rollback();
            //        }
            //    }
            //}
            #endregion

            #region 使用已存在的事务
            int outputId = 1, inputId = 1;
            decimal transferAmount = 10000m;
            var connectionString = ConfigurationManager.ConnectionStrings["EFDemoConn"].ConnectionString;
            using (var conn=new SqlConnection(connectionString))
            {
                conn.Open();
                using (var trans=conn.BeginTransaction())
                {
                    try
                    {
                        var result = DebitOutputAccount(conn, trans, outputId, transferAmount);
                        if (!result)
                        {
                            throw new Exception("不能正常扣款");
                        }
                        using (var db=new Context(conn,contextOwnsConnection:false))
                        {
                            db.Database.UseTransaction(trans);
                            var inputAccount = db.InputAccount.Find(inputId);
                            inputAccount.Balance += transferAmount;
                            db.SaveChanges();
                        }
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                    }
                }
            }
            #endregion
        }

        //模拟老项目类库
        static bool DebitOutputAccount(SqlConnection conn,SqlTransaction trans,int accountId,decimal ammountDebit)
        {
            int affectedRows = 0;
            var command = conn.CreateCommand();
            command.Transaction = trans;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "Update OutputAccounts set Balance=Balance-@amountToDebit where id=@accountId";
            command.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter("@amountToDebit",ammountDebit),
                new SqlParameter("@accountId",accountId)
            });
            try
            {
                affectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return affectedRows == 1;
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
