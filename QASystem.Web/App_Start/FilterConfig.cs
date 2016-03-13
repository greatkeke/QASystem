using QASystem.Web.Filter;
using System.Web.Mvc;

namespace QASystem.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LoginValidateAttribute());
        }
    }
}
