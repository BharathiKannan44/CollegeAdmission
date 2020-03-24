using System.Collections.Generic;
using System.Web.Mvc;
using CollegeAdmission.BL;
using CollegeAdmission.Entity;
using CollegeAdmission.Filters;
using CollegeAdmission.ViewModel;

namespace CollegeAdmission.Controllers
{
    //
    //Summary:
    //  This class provide Provides methods that respond to HTTP requests based on Colleges
    [ExceptionFilter]
    public class CollegesController : Controller
    {
        ICollegeBL collegeBL;
        //
        //Summary:
        //    Here, The Constructor Create instance for CollegeBL.
        public CollegesController()
        {
            collegeBL = new CollegeBL();
        }
        public ActionResult Index()
        {
            return View();
        }

        // 
        //Summary:
        //  The Action Method get the colleges From the Database
        [Authorize(Roles = "Admin")]
        public ActionResult DisplayCollege()
        {
            IEnumerable<College> collegesList = collegeBL.GetColleges();
            List<CollegeViewModel> collegeModelList = new List<CollegeViewModel>();
            foreach (College college in collegesList)
            {
                CollegeViewModel collegeViewModel = AutoMapper.Mapper.Map<College, CollegeViewModel>(college);
                collegeModelList.Add(collegeViewModel);
            }
            return View(collegeModelList);
        }

        //
        //Summary:
        //  The Action is used call the Add view
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        //
        //Summary:
        //  Post Method for Add College to the database
        //Parameter:
        //  CollegeViewModel:
        //      This object contains college fields
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CollegeViewModel collegeViewModel)
        {
            if (ModelState.IsValid)
            {
                College college = AutoMapper.Mapper.Map<CollegeViewModel, College>(collegeViewModel);
                if (collegeBL.AddCollege(college))
                {
                    TempData["CollegeCode"] = college.CollegeCode;
                    return RedirectToAction("AddDepartment", "Department");
                }
                ViewData["Message"] = Message.CollegeExists;
            }
            return View(collegeViewModel);
        }

        //
        //Summary:
        //  The Action is used to call the edit view and pass CollegeViewModel object
        //Parameter:
        //      code:
        //          get Department by using this code
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string code)
        {
            College college = collegeBL.GetCollegeByCode(code);
            CollegeViewModel collegeViewModel = AutoMapper.Mapper.Map<College, CollegeViewModel>(college);
            return View(collegeViewModel);
        }

        //
        //Summary:
        //  Post Method for update College to the database
        //Parameter:
        //  CollegeViewModel:
        //      This object contains College fields   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CollegeViewModel collegeViewModel)
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

        //
        //Summary:
        //  This Method is used to call the Delete view and pass CollegeViewModel object
        //Parameter:
        //  CollegeViewModel:
        //      This object contains College fields  
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string code)
        {
            College college = collegeBL.GetCollegeByCode(code);
            CollegeViewModel collegeViewModel = AutoMapper.Mapper.Map<College, CollegeViewModel>(college);
            return View(collegeViewModel);           
        }

        //
        //Summary:
        //  Post Method for Delete College to the database
        //Parameter:
        //  CollegeViewModel:
        //      This object contains College fields  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CollegeViewModel collegeViewModel)
        {
            collegeBL.DeleteCollege(collegeViewModel.CollegeCode);
            TempData["Message"] = Message.Deleted;
            return RedirectToAction("DisplayCollege");
        }

        // 
        //Summary:
        //  The Action Method get the colleges From the Database for display to the students.
        [Authorize(Roles = "User")]
        public ActionResult DisplayCollegeByStudent()
        {
            IEnumerable<College> collegesList = collegeBL.GetColleges();
            List<CollegeViewModel> collegeModelList = new List<CollegeViewModel>();
            foreach (College college in collegesList)
            {
                CollegeViewModel collegeViewModel = AutoMapper.Mapper.Map<College, CollegeViewModel>(college);
                collegeModelList.Add(collegeViewModel);
            }
            return View(collegeModelList);
        }
    }
}
