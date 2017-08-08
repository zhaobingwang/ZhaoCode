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

                #region 多表连接
                //var join = from l in db.Locations
                //            join e in db.Employers on l.Id equals e.Location.Id
                //            into employerList   // 注意，这里的employerList是属于某个地方的所有员工，不是两张表join之后的结果集
                //            select new
                //            {
                //                LocationName = l.Name,
                //                EmployerList = employerList
                //            };

                //var join = db.Locations.GroupJoin(db.Employers,
                //    l => l.Id,    //左表要连接的键
                //    e => e.Location.Id,   //右表要连接的键
                //    (l, employerGroup) => new
                //    {
                //        LocationName = l.Name,
                //        EmployerList = employerGroup
                //    }
                //    );

                //foreach (var item in join)
                //{
                //    Console.WriteLine(item.LocationName);
                //    foreach (var item2 in item.EmployerList)
                //    {
                //        Console.WriteLine(item2.EmployerName);
                //    }
                //}
                #endregion

                #region 延迟加载
                //var employer = db.Employers;    //还没有查询数据库
                //var employerList = employer.ToList();   //已经查询了数据库，但是由于延时加载的存在，还没有加载location表的数据
                //var location = employerList.ElementAt(0).Location;    //因为用户访问了location表的数据，因此这个时候才加载
                #endregion

                #region 预加载
                /*
                 *  1中的参数为lambda表达式的没有？
                 *  2，3有区别？
                 */


                //var employer1 = db.Employers.Include(e=>e.Location".ToList();
                //var employer2 = db.Employers.Include("Location").ToList();
                //var employer3 = db.Employers.ToList();
                #endregion
            }

            #region 插入数据
            //var location = new Location { Name = "北京" };
            //location.Employers.Add(new Employer { EmployerName = "王五" });
            //location.Employers.Add(new Employer { EmployerName = "Jack" });
            //var location2 = new Location { Name = "广州" };
            //location2.Employers.Add(new Employer { EmployerName = "张飞" });
            //using (var db=new Context())
            //{
            //    db.Locations.Add(location);
            //    db.Entry(location2).State = System.Data.Entity.EntityState.Added;
            //    db.SaveChanges();
            //    foreach (var l in db.Locations)
            //    {
            //        Console.WriteLine(l.Name);
            //        foreach (var e in l.Employers)
            //        {
            //            Console.WriteLine("\t{0}",e.EmployerName);
            //        }
            //    }
            //}
            #endregion

            #region 更新数据
            //using (var db=new Context())
            //{
            //    var employer = db.Employers.Find(1);
            //    employer.EmployerName = "改名字了222";
            //    //db.Entry(employer).State = System.Data.Entity.EntityState.Modified;
            //    db.SaveChanges();
            //    foreach (var item in db.Employers)
            //    {
            //        Console.WriteLine("{0}",item.EmployerName);
            //    }
            //}
            #endregion

            #region 状态追踪
            //using (var db=new Context())
            //{
            //    var location1 = db.Locations.Include("Employers");
            //    foreach (var l in location1)
            //    {
            //        Console.WriteLine("位置追踪状态：{0}",db.Entry(l).State);
            //        foreach (var employer in l.Employers)
            //        {
            //            Console.WriteLine("员工的追踪状态：{0}",db.Entry(employer).State);
            //        }
            //        Console.WriteLine("****************************");
            //    }

            //    var location2 = db.Locations.Include("Employers").AsNoTracking();   ///使用AsNoTracking()方法设置不再追踪该实体

            //    Console.WriteLine(Environment.NewLine);
            //    Console.WriteLine("使用了AsNoTracking()方法之后");
            //    foreach (var l in location2)
            //    {
            //        Console.WriteLine("位置追踪状态：{0}", db.Entry(l).State);
            //        foreach (var employer in l.Employers)
            //        {
            //            Console.WriteLine("员工的追踪状态：{0}", db.Entry(employer).State);
            //        }
            //        Console.WriteLine("****************************");
            //    }
            //}
            #endregion

            #region 删除数据
            //using (var db = new Context())
            //{
            //    PrintAllEmployers(db);
            //    var toDelete = db.Locations.Find(2);
            //    toDelete.Employers.ToList().ForEach(e => db.Employers.Remove(e));
            //    db.Locations.Remove(toDelete);
            //    db.SaveChanges();
            //    PrintAllEmployers(db);
            //}

            //方法2：通过设置实体状态删除
            //var toDeleteLocation = new Location { Id = 3 };
            //toDeleteLocation.Employers.Add(new Employer { Id = 15 });
            //toDeleteLocation.Employers.Add(new Employer { Id = 14 });
            //using (var db = new Context())
            //{
            //    PrintAllEmployers(db);  //删除前先输出现有的数据,不能写在下面的using语句中，否则Attach方法会报错
            //}
            //using (var db=new Context())
            //{
            //    db.Locations.Attach(toDeleteLocation);
            //    foreach (var employer in toDeleteLocation.Employers.ToList())
            //    {
            //        db.Entry(employer).State = System.Data.Entity.EntityState.Deleted;
            //    }
            //    db.Entry(toDeleteLocation).State = System.Data.Entity.EntityState.Deleted;  //删除完子实体，再删除父实体
            //    db.SaveChanges();
            //    Console.WriteLine("删除之后的数据如下：\r\n");
            //    PrintAllEmployers(db);
            //}
            #endregion

            #region 使用内存数据
            using (var db=new Context())
            {
                //14.1 证明Find方法先去内存中寻找数据
                //Find方法在构建数据库查询之前，会先去本地的上下文中搜索
                var location = db.Locations.ToList();
                //var query = db.Locations.Find(4);

                //14.2 ChangeTracker的使用
                //通过ChangeTracker对象，我们可以访问内存中所有实体的状态，也可以查看这些实体以及它们的DbChangeTracker
                foreach (var dbEntityEntry in db.ChangeTracker.Entries<Location>())
                {
                    Console.WriteLine(dbEntityEntry.State);
                    Console.WriteLine(dbEntityEntry.Entity.Name);
                }
            }
            #endregion
        }
        static void PrintEmployers(IQueryable<Employer> employers)
        {
            Console.WriteLine("Id\tName\t");
            foreach (var employer in employers)
            {
                Console.WriteLine("{0}\t{1}\t{2}", employer.Id, employer.EmployerName,employer.Location.Name);
            }
        }
        static void PrintAllEmployers(Context db)
        {
            var locations = db.Locations.ToList();
            foreach (var location in locations)
            {
                Console.WriteLine("{0}的员工：",location.Name);
                foreach (var employer in location.Employers)
                {
                    Console.WriteLine("{0}\t{1}\t{2}",employer.Id,employer.EmployerName,employer.Location.Name);
                }
            }
        }
    }
}
