using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpringNet.MVC.Controllers
{
    public class HomeController : Controller
    {
        //Service.TestClass test = new Service.TestClass();
        Service.TestClass test { get; set; }
        public ActionResult Test()
        {
            string result = test.TestGet();
            return Content(result);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}