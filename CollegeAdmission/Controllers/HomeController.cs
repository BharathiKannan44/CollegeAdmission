using CollegeAdmission.Filters;
using System.Web.Mvc;

namespace CollegeAdmission.Controllers
{
    [ExceptionFilter]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}