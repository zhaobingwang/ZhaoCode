using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WebMVC.Controllers
{
    public class CacheExampleController : Controller
    {
        // GET: CacheExample
        [OutputCache(Duration = 10, VaryByParam = "none")]
        public ActionResult Index()
        {
            ViewBag.Test = "测试内容";
            ViewBag.Now = DateTime.Now.ToString();
            return View();
        }

        [OutputCache(Duration = 10, VaryByParam = "name")]
        public ActionResult GetName(string name)
        {
            ViewBag.Name = name;
            ViewBag.Now = DateTime.Now.ToString();
            return View();
        }
    }
}