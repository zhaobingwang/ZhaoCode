using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOperation
{
    public class SeedingDataContext : DbContext
    {
        public SeedingDataContext()
        {
            Database.SetInitializer<SeedingDataContext>(new SeedingDataInitializer());
        }
        public virtual DbSet<Employer> Employers { get; set; }
    }
}

