using CollegeAdmission.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeAdmission.DAL
{
    public class DepartmentRepository
    {
        CollegeDBContext collegeDBContext;
        public DepartmentRepository()
        {
            collegeDBContext = new CollegeDBContext();
        }
        public CollegeDepartment GetDepartment(int id)
        {
            return collegeDBContext.CollegeDepartments.Find(id);
        }
        public List<CollegeDepartment> GetDepartmentByCollege(string collegeCode)
        {
            return collegeDBContext.CollegeDepartments.Where(m => m.CollegeCode == collegeCode).ToList();
        }
        public void AddDepartmentByCollege(CollegeDepartment collegeDepartment)
        {
            collegeDBContext.CollegeDepartments.Add(collegeDepartment);
            collegeDBContext.SaveChanges();
        }
        public List<Department> GetDepartmentList()
        {
            return collegeDBContext.Departments.ToList();
        }
        public string GetDepartmentNameById(int id)
        {
            return collegeDBContext.Departments.Find(id).DeptName;
        }
        public int GetDepartmentId(string deptName)
        {
            List<Department> departments = GetDepartmentList();
            foreach(Department department in departments)
            {
                if(department.DeptName == deptName)
                {
                    return department.DeptId;
                }
            }
            return -1;
        }
        public void EditDepartment(CollegeDepartment collegeDepartment)
        {
            using (CollegeDBContext collegeDBContext = new CollegeDBContext())
            {
                collegeDBContext.Entry(collegeDepartment).State = EntityState.Modified;
                collegeDBContext.SaveChanges();
            }
        }
        public void DeleteDepartment(CollegeDepartment department)
        {
            using (CollegeDBContext collegeDBContext = new CollegeDBContext())
            {
                collegeDBContext.CollegeDepartments.Remove(department);
                collegeDBContext.SaveChanges();
            }
        }
    }
}
