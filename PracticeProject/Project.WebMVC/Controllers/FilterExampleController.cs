using Project.WebMVC.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WebMVC.Controllers
{
    public class FilterExampleController : Controller
    {
        // GET: FilterExample
        [MyActionFilter]
        [MyResultFilter]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TriggerException()
        {
            int a = 0;
            int b = 10 / a;
            return View(b);
        }
    }
}