using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new Initializer());
            using (var context = new Context())
            {
                #region TPT继承
                var employee = new Employee
                {
                    Name = "司马懿",
                    Email = "simayi@sanguo.com",
                    PhoneNumber = "18890907878",
                    Salary = 100000m
                };
                var vendor = new Vendor
                {
                    Name = "诸葛亮",
                    Email = "zhugeliang@sanguo.com",
                    PhoneNumber = "17786986756",
                    HourlyRate = 1000m
                };
                context.Person.Add(employee);
                context.Person.Add(vendor);
                context.SaveChanges();
                #endregion
            }
        }
    }
}
