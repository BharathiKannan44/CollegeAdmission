using CollegeAdmission.Filters;
using System.Web.Mvc;

namespace CollegeAdmission.Controllers
{
    //
    //Summary:
    // The class provides method for Student operations
    [ExceptionFilter]
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
    }
}