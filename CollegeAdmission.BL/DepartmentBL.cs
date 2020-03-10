using CollegeAdmission.DAL;
using CollegeAdmission.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeAdmission.BL
{
    public class DepartmentBL
    {
        DepartmentRepository departmentRepository;
        public DepartmentBL()
        {
            departmentRepository = new DepartmentRepository();
        }
        public CollegeDepartment GetDepartment(int id)
        {
            return departmentRepository.GetDepartment(id);
        }
        public List<CollegeDepartment> GetDepartmentByCollege(string collegeCode)
        {
            return departmentRepository.GetDepartmentByCollege(collegeCode);
        }
        public void AddDepartmentByCollege(CollegeDepartment collegeDepartment)
        {
            departmentRepository.AddDepartmentByCollege(collegeDepartment);
        }
        public List<Department> GetDepartmentList()
        {
            return departmentRepository.GetDepartmentList();
        }
        public string GetDepartmentNameById(int id)
        {
            return departmentRepository.GetDepartmentNameById(id);
        }
        public int GetDepartmentId(string deptName)
        {
            return departmentRepository.GetDepartmentId(deptName);
        }
        public void EditDepartment(CollegeDepartment collegeDepartment)
        {
            departmentRepository.EditDepartment(collegeDepartment);
        }
        public void DeleteDepartment(CollegeDepartment collegeDepartment)
        {
            departmentRepository.DeleteDepartment(collegeDepartment);
        }
    }
}
