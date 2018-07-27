using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Project.WebAPI.Filters
{
    public class APIAuthorizeAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // 如果用户使用了froms authentication，就不必再做basic authentication了
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                return;
            }
            var authHeader = actionContext.Request.Headers.Authorization;
            if (authHeader != null)
            {
                if (authHeader.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) && !string.IsNullOrWhiteSpace(authHeader.Parameter))
                {
                    var credArray = GetCredentials(authHeader);
                    var userName = credArray[0];
                    var key = credArray[1];
                    string ip = System.Web.HttpContext.Current.Request.UserHostAddress;

                    if (IsResourceOwner(userName, actionContext))
                    {
                    }
                }
            }
            HandleUnauthorizedRequest(actionContext);
            //base.OnAuthorization(actionContext);
        }

        private string[] GetCredentials(System.Net.Http.Headers.AuthenticationHeaderValue authHeader)
        {
            // Base 64 encoded string
            var rawCred = authHeader.Parameter;
            var encoding = Encoding.GetEncoding("iso-8859-1");
            var cred = encoding.GetString(Convert.FromBase64String(rawCred));
            var credArray = cred.Split(':');
            return credArray;
        }

        private bool IsResourceOwner(string userName, System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var routeData = actionContext.Request.GetRouteData();
            var resourceUserName = routeData.Values["userName"] as string;

            if (resourceUserName == userName)
            {
                return true;
            }
            return false;
        }

        private void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
            actionContext.Response.Headers.Add("WWW-Authenticate", "Basic Scheme='eLearning' location='http://localhost/Project.WebAPI/api/'");
        }
    }
}