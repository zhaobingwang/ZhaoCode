using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CustomConventions:Convention
    {
        public CustomConventions()
        {
            Properties<string>().Configure(config => config.IsUnicode(false));
        }
    }
}
