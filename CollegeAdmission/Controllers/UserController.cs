using CollegeAdmission.BL;
using CollegeAdmission.Entity;
using CollegeAdmission.Filters;
using CollegeAdmission.ViewModel;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CollegeAdmission.Controllers
{
    //
    //Summmary:
    // this class provides method to Login and registration operation for user.
    [ExceptionFilter]
    public class UserController : Controller
    {
        // GET: User
         IUserBL userBL;
        public UserController()
        {
            userBL = new UserBL();
        }
        public ActionResult Index()
        {
            return View();
        }
        
        //
        //Summary:
        // This Action used to call the registration view
        [AllowAnonymous]
        public ActionResult Registration()
        {
            return View();
        }

        //
        //Summary:
        // This Action is the post method for registration view and store the user
        // Details to Database
        [HttpPost]
        [ActionName("Registration")]
        public ActionResult Registration_Post()
        {
            UserViewModel userViewModel = new UserViewModel();
            TryUpdateModel(userViewModel);
            if (ModelState.IsValid)
            {
                User user = AutoMapper.Mapper.Map<UserViewModel, User>(userViewModel);
                user.Role = Enum.GetName(typeof(Role), 0);
                if (userBL.SignUp(user))
                {
                    TempData["Message"] = Message.Registered;
                    return RedirectToAction("Login");
                }
                ViewData["Message"] = Message.ExistMailId;            
            }
            return View();
        }

        //
        //Summary:
        // This Action used to call the Login view
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        //
        //Summary:
        // This Action is the post method for Login view, validate the User inputs and 
        // give authentication to the User.
        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = userBL.Login(loginViewModel.EmailId, loginViewModel.Password);
                if(user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.EmailId, false);
                    var authTicket = new FormsAuthenticationTicket(1, user.EmailId, DateTime.Now, DateTime.Now.AddMinutes(20), false, user.Role);
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);
                    if (user.Role == Enum.GetName(typeof(Role), 1))
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                        return RedirectToAction("Index", "Student");
                }
                TempData["Message"] = Message.Incorrect;         
            }
            return View();
        }

        //
        //Summary:
        // This Action used to logout the user and redirect to Login page.
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}