using NETFrameworkException.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NETFrameworkException
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //开启一个线程，扫描异常信息队列
            string filePath = Server.MapPath("/log/");
            ThreadPool.QueueUserWorkItem((o) =>
            {
                while (true)
                {
                    if (MyExceptionAttribute.queueException.Count() > 0)    //队列中有数据
                    {
                        Exception ex = MyExceptionAttribute.queueException.Dequeue();
                        if (ex!=null)
                        {
                            //将异常信息写入日志
                            string fileName = DateTime.Now.ToString("yyyyMMdd");
                            File.AppendAllText(filePath + fileName + ".log", ex.ToString(), System.Text.Encoding.UTF8);
                        }
                    }
                    else
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(5));
                    }
                }
            }, filePath);
        }
        //异常处理过滤器

    }
}
