using CollegeAdmission.Filters;
using System.Web.Mvc;

namespace CollegeAdmission.Controllers
{
    //
    //Summary:
    // The class provides method for admin operations
    [ExceptionFilter]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}