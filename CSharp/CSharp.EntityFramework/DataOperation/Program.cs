using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var db=new SeedingDataContext())
            //{
            //    var employers = db.Employers;
            //    foreach (var employer in employers)
            //    {
            //        Console.WriteLine("Id:{0}\tName:{1}",employer.Id,employer.EmployerName);
            //    }
            //}
            //Console.WriteLine("数据库创建完成，种子初始化完成");
            //Console.ReadKey();

            using (var db=new Context())
            {
                //var employers = db.Employers;
                //foreach (var employer in employers)
                //{
                //    Console.WriteLine("{0}",employer.EmployerName);
                //}
                //Console.WriteLine("List Data Finish");

                //  1.查询语法
                //var employers = from e in db.Employers
                //               where e.Id > 0
                //               select e;

                //  2.方法语法
                var employers = db.Employers.Where(e => e.Id > 0);
                foreach (var employer in employers)
                {
                    Console.WriteLine(employer.EmployerName);
                }
            }
            
        }
    }
}
