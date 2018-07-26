using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WebMVC.Controllers
{
    public class WebSecurityController : Controller
    {
        // GET: WebSecurity
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult XSS(string cookie)
        {
            ViewBag.Cookie = cookie;
            return View();
        }
    }
}