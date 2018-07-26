using System;

namespace Ioc.WithOutDI
{
    class WithOutDI
    {
        static void Main(string[] args)
        {
            // without DI
            Order order = new Order();
            order.Add();
            Console.ReadLine();

        }
    }


    #region 数据库读写
    /// <summary>
    /// sql server 数据库读写
    /// </summary>
    public class SqlServerDal
    {
        public void Add()
        {
            Console.WriteLine("在SqlServer数据库中添加一条订单");
        }
    }
    public class MySqlDal
    {
        public void Add()
        {
            Console.WriteLine("在MySql数据库中添加一条订单");
        }
    }
    #endregion

    #region 订单逻辑
    //public class Order
    //{
    //    private readonly SqlServerDal dal = new SqlServerDal();
    //    public void Add()
    //    {
    //        dal.Add();
    //    }
    //}

    // SqlServerDal换成MySqlDal
    public class Order
    {
        private readonly MySqlDal dal = new MySqlDal();
        public void Add()
        {
            dal.Add();
        }
    }
    #endregion
}
