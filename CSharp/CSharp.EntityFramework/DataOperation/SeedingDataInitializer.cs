using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOperation
{
    public class SeedingDataInitializer : DropCreateDatabaseAlways<SeedingDataContext>
    {
        protected override void Seed(SeedingDataContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                var employer = new Employer { EmployerName = "员工" + (i + 1) };
                context.Employers.Add(employer);
            }
            base.Seed(context);
        }
    }
}
