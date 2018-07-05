using Newtonsoft.Json;
using Project.WebAPI.Common;
using Project.WebAPI.Enums;
using Project.WebAPI.Models;
using Project.WebAPI.Models.Verify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Project.WebAPI.Controllers
{
    public class VerifyController : ApiController
    {
        public async Task<IHttpActionResult> GetToken22222(string userId)
        {
            int id = 0;

            // verify incoming parameters.
            if (string.IsNullOrEmpty(userId) || (!int.TryParse(userId, out id)))
            {
                return NotFound();
            }

            // insert cache
            Token token = (Token)HttpRuntime.Cache.Get(id.ToString());
            if (HttpRuntime.Cache.Get(id.ToString()) == null)
            {
                token = new Token();
                token.Id = id;
                token.SignToken = Guid.NewGuid();
                token.ExpireTime = DateTime.Now.AddDays(1);
                HttpRuntime.Cache.Insert(token.Id.ToString(), token, null, token.ExpireTime, TimeSpan.Zero);
            }

            // return token
            return Ok(token);
        }

        public HttpResponseMessage GetToken(string userId)
        {
            ResultMsg resultMsg = null;
            int id = 0;
            // verify incoming parameters.
            if (string.IsNullOrEmpty(userId) || (!int.TryParse(userId, out id)))
            {
                resultMsg = new ResultMsg();
                resultMsg.StatusCode = (int)StatusCodeEnum.ParameterError;
                resultMsg.Info = "参数错误";
                resultMsg.Data = "";
                return HttpResponseHelper.toJson(JsonConvert.SerializeObject(resultMsg));
            }

            // insert cache
            Token token = (Token)HttpRuntime.Cache.Get(id.ToString());
            if (HttpRuntime.Cache.Get(id.ToString()) == null)
            {
                token = new Token();
                token.Id = id;
                token.SignToken = Guid.NewGuid();
                token.ExpireTime = DateTime.Now.AddDays(1);
                HttpRuntime.Cache.Insert(token.Id.ToString(), token, null, token.ExpireTime, TimeSpan.Zero);
            }

            // return token
            resultMsg = new ResultMsg();
            resultMsg.StatusCode = (int)StatusCodeEnum.Success;
            resultMsg.Info = "";
            resultMsg.Data = token;

            return HttpResponseHelper.toJson(JsonConvert.SerializeObject(resultMsg));
        }
    }
}
