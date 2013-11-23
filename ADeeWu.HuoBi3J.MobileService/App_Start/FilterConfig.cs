using System.Web;
using System.Web.Mvc;

namespace ADeeWu.HuoBi3J.MobileService
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}