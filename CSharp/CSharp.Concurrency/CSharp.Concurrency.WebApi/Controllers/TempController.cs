using CSharp.Concurrency.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CSharp.Concurrency.WebApi.Controllers
{
    public class TempController : ApiController
    {
        public async Task<string> Get()
        {
            //var result=await TempClass.DownloadStringWithTimeout("http://tech.163.com/17/1127/20/D49A2NRE00097U7T.html");
            var result = await TempClass.DownloadStringWithRetries("http://tech.163.com/17/1127/20/D49A2NRE00097U7T.html");
            return result;
        }
    }
}
