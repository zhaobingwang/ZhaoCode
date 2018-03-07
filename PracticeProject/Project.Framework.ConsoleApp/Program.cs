using Project.Framework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Framework.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MySqlContext())
            {
                var users = db.Users;
                foreach (var item in users)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
    }
}
