using Newtonsoft.Json;
using Project.WebAPI.Common;
using Project.WebAPI.Enums;
using Project.WebAPI.Models;
using Project.WebAPI.Models.Verify;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Project.WebAPI.Filters
{
    public class ApiSecurityFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            ResultMsg resultMsg = null;
            var request = actionContext.Request;
            string method = request.Method.Method;
            string userid = string.Empty, timestamp = string.Empty, nonce = string.Empty, signature = string.Empty;
            int id = 0;

            if (request.Headers.Contains("userid"))
            {
                userid = HttpUtility.UrlDecode(request.Headers.GetValues("userId").FirstOrDefault());
            }
            if (request.Headers.Contains("timestamp"))
            {
                timestamp = HttpUtility.UrlDecode(request.Headers.GetValues("timestamp").FirstOrDefault());
            }
            if (request.Headers.Contains("nonce"))
            {
                nonce = HttpUtility.UrlDecode(request.Headers.GetValues("nonce").FirstOrDefault());
            }
            if (request.Headers.Contains("signature"))
            {
                signature = HttpUtility.UrlDecode(request.Headers.GetValues("signature").FirstOrDefault());
            }

            // The GetToken method does not require signature verification.
            if (actionContext.ActionDescriptor.ActionName == "GetToken")
            {
                if (string.IsNullOrEmpty(userid) || (!int.TryParse(userid, out id) || string.IsNullOrEmpty(timestamp) || string.IsNullOrEmpty(nonce)))
                {
                    resultMsg = new ResultMsg();
                    resultMsg.StatusCode = (int)StatusCodeEnum.ParameterError;
                    resultMsg.Info = "请求参数不完整或不正确";
                    resultMsg.Data = "";
                    actionContext.Response = HttpResponseHelper.toJson(JsonConvert.SerializeObject(resultMsg));
                    base.OnActionExecuting(actionContext);
                    return;
                }
                else
                {
                    base.OnActionExecuting(actionContext);
                    return;
                }
            }

            // Determine if the request header contains the following parameters.
            if (string.IsNullOrEmpty(userid) || (!int.TryParse(userid, out id) || string.IsNullOrEmpty(timestamp) || string.IsNullOrEmpty(nonce) || string.IsNullOrEmpty(signature)))
            {
                resultMsg = new ResultMsg();
                resultMsg.StatusCode = (int)StatusCodeEnum.ParameterError;
                resultMsg.Info = "请求参数不完整或不正确";
                resultMsg.Data = "";
                actionContext.Response = HttpResponseHelper.toJson(JsonConvert.SerializeObject(resultMsg));
                base.OnActionExecuting(actionContext);
                return;
            }

            // Determine if the timespan is valid.
            double ts1 = 0;
            double ts2 = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds;
            bool timespanValidate = double.TryParse(timestamp, out ts1);
            double ts = ts2 - ts1;
            bool flag = ts > 60 * 60 * 1000;    // 1h.
            if (flag || (!timespanValidate))
            {
                resultMsg = new ResultMsg();
                resultMsg.StatusCode = (int)StatusCodeEnum.URLExpireError;
                resultMsg.Info = "该URL已经失效";
                resultMsg.Data = "";
                actionContext.Response = HttpResponseHelper.toJson(JsonConvert.SerializeObject(resultMsg));
                base.OnActionExecuting(actionContext);
                return;
            }

            // Datermine if the token is valid.
            Token token = (Token)HttpRuntime.Cache.Get(id.ToString());
            string signToken = string.Empty;
            if (HttpRuntime.Cache.Get(id.ToString()) == null)
            {
                resultMsg = new ResultMsg();
                resultMsg.StatusCode = (int)StatusCodeEnum.TokenInvalid;
                resultMsg.Info = "请求TOKEN失效";
                resultMsg.Data = "";
                actionContext.Response = HttpResponseHelper.toJson(JsonConvert.SerializeObject(resultMsg));
                base.OnActionExecuting(actionContext);
                return;
            }
            else
            {
                signToken = token.SignToken.ToString();
            }

            // Splicing parameters according to request type.
            NameValueCollection form = HttpContext.Current.Request.QueryString;
            string data = string.Empty;
            switch (method)
            {
                case "POST":
                    Stream stream = HttpContext.Current.Request.InputStream;
                    string responseJson = string.Empty;
                    StreamReader streamReader = new StreamReader(stream);
                    data = streamReader.ReadToEnd();
                    break;
                case "GET":
                    // 1.Take out all get parameters
                    IDictionary<string, string> parameters = new Dictionary<string, string>();
                    for (int i = 0; i < form.Count; i++)
                    {
                        string key = form.Keys[i];
                        parameters.Add(key, form[key]);
                    }

                    // 2.Sort the dictionary alphabetically by key
                    IDictionary<string, string> sortedParams = new SortedDictionary<string
                        , string>(parameters);
                    IEnumerator<KeyValuePair<string, string>> dem = sortedParams.GetEnumerator();

                    // 3.String all parameter names and parameter values together
                    StringBuilder query = new StringBuilder();
                    while (dem.MoveNext())
                    {
                        string key = dem.Current.Key;
                        string value = dem.Current.Value;
                        if (!string.IsNullOrEmpty(key))
                        {
                            query.Append(key).Append(value);
                        }
                    }
                    data = query.ToString();
                    break;
                default:
                    resultMsg = new ResultMsg();
                    resultMsg.StatusCode = (int)StatusCodeEnum.HttpMehtodError;
                    resultMsg.Info = "HTTP请求类型不合法";
                    resultMsg.Data = "";
                    actionContext.Response = HttpResponseHelper.toJson(JsonConvert.SerializeObject(resultMsg));
                    base.OnActionExecuting(actionContext);
                    return;
            }

            bool result = SignHelper.Validate(timestamp, nonce, id, signToken, data, signature);
            if (!result)
            {
                resultMsg = new ResultMsg();
                resultMsg.StatusCode = (int)StatusCodeEnum.HttpRequestError;
                resultMsg.Info = "HTTP请求不合法";
                resultMsg.Data = "";
                actionContext.Response = HttpResponseHelper.toJson(JsonConvert.SerializeObject(resultMsg));
                base.OnActionExecuting(actionContext);
                return;
            }
        }
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}