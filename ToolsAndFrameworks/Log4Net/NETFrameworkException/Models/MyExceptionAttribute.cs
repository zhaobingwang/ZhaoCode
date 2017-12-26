using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NETFrameworkException.Models
{
    public class MyExceptionAttribute : HandleErrorAttribute
    {
        public static Queue<Exception> queueException = new Queue<Exception>();
        /// <summary>
        /// 捕获异常数据
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            Exception ex = filterContext.Exception;
            //写入队列
            queueException.Enqueue(ex);
            //跳转至错误页面
            filterContext.HttpContext.Response.Redirect("/error.html");
        }
    }
}