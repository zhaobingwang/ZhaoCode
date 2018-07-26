using System.Web;
using System.Web.Mvc;
using Project.WebMVC.Filter;

namespace Project.WebMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());


            filters.Add(new MyAuthorizeAttribute());
            filters.Add(new MyExceptionAttribute());

        }
    }
}
