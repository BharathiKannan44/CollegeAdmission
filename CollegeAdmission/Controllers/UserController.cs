using CollegeAdmission.BL;
using CollegeAdmission.Entity;
using CollegeAdmission.ViewModel;
using System;
using System.Web.Mvc;

namespace CollegeAdmission.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        UserBL userBL;
        public UserController()
        {
            userBL = new UserBL();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Registration")]
        public ActionResult Registration_Post()
        {
            UserViewModel userViewModel = new UserViewModel();
            TryUpdateModel(userViewModel);
            if (userViewModel.Password != userViewModel.ConfirmPassword)
            {
                TempData["Message"] = "Both passwords are not equal";
                return View();
            }
            else if (ModelState.IsValid)
            {
                User user = new User();
                user.FirstName = userViewModel.FirstName;
                user.LastName = userViewModel.LastName;
                user.Gender = userViewModel.Gender;
                user.Dob = userViewModel.Dob;
                user.PhoneNumber = userViewModel.PhoneNumber;
                user.EmailId = userViewModel.EmailId;
                user.Password = userViewModel.Password;
                user.Role = Enum.GetName(typeof(Role), 0);
                userBL.SignUp(user);
                TempData["Message"] = "Registered Sucessfully";
                return RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = userBL.Login(loginViewModel.EmailId, loginViewModel.Password);
                if(user != null)
                {
                    return RedirectToAction("DisplayCollege", "Colleges");
                }
                TempData["Message"] = "Incorrect EmailId or password";
                return View();             
            }
            return View();
        }
    }
}