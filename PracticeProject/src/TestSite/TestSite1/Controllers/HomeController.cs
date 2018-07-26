using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestSite1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Response.Cookies["name"].Value = "张三";
            Response.Cookies["password"].Value = "123456";
            return View();
        }

        [ValidateInput(false)]
        public ActionResult Search(string key)
        {
            ViewBag.Result = key;
            Response.Write(key);
            return View();
        }
    }
}