using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WebMVC.Filter
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.Write("OnAuthorization <br />");
            //base.OnAuthorization(filterContext);
        }
    }
}