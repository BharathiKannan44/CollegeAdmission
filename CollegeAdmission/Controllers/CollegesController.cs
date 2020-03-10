using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using CollegeAdmission.BL;
using CollegeAdmission.Entity;
using CollegeAdmission.ViewModel;

namespace CollegeAdmission.Controllers
{
    public class CollegesController : Controller
    {
        CollegeBL collegeBL;

        public CollegesController()
        {
            collegeBL = new CollegeBL();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DisplayCollege()
        {
            IEnumerable<College> collegesList = collegeBL.GetColleges();
            List<CollegeViewModel> collegeModelList = new List<CollegeViewModel>();
            foreach (College college in collegesList)
            {
                CollegeViewModel collegeViewModel = AutoMapper.Mapper.Map<College, CollegeViewModel>(college);
                //foreach(CollegeDepartment department in college.CollegeDepartments)
                //{
                //   DepartmentViewModel departmentViewModel = Mapper.Map<CollegeDepartment,DepartmentViewModel>(department);
                //    collegeViewModel.DepartmentViewModel.Add(departmentViewModel);
                //}   
                collegeModelList.Add(collegeViewModel);
            }
            return View(collegeModelList);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CollegeViewModel collegeViewModel)
        {
            if (ModelState.IsValid)
            {
                College college = AutoMapper.Mapper.Map<CollegeViewModel, College>(collegeViewModel);
                collegeBL.AddCollege(college);
                TempData["CollegeCode"] = college.CollegeCode;
                return RedirectToAction("AddDepartment", "Department");
            }
            return View(collegeViewModel);
        }
        public ActionResult Edit(string code)
        {
            College college = collegeBL.GetCollegeByCode(code);
            CollegeViewModel collegeViewModel = AutoMapper.Mapper.Map<College, CollegeViewModel>(college);
            return View(collegeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CollegeCode,CollegeName,CollegeWebsite")] CollegeViewModel collegeViewModel)
        {
            if (ModelState.IsValid)
            {
                College college = AutoMapper.Mapper.Map<CollegeViewModel, College>(collegeViewModel);
                collegeBL.UpdateCollege(college);
                TempData["CollegeCode"] = college.CollegeCode;
                return RedirectToAction("DisplayDepartmentByCollege", "Department");
            }
            return View(collegeViewModel);
        }
        public ActionResult Delete(string code)
        {
            collegeBL.DeleteCollege(code);
            return RedirectToAction("DisplayColleges");
        }
    }
}
