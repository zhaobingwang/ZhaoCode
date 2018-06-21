using Project.Framework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Project.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        public async Task<User> GetUser(int id)
        {
            List<User> list = new List<User>();
            using (var db = new MySqlContext())
            {
                var result = await db.Users.FindAsync(id);
                return result;
            }
        }
    }
}
