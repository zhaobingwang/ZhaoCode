using Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class Initializer:MigrateDatabaseToLatestVersion<Context,Configuration>
    {
        public override void InitializeDatabase(Context context)
        {
            context.Database.Log = System.Console.Write;
            base.InitializeDatabase(context);
        }
    }
}
