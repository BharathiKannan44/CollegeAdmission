using CollegeAdmission.DAL;
using CollegeAdmission.Entity;
using System.Collections.Generic;


namespace CollegeAdmission.BL
{
    public interface IDepartmentBL
    {
        CollegeDepartment GetDepartment(int id);
        IEnumerable<CollegeDepartment> GetDepartmentByCollege(string collegeCode);
        bool AddDepartmentByCollege(CollegeDepartment collegeDepartment);
        IEnumerable<Department> GetDepartmentList();
        void EditDepartment(CollegeDepartment collegeDepartment);
        void DeleteDepartment(int id);
        CollegeDepartment CheckExistsDepartment(int deptId, string collegeCode);
        Department GetDepartmentById(int id);
    }
    //
    //Summary:
    //  Business Class for Deprtments
    public class DepartmentBL : IDepartmentBL
    {
        IDepartmentRepository departmentRepository;
        //
        //Summary:
        //  Here Create Instance for Department Repository
        public DepartmentBL()
        {
            departmentRepository = new DepartmentRepository();
        }
        public CollegeDepartment GetDepartment(int id)
        {
            return departmentRepository.GetDepartment(id);
        }
        public IEnumerable<CollegeDepartment> GetDepartmentByCollege(string collegeCode)
        {
            return departmentRepository.GetDepartmentByCollege(collegeCode);
        }
        //
        //Summary:
        // This Method Check the Department is Exists or not and the Add to the Databae.
        public bool AddDepartmentByCollege(CollegeDepartment collegeDepartment)
        {
            if (departmentRepository.CheckExistsDepartment(collegeDepartment.DeptId, collegeDepartment.CollegeCode) == null)
            {
                departmentRepository.AddDepartmentByCollege(collegeDepartment);
                return true;
            }
            return false;
        }
        public IEnumerable<Department> GetDepartmentList()
        {
            return departmentRepository.GetDepartmentList();
        }
        public void EditDepartment(CollegeDepartment collegeDepartment)
        {
            departmentRepository.EditDepartment(collegeDepartment);
        }
        public void DeleteDepartment(int id)
        {
            departmentRepository.DeleteDepartment(id);
        }
        public Department GetDepartmentById(int id)
        {
            return departmentRepository.GetDepartmentById(id);
        }
        public CollegeDepartment CheckExistsDepartment(int deptId, string collegeCode)
        {
            return departmentRepository.CheckExistsDepartment(deptId, collegeCode);
        }
    }
}
