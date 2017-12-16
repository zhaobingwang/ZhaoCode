using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CSharp.Unclassified.SSODemo_Service.Controllers
{
    public class HomeController : Controller
    {
        public static Dictionary<string, Guid> TokenIds = new Dictionary<string, Guid>();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// 验证是否登录
        /// </summary>
        /// <param name="backUrl"></param>
        /// <returns></returns>
        public ActionResult Verification(string backUrl)
        {
            if (Session["user"]==null)
            {
                return Redirect($"Login?backUrl=" + backUrl);
            }
            Session["user"] = "已经登录";
            return Redirect($"{backUrl}?tokenId=" + TokenIds[Session.SessionID]);
        }

        /// <summary>
        /// 验证tokenid是否有效
        /// </summary>
        /// <param name="tokenId"></param>
        /// <returns></returns>
        public bool TokenIdIsValid(Guid tokenId)
        {
            return TokenIds.Any(t => t.Value == tokenId);
        }

        /// <summary>
        /// 返回登录页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="backUrl"></param>
        /// <returns></returns>
        [HttpPost]
        public string Login(string name, string password, string backUrl)
        {
            if (true) //TODO：验证用户名密码登录
            {
                //用Session标识会话是登录状态
                Session["user"] = "XXX已登录";
                //在认证中心 保存客户端Client的登录认证码
                TokenIds.Add(Session.SessionID, Guid.NewGuid());
            }
            else //验证失败重新登录
            {
                return "/Home/Login";
            }
            return backUrl + "?tokenId=" + TokenIds[Session.SessionID]; //生成一个tokenId 发放到客户端
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Logout()
        {
            using (HttpClient http=new HttpClient())
            {
                await http.GetAsync($"http://localhost:8302/Home/ClearToken?tokenId={TokenIds[Session.SessionID]}");   //client1
                await http.GetAsync($"http://localhost:8303/Home/ClearToken?tokenId={TokenIds[Session.SessionID]}");   //client2
            }
            TokenIds.Remove(Session.SessionID);
            Session["user"] = null;
            return Redirect("Login");
        }
    }
}