using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WebMVC.Filter
{
    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write($"Action执行前：{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")} <br />");
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write($"Action执行后：{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")} <br />");
            base.OnActionExecuted(filterContext);
        }
    }
}