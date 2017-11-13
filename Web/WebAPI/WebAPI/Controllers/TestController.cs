using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class TestController : ApiController
    {
        //[Route("api/GetText")]
        //[HttpGet]
        //[ActionName("GetText")]
        //public string GetText()
        //{
        //    return "Test text1";
        //}
        //[Route("api/GetText2")]
        //[HttpGet]
        //[ActionName("GetText2")]
        //public string GetText2()
        //{
        //    return "Test text2";
        //}

        public string GetText()
        {
            return "text1";
        }

        public string AA()
        {
            return "text2";
        }
    }
}
