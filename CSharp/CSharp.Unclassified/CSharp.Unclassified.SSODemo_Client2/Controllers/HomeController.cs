using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CSharp.Unclassified.SSODemo_Client2.Controllers
{
    public class HomeController : Controller
    {
        public static List<string> Tokens = new List<string>();
        public async Task<ActionResult> Index()
        {
            var tokenId = Request["tokenId"];
            //如果tokenId不为空，则是由Service302过来的。
            if (tokenId != null)
            {
                using (HttpClient http = new HttpClient())
                {
                    //验证Tokend是否有效
                    var isValid = await http.GetStringAsync($"http://localhost:8301/Home/TokenIdIsValid?tokenId={tokenId}");
                    if (bool.Parse(isValid.ToString()))
                    {
                        if (!Tokens.Contains(tokenId))
                        {
                            //记录登陆过的client (主要是为了可以统一登出)
                            Tokens.Add(tokenId);
                        }
                        Session["token"] = tokenId;
                    }
                }
            }
            //判断是否是登录状态
            if (Session["token"] == null || !Tokens.Contains(Session["token"].ToString()))
            {
                return Redirect("http://localhost:8301/Home/Verification?backUrl=http://localhost:8303/Home");
            }
            else
            {
                if (Session["token"] != null)
                {
                    Session["token"] = null;
                }
            }
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
    }
}