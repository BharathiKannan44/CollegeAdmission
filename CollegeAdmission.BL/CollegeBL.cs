using CollegeAdmission.DAL;
using CollegeAdmission.Entity;
using System.Collections.Generic;

namespace CollegeAdmission.BL
{
    public class CollegeBL
    {
        CollegeRepository collegeRepository;
        public CollegeBL()
        {
            collegeRepository = new CollegeRepository();
        }
        public IEnumerable<College> GetColleges()
        {
            return collegeRepository.GetColleges();
        }
        public void AddCollege(College college)
        {
            collegeRepository.AddCollege(college);
        }
        public College GetCollegeByCode(string id)
        {
            return collegeRepository.GetCollegeByCode(id);
        }
        public void UpdateCollege(College college)
        {
            collegeRepository.UpdateCollege(college);
        }
        public void DeleteCollege(string code)
        {
            collegeRepository.DeleteCollege(code);
        }
        public  IEnumerable<CollegeDepartment> GetDepartment(string collegeCode)
        {
            return collegeRepository.GetDepartment(collegeCode);
        }
        public List<Department> GetAllDepartments()
        {
            return collegeRepository.GetAllDepartments();
        }
      
    }
}
