using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CollegeAdmission.BL;
using CollegeAdmission.Entity;
using CollegeAdmission.Filters;
using CollegeAdmission.ViewModel;
using System.Linq;

namespace CollegeAdmission.Controllers
{
    [ExceptionFilter]
    public class UserApplicationsController : Controller
    {
        ICollegeBL collegeBL;
        IDepartmentBL departmentBL;
        IUserBL userBL;
        IApplicationBL userApplicationBL;
        public UserApplicationsController()
        {
            collegeBL = new CollegeBL();
            departmentBL = new DepartmentBL();
            userBL = new UserBL();
            userApplicationBL = new ApplicationBL();
        }
        // GET: UserApplications

        public ActionResult DisplayApplications()
        {
            IEnumerable<College> colleges = collegeBL.GetColleges();
            List<SelectListItem> collegeList = new List<SelectListItem>();
            foreach (College college in colleges)
            {
                collegeList.Add(new SelectListItem { Text = @college.CollegeName, Value = @college.CollegeCode });
            }
            ViewBag.College = collegeList;
            var enumData = from Status e in Enum.GetValues(typeof(Status))
                           select new
                           {
                               ID = (int)e,
                               Name = e.ToString()
                           };
            ViewBag.StatusList = new SelectList(enumData, "ID", "Name");
            List<UserApplicationModel> applicationModels = new List<UserApplicationModel>();
            IEnumerable<UserApplication> applications;
            if (TempData["CollegeCode"] != null  && TempData["Status"] != null)
            {
                applications = userApplicationBL.GetApplicationsByCollege(TempData["CollegeCode"].ToString(),Enum.GetName(typeof(Status),Convert.ToInt32(TempData["Status"])));
                foreach (UserApplication application in applications)
                {
                    applicationModels.Add(AutoMapper.Mapper.Map<UserApplication, UserApplicationModel>(application));
                }
            }
            else if(TempData["CollegeCode"] != null)
            {
                applications = userApplicationBL.GetApplicationsByCollege(TempData["CollegeCode"].ToString(), null);

            }
            else if (TempData["Status"] != null)
            {
                applications = userApplicationBL.GetApplicationsByCollege(null, Enum.GetName(typeof(Status), Convert.ToInt32(TempData["Status"])));
            }
            else
            {
                applications = userApplicationBL.GetApplications();              
            }
            foreach (UserApplication application in applications)
            {
                applicationModels.Add(AutoMapper.Mapper.Map<UserApplication, UserApplicationModel>(application));
            }
            return View(applicationModels);
        }
        // GET: UserApplications/Details/5

        [HttpGet]
        public ActionResult Create(string code, int deptId, string mailId)
        {
            CollegeDepartment collegeDepartment = departmentBL.CheckExistsDepartment(deptId, code);
            if(collegeDepartment.AvailableSeats > 0)
            {
                College college = collegeBL.GetCollegeByCode(code);
                Department department = departmentBL.GetDepartmentById(deptId);               
                TempData["College"] = college;
                TempData["CollegeName"] = college.CollegeName;
                TempData["Department"] = department;
                TempData["DeptName"] = department.DeptName;
                return View();
            }
            TempData["Message"] = "This Department has no Seats";
            return RedirectToAction("DisplayDepartmentByStudent", "Department", new { code = code });
        }

        [HttpPost]
        public ActionResult Create(UserApplicationModel userApplicationModel)
        {           
            if (ModelState.IsValid)
            {
                User user = userBL.GetUser(this.HttpContext.User.Identity.Name);
                userApplicationModel.UserId = user.UserId;
                userApplicationModel.CollegeCode = ((College)TempData["College"]).CollegeCode;
                userApplicationModel.DeptId = ((Department)TempData["Department"]).DeptId;
                userApplicationModel.Status = Enum.GetName(typeof(Status), 0);
                UserApplication application = AutoMapper.Mapper.Map<UserApplicationModel, UserApplication>(userApplicationModel);
                if (userApplicationBL.AddApplication(application))
                    return RedirectToAction("Sucess", "UserApplications");
                else
                    return RedirectToAction("DisplayDepartmentByStudent", "Department",new { code = application.CollegeCode });
            }
            userApplicationModel.college = (College)TempData["College"];
            userApplicationModel.department = (Department)TempData["Department"];
            TempData["CollegeName"] = ((College)TempData["College"]).CollegeName;
            TempData["DeptName"] = ((Department)TempData["Department"]).DeptName;
            return View(userApplicationModel);
        }
        public ActionResult Sucess()
        {
            return View();
        }

        public ActionResult ShowApplicationByAdmin(int applicationNumber)
        {
            UserApplication application = userApplicationBL.GetApplication(applicationNumber);
            UserApplicationModel applicationModel = AutoMapper.Mapper.Map<UserApplication, UserApplicationModel>(application);
            return View(applicationModel);
        }
        public ActionResult ShowApplicationByUser(string mailId)
        {
            IEnumerable<UserApplication> applications = userApplicationBL.GetApplicationByUser(mailId);
            List<UserApplicationModel> applicationModels = new List<UserApplicationModel>();
            foreach (UserApplication application in applications)
            {
                applicationModels.Add(AutoMapper.Mapper.Map<UserApplication, UserApplicationModel>(application));
            }
            return View(applicationModels);
        }
        public ActionResult UpdateApplication(int applicationNumber, int status)
        {
            userApplicationBL.UpdateApplication(applicationNumber, Enum.GetName(typeof(Status), status));
            return RedirectToAction("DisplayApplications");
        }

        [HttpPost]
        public ActionResult Search(string college, string status)
        {
            if(college != "" || status != "")
            {
                if (college != "" && status != "")
                {
                    TempData["CollegeCode"] = college;
                    TempData["Status"] = status;
                }
                else if (status == "")
                {
                    TempData["CollegeCode"] = college;
                }
                else
                {
                    TempData["Status"] = status;
                }
            }           
            return RedirectToAction("DisplayApplications", "UserApplications");
        }
    }

}
