using CollegeAdmission.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CollegeAdmission.DAL
{
    public class CollegeRepository
    {

        public IEnumerable<College> GetColleges()
        {
            List<College> collegeList = new List<College>();
            using (CollegeDBContext collegeDBContext = new CollegeDBContext())
            {
                collegeList = collegeDBContext.Colleges.ToList();
            }
            return collegeList;
        }

        public void AddCollege(College college)
        {
            using (CollegeDBContext collegeDBContext = new CollegeDBContext())
            {
                collegeDBContext.Colleges.Add(college);
                collegeDBContext.SaveChanges();
            }
        }
        public College GetCollegeByCode(string code)
        {
            using (CollegeDBContext collegeDBContext = new CollegeDBContext())
            {
                return collegeDBContext.Colleges.Find(code);
            }

        }
        public void UpdateCollege(College college)
        {
            using (CollegeDBContext collegeDBContext = new CollegeDBContext())
            {
                collegeDBContext.Entry(college).State = EntityState.Modified;
                collegeDBContext.SaveChanges();
            }
        }
        public void DeleteCollege(string code)
        {
            using (CollegeDBContext collegeDBContext = new CollegeDBContext())
            {
                College college = GetCollegeByCode(code);
                collegeDBContext.Colleges.Remove(college);
                collegeDBContext.SaveChanges();
            }
        }
        public IEnumerable<CollegeDepartment> GetDepartment(string collegeCode)
        {
            using (CollegeDBContext collegeDBContext = new CollegeDBContext())
            {
                List<CollegeDepartment> departments = collegeDBContext.CollegeDepartments.Where(n => n.CollegeCode == collegeCode).ToList();
                return departments;
            }
        }
        public List<Department> GetAllDepartments()
        {
            using (CollegeDBContext collegeDBContext = new CollegeDBContext())
            {
                List<Department> departments = collegeDBContext.Departments.ToList();
                return departments;
            }
        }
        
    }
}
