using System.Web;
using System.Web.Mvc;

namespace CSharp.Unclassified.SSODemo_Client1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
