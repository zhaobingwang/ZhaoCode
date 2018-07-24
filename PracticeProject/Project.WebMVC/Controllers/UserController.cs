using Project.Framework.Data;
using Project.Framework.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WebMVC.Controllers
{
    public class UserController : Controller
    {
        private MySqlContext db = new MySqlContext();

        // GET: User
        public ActionResult Index()
        {
            List<User> users = new List<User>();
            ViewData["One"] = "张三";
            ViewBag.Two = "李四";
            var user = new User() { Name = "王五" };
            TempData["Four"] = "赵六";

            return View(user);
        }

        /// <summary>
        /// 部分视图示例
        /// </summary>
        /// <returns></returns>
        public ActionResult PartialViewExample()
        {
            ViewData["SayHi"] = "Hello!";
            return PartialView();
        }

        public ActionResult UpdateUser()
        {
            return View();
        }
        
        [HttpPost]
        public string UpdateUser(FormCollection form)
        {
            return Request.Form["Name"];
        }

        [HttpPost]
        public string UpdateUser(string name)
        {
            return name;
        }
    }
}