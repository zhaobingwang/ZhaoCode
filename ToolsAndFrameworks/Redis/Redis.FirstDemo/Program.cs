using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis.FirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var redis = new RedisHelper(0);
            //redis.StringSet<User>("user", new User { Id = "1", Name = "zhangsan" });
            //var data = redis.StringGet<User>("user");
            //Console.WriteLine($"{data.Id}  {data.Name} ");
            redis.StringSet("test:user1", "张三");
            var data = redis.StringGet("test:user1");
            Console.WriteLine(data);
            Console.Read();
        }
    }

    [Serializable]
    class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
