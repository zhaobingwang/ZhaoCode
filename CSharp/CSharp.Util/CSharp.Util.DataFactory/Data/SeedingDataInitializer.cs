using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Util.DataFactory.Data
{
    public class SeedingDataInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            for (int i = 0; i < 5; i++)
            {
                var province = new Province { Name = $"测试省份{i + 1}" };
                context.Province.Add(province);
            }
            base.Seed(context);
        }
    }
}
