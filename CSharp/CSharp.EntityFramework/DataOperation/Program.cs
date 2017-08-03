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

            using (var db = new Context())
            {
                #region MyRegion
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
                //var employers = db.Employers.Where(e => e.Id > 0);
                //foreach (var employer in employers)
                //{
                //    Console.WriteLine(employer.EmployerName);
                //}
                //Console.WriteLine("EMPLOYER DATA END-----");

                //var companys = db.Companies;
                //foreach (var company in companys)
                //{
                //    Console.WriteLine(company.Name);
                //}
                //Console.WriteLine("COMPANY DATA END---"); 
                #endregion

                #region 使用导航属性
                //查询语法
                //var employers = from l in db.Locations
                //                where l.Name == "杭州"
                //                from e in l.Employers
                //                where e.Id>5
                //                select e;

                //方法语法
                //var employers = db.Locations.Where(l => l.Name == "杭州").SelectMany(e => e.Employers);
                //foreach (var employer in employers)
                //{
                //    Console.WriteLine("{0}\t{1}",employer.EmployerName,employer.Location.Name);
                //}
                #endregion

                #region LINQ投影
                // 1.查询语法
                //var employers = from l in db.Locations
                //                select new
                //                {
                //                    LocationName = l.Name,
                //                    EmployerList = l.Employers
                //                };

                // 2.方法语法
                //var employers = db.Locations.Select(l => new
                //{
                //    LocationName = l.Name,
                //    EmployerList = l.Employers
                //});
                //foreach (var employer in employers)
                //{
                //    foreach (var employer2 in employer.EmployerList)
                //    {
                //        Console.WriteLine("{0}\t{1}",employer.LocationName,employer2.EmployerName);
                //    }
                //}
                #endregion

                #region 分组Group
                // 1.查询语法
                //var employersWithLocation = from employer in db.Employers
                //                            group employer by employer.Location.Name
                //                          into employerGroup
                //                            select new
                //                            {
                //                                LocationName = employerGroup.Key,
                //                                Employers = employerGroup
                //                            };

                // 2.方法语法
                //var employersWithLocation = db.Employers.GroupBy(e => e.Location.Name).Select(employerGroup => new
                //{
                //    LocationName = employerGroup.Key,
                //    Employers = employerGroup
                //});
                //foreach (var ewl in employersWithLocation)
                //{
                //    Console.WriteLine("{0}:", ewl.LocationName);
                //    foreach (var employer in ewl.Employers)
                //    {
                //        Console.WriteLine("\t{0}", employer.EmployerName);
                //    }
                //}
                #endregion

                #region 排序Ordering
                // 1.1 升序 查询语法
                //var employers = from employer in db.Employers
                //                orderby employer.EmployerName ascending //默认ascending 可省略
                //                select employer;

                // 1.2 升序 方法语法
                //var employers = db.Employers.OrderBy(e => e.EmployerName);

                // 2.1 降序 查询语法
                //var employers = from employer in db.Employers
                //                orderby employer.EmployerName descending
                //                select employer;

                // 2.2 降序 方法语法
                //var employers = db.Employers.OrderByDescending(e => e.EmployerName);

                //foreach (var employer in employers)
                //{
                //    Console.WriteLine("{0}",employer.EmployerName);
                //}

                #endregion

                #region 聚合操作
                /*
                 * Count-数量
                 * Sum-求和
                 * Min-最小值
                 * Max-最大值
                 * Average-平均值
                 */

                // 方法语法

                //var count = (from e in db.Employers
                //             where e.Location.Name == "杭州"
                //             select e).Count();
                //var count2 = db.Employers.Count(e => e.Location.Name == "上海");
                //var sum = db.Employers.Where(e => e.Location.Name == "上海").Sum(e => e.Id);
                //var min = db.Employers.Min(e => e.Id);
                //var max = db.Employers.Max(e => e.Id);
                //var average = db.Employers.Average(e => e.Id);
                //Console.WriteLine("Count查询语法:{0},Count方法语法{1}", count,count2);
                //Console.WriteLine("sum:{0},min:{1},max:{2},average:{3}", sum, min, max, average);
                #endregion

                #region 分页Paging
                //var employersBefore = db.Employers;
                //var employersAfter = db.Employers.OrderBy(e => e.Id).Skip(5);   //Skip(N):该方法用于从查询结果中跳过前N条数据
                //var take = db.Employers.Take(3);    //Take()方法用于从查询结果中限制元素的数量

                //Console.WriteLine("Before:");
                //PrintEmployers(employersBefore);

                //Console.WriteLine("After:");
                //PrintEmployers(employersAfter);

                //Console.WriteLine("Take:");
                //PrintEmployers(take);

                //Console.ReadKey();

                #endregion

                #region 分页实现
                //while (true)
                //{
                //    Console.WriteLine("您要查看第几页数据：");
                //    string strPage = Console.ReadLine() ?? "1";
                //    int page = int.Parse(strPage);
                //    const int pageSize = 5;
                //    if (page > 0 && page < 4)
                //    {
                //        var employers = db.Employers.OrderBy(e => e.Id).Skip((page - 1) * pageSize).Take(pageSize);
                //        PrintEmployers(employers);
                //    }
                //    else
                //    {
                //        Console.WriteLine("No Data,Finish Query!");
                //        break;
                //    }
                //}
                #endregion
            }

        }
        static void PrintEmployers(IQueryable<Employer> employers)
        {
            Console.WriteLine("Id\tName\t");
            foreach (var employer in employers)
            {
                Console.WriteLine("{0}\t{1}", employer.Id, employer.EmployerName);
            }
        }
    }
}
