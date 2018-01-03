using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace OptionBindSample.Controllers
{
    public class HomeController : Controller
    {
        //public readonly Class _myClass;

        //public HomeController(IOptions<Class> classAccesser)
        //{
        //    _myClass = classAccesser.Value;
        //}
        public IActionResult Index()
        {
            //return View(_myClass);
            return View();
        }
    }
}