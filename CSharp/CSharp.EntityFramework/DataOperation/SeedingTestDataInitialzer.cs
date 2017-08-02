using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOperation
{
    public class SeedingTestDataInitialzer: DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            #region companies data
            var company = new Company
            {
                Id = 1,
                Name = "网易"
            };
            var company2 = new Company
            {
                Id = 2,
                Name = "阿里"
            };
            context.Companies.Add(company);
            context.Companies.Add(company2);
            #endregion

            #region location data
            var location = new Location
            {
                Name = "杭州",
            };
            var location2 = new Location
            {
                Name = "上海"
            };
            context.Locations.Add(location);
            context.Locations.Add(location2);
            #endregion

            for (int i = 0; i < 10; i++)
            {
                var employer = new Employer { EmployerName = "员工" + (i + 1) };
                context.Employers.Add(employer);
            }

            var employer2 = new Employer
            {
                EmployerName = "张三",
            };
            employer2.Companies.Add(company);
            employer2.Location = location;
            context.Employers.Add(employer2);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
