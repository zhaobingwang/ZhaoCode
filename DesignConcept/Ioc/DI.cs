using System;
using System.Collections.Generic;
using System.Text;

namespace Ioc.DI
{
    public class DI
    {
        static void Main(string[] args)
        {
            SqlServerDal dal = new SqlServerDal();  // 在外部创建依赖对象
            Order order = new Order(dal);   // 通过构造函数注入依赖
            order.Add();
            Console.Read();
        }
    }

    public interface IDataAccess
    {
        void Add();
    }
    public class SqlServerDal : IDataAccess
    {
        public void Add()
        {
            Console.WriteLine("在SqlServer数据库中添加一条订单");
        }
    }
    public class MySqlDal : IDataAccess
    {
        public void Add()
        {
            Console.WriteLine("在MySql数据库中添加一条订单");
        }
    }

    public class Order
    {
        private IDataAccess _ida;   // 定义一个私有变量保存抽象
        public Order(IDataAccess ida)
        {
            _ida = ida; // 依赖注入
        }
        public void Add()
        {
            _ida.Add();
        }
    }
}
