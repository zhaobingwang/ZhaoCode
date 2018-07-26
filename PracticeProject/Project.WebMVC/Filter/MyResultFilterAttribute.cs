using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WebMVC.Filter
{
    public class MyResultFilterAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write($"加载视图前执行：{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}");
            base.OnResultExecuting(filterContext);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write($"加载视图后执行：{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}");
            base.OnResultExecuted(filterContext);
        }
    }
}