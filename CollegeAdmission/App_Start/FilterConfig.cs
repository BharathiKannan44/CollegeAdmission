using CollegeAdmission.Filters;
using System.Web.Mvc;

namespace CollegeAdmission
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ExceptionFilter());
            //filters.Add(new HandleErrorAttribute());
        }
    }
}
