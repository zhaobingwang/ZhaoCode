using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiSite.Domain;
using WepApiSite.Core;

namespace WebApiSite.Controllers
{
    public class UserController : ApiController
    {
        public IEnumerable<User> Get()
        {
            UserService userService = new UserService();
            List<User> list = userService.GetAllUsers();
            return list;
        }
    }
}
