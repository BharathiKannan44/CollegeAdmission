using CollegeAdmission.BL;
using AutoMapper;
using CollegeAdmission.Entity;
using CollegeAdmission.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollegeAdmission.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        DepartmentBL departmentBL;
        public DepartmentController()
        {
            departmentBL = new DepartmentBL();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DisplayDepartmentByCollege(string collegeCode)
        {
            List<CollegeDepartment> departmentList = departmentBL.GetDepartmentByCollege(collegeCode);
            TempData["CollegeCode"] = collegeCode;
            List<DepartmentViewModel> departmentViewModelList = new List<DepartmentViewModel>();
            foreach (CollegeDepartment department in departmentList)
            {
                DepartmentViewModel departmentViewModel = AutoMapper.Mapper.Map<CollegeDepartment, DepartmentViewModel>(department);
                departmentViewModelList.Add(departmentViewModel);
            }
            return View(departmentViewModelList);
        }
        public ActionResult AddDepartment()
        {
            DepartmentViewModel departmentViewModel = new DepartmentViewModel();
            departmentViewModel.CollegeCode = TempData["CollegeCode"].ToString();
            List<Department> departments = departmentBL.GetDepartmentList();
            List<SelectListItem> deptList = new List<SelectListItem>();
            foreach (Department department in departments)
            {
                deptList.Add(new SelectListItem { Text = @department.DeptName, Value = @department.DeptId.ToString() });
            }
            ViewBag.Dept = deptList;
            return View(departmentViewModel);
        }  
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDepartment(DepartmentViewModel departmentViewModel)
        {
            List<Department> departments = departmentBL.GetDepartmentList();
            List<SelectListItem> deptList = new List<SelectListItem>();
            foreach (Department department in departments)
            {
                deptList.Add(new SelectListItem { Text = @department.DeptName, Value = @department.DeptId.ToString() });
            }
            ViewBag.Dept = deptList;
            if (ModelState.IsValid)
            {
                CollegeDepartment collegeDepartment = AutoMapper.Mapper.Map<DepartmentViewModel, CollegeDepartment>(departmentViewModel);
                departmentBL.AddDepartmentByCollege(collegeDepartment);
                return RedirectToAction("DisplayDepartmentByCollege",collegeDepartment.CollegeCode);
            }
            return View();
        }
        public ActionResult EditDepartment(int id)
        {
            CollegeDepartment collegeDepartment = departmentBL.GetDepartment(id);
            DepartmentViewModel departmentViewModel = AutoMapper.Mapper.Map<CollegeDepartment,DepartmentViewModel>(collegeDepartment);
            return View(departmentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDepartment(DepartmentViewModel departmentViewModel)
        {
            if (ModelState.IsValid)
            {
                CollegeDepartment collegeDepartment = Mapper.Map<DepartmentViewModel, CollegeDepartment>(departmentViewModel);
                departmentBL.EditDepartment(collegeDepartment);
                return RedirectToAction("DisplayDepartmentByCollege",collegeDepartment.CollegeCode);
            }
            return View();
        }
        public ActionResult DeleteDepartment(int id)
        {
            CollegeDepartment collegeDepartment = departmentBL.GetDepartment(id);
            departmentBL.DeleteDepartment(collegeDepartment);
            return RedirectToAction("DisplayDepartmentByCollege",collegeDepartment.CollegeCode);
        }

    }
}