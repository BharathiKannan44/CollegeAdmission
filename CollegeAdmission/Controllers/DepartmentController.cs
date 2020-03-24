using CollegeAdmission.BL;
using AutoMapper;
using CollegeAdmission.Entity;
using CollegeAdmission.ViewModel;
using System.Collections.Generic;
using System.Web.Mvc;
using CollegeAdmission.Filters;

namespace CollegeAdmission.Controllers
{
    //
    //Summary:
    //  This class provide Provides methods that respond to HTTP requests based on Departments
    [ExceptionFilter]
    public class DepartmentController : Controller
    {
        // GET: Department
        IDepartmentBL departmentBL;

        //
        //Summary:
        //    Here, The Constructor Create instance for DepartmentBL.
        public DepartmentController()
        {
            departmentBL = new DepartmentBL();
        }
        public ActionResult Index()
        {
            return View();
        }

        // 
        //Summary:
        //  The Action Method get the departments From the Database
        [Authorize(Roles = "Admin")]
        public ActionResult DisplayDepartmentByCollege()
        {
            IEnumerable<CollegeDepartment> departmentList = departmentBL.GetDepartmentByCollege(TempData["CollegeCode"].ToString());
            List<DepartmentViewModel> departmentViewModelList = new List<DepartmentViewModel>();
            foreach (CollegeDepartment department in departmentList)
            {
                DepartmentViewModel departmentViewModel = AutoMapper.Mapper.Map<CollegeDepartment, DepartmentViewModel>(department);
                departmentViewModelList.Add(departmentViewModel);
            }
            return View(departmentViewModelList);
        }

        //
        //Summary:
        //  The Action is used call the view and pass Department view model with college code 
        [Authorize(Roles = "Admin")]
        public ActionResult AddDepartment()
        {
            DepartmentViewModel departmentViewModel = new DepartmentViewModel();
            departmentViewModel.CollegeCode = TempData["CollegeCode"].ToString();
            IEnumerable<Department> departments = departmentBL.GetDepartmentList();
            List<SelectListItem> deptList = new List<SelectListItem>();
            foreach (Department department in departments)
            {
                deptList.Add(new SelectListItem { Text = @department.DeptName, Value = @department.DeptId.ToString() });
            }
            ViewBag.Dept = deptList;
            return View(departmentViewModel);
        }  
        
        //
        //Summary:
        //  Post Method for Add Department to the database
        //Parameter:
        //  departmentViewModel:
        //      This object contains department fields
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDepartment(DepartmentViewModel departmentViewModel)
        {
            IEnumerable<Department> departments = departmentBL.GetDepartmentList();
            List<SelectListItem> deptList = new List<SelectListItem>();
            foreach (Department department in departments)
            {
                deptList.Add(new SelectListItem { Text = @department.DeptName, Value = @department.DeptId.ToString() });
            }
            ViewBag.Dept = deptList;
            if (ModelState.IsValid)
            {
                CollegeDepartment collegeDepartment = AutoMapper.Mapper.Map<DepartmentViewModel, CollegeDepartment>(departmentViewModel);
                if(departmentBL.AddDepartmentByCollege(collegeDepartment))
                {
                    TempData["CollegeCode"] = collegeDepartment.CollegeCode;
                    TempData["Message"] = Message.Added;
                    return RedirectToAction("DisplayDepartmentByCollege");
                }
                ViewData["Message"] = Message.AlreadyAdded;
            }
            return View();
        }

        //
        //Summary:
        //  The Action is used to call the edit view and pass DepartmentViewModel object
        //Parameter:
        //      id:
        //          get Department by using this id
        [Authorize(Roles = "Admin")]
        public ActionResult EditDepartment(int id)
        {
            CollegeDepartment collegeDepartment = departmentBL.GetDepartment(id);
            DepartmentViewModel departmentViewModel = AutoMapper.Mapper.Map<CollegeDepartment,DepartmentViewModel>(collegeDepartment);
            return View(departmentViewModel);
        }

        //
        //Summary:
        //  Post Method for update Department to the database
        //Parameter:
        //  departmentViewModel:
        //      This object contains department fields    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDepartment(DepartmentViewModel departmentViewModel)
        {
            if (ModelState.IsValid)
            {
                CollegeDepartment collegeDepartment = Mapper.Map<DepartmentViewModel, CollegeDepartment>(departmentViewModel);
                departmentBL.EditDepartment(collegeDepartment);
                TempData["CollegeCode"] = collegeDepartment.CollegeCode;
                return RedirectToAction("DisplayDepartmentByCollege");
            }
            return View();
        }

        //
        //Summary:
        //  This Method is used to call the Delete view and pass DepartmentViewModel object
        //Parameter:
        //  departmentViewModel:
        //      This object contains department fields  
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteDepartment(int id)
        {
            CollegeDepartment collegeDepartment = departmentBL.GetDepartment(id);
            DepartmentViewModel departmentViewModel = AutoMapper.Mapper.Map<CollegeDepartment, DepartmentViewModel>(collegeDepartment);
            return View(departmentViewModel);
        }

        //
        //Summary:
        //  Post Method for Delete Department to the database
        //Parameter:
        //  departmentViewModel:
        //      This object contains department fields  
        [HttpPost]
        public ActionResult DeleteDepartment(DepartmentViewModel departmentViewModel)
        {
            CollegeDepartment collegeDepartment = Mapper.Map<DepartmentViewModel, CollegeDepartment>(departmentViewModel);
            TempData["CollegeCode"] = collegeDepartment.CollegeCode;
            departmentBL.DeleteDepartment(collegeDepartment.ID);
            TempData["Message"] = Message.Deleted;
            return RedirectToAction("DisplayDepartmentByCollege");
        }

        // 
        //Summary:
        //  The Action Method get the Departments From the Database for display to the students.
        [Authorize(Roles = "User")]
        public ActionResult DisplayDepartmentByStudent(string code)
        {
            IEnumerable<CollegeDepartment> departmentList = departmentBL.GetDepartmentByCollege(code);
            List<DepartmentViewModel> departmentViewModelList = new List<DepartmentViewModel>();
            foreach (CollegeDepartment department in departmentList)
            {
                DepartmentViewModel departmentViewModel = AutoMapper.Mapper.Map<CollegeDepartment, DepartmentViewModel>(department);
                departmentViewModelList.Add(departmentViewModel);
            }
            return View(departmentViewModelList);
        }
    }
}