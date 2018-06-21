using Project.Framework.Data;
using Project.WebAPI.Models;
using Project.WebAPI.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Project.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        private MySqlContext db = new MySqlContext();

        [HttpGet]
        public async Task<IHttpActionResult> GetUser(int userId)
        {
            var user = await db.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.ToResponse());
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostUser(UserRequest request)
        {
            if (ModelState.IsValid)
            {
                var User = db.Users.Add(request.ToEntity());
                await db.SaveChangesAsync();
                var uri = new Uri(
                    Url.Link("DefaultApi", new { id=User.Id}));
                return Created(uri, User);
                //return CreatedAtRoute("", new { id = User.Id }, request);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
