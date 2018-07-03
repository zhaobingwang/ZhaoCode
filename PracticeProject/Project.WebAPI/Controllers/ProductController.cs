using Newtonsoft.Json;
using Project.Framework.Data;
using Project.Framework.Data.Entities;
using Project.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Project.WebAPI.Controllers
{
    public class ProductController : ApiController
    {
        private MySqlContext db = new MySqlContext();

        [HttpGet]
        public async Task<IHttpActionResult> GetProduct(int id)
        {
            var product = await db.Products.FindAsync(id);
            if (product==null)
            {
                return NotFound();
            }
            //return Ok(JsonConvert.SerializeObject(product));
            return Ok(product.ToResponse());
        }
    }
}
