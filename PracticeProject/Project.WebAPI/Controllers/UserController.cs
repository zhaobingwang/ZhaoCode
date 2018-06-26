using Newtonsoft.Json;
using Project.Framework.Data;
using Project.WebAPI.Helper;
using Project.WebAPI.Models;
using Project.WebAPI.Models.Request;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public static RedisHelper redis = new RedisHelper(0);

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

        [HttpGet]
        public async Task<IHttpActionResult> GetUsers(int pageIndex = 1, int pageSize = 10)
        {
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            #region 访问次数
            var ip = ClientInfoHelper.GetIP();
            string key = $"count_visit_{ip}";
            var historyVisit = await redis.StringGetAsync(key, "") ?? "0";
            int visit = 0;
            if (int.TryParse(historyVisit, out visit))
            {
                visit += 1;
                await redis.StringSetAsync(key, visit.ToString());
            }
            #endregion

            List<User> users = new List<User>();

            #region 缓存Users列表
            string key_statistics = $"statistics_users";
            var usersCache = await redis.StringGetAsync(key_statistics, "");
            if (string.IsNullOrEmpty(usersCache))
            {
                users = db.Users.OrderBy(u => u.Id).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
                var jsonUsers = JsonConvert.SerializeObject(users);
                await redis.StringSetAsync(key_statistics, jsonUsers, TimeSpan.FromHours(1));
            }
            else
            {
                var result = await redis.StringGetAsync(key_statistics, "");
                users = JsonConvert.DeserializeObject<List<User>>(result);
            }
            #endregion

            if (users == null || users.Count < 1)
            {
                return NotFound();
            }
            return Ok(users.ToResponse());
            //sw.Stop();
            //return Ok(sw.ElapsedMilliseconds);
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostUser(UserRequest request)
        {
            if (ModelState.IsValid)
            {
                var User = db.Users.Add(request.ToEntity());
                await db.SaveChangesAsync();
                var uri = new Uri(
                    Url.Link("DefaultApi", new { id = User.Id }));
                return Created(uri, User);
                //return CreatedAtRoute("", new { id = User.Id }, request);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update(dynamic obj)
        {
            int id = Convert.ToInt32(obj.id);
            UserRequest beUpdateModel = JsonConvert.DeserializeObject<UserRequest>(Convert.ToString(obj.model));
            var user = await db.Users.FindAsync(id);
            if (ModelState.IsValid)
            {
                var aa = 1;
            }
            return Ok(true);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update2(UserUpdateRequest request)
        {
            if (ModelState.IsValid)
            {
                var user = await db.Users.FindAsync(request.Id);
                user.ModifyDate = DateTime.Now;
                user.Name = request.Name;
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                try
                {
                    int result= await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return NotFound();
                }
                return Ok(request);
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
