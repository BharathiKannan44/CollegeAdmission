using CollegeAdmission.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CollegeAdmission.DAL
{
    //
    //Summary:
    // Interface for connect User interface and database
    public interface ICollegeRepository
    {
        IEnumerable<College> GetColleges();
        void AddCollege(College college);
        College GetCollegeByCode(string id);
        void UpdateCollege(College college);
        void DeleteCollege(string code);
        College CheckExistCollege(College college);
    }

    //
    //Summary:
    // This class provides method for college CRUD opertions
    public class CollegeRepository : ICollegeRepository
    {
        //
        //Summary:
        //  This method is to get college from database
        //Return:
        //  returns List of  Colleges
        public IEnumerable<College> GetColleges()
        {
            using (CollegeDBContext collegeDBContext = new CollegeDBContext())
            {
                return collegeDBContext.Colleges.ToList();
            }       
        }

        //
        //Summary:
        //  This method is to Add college to database
        public void AddCollege(College college)
        {
            using (CollegeDBContext collegeDBContext = new CollegeDBContext())
            {
                SqlParameter collegeCode = new SqlParameter("@CollegeCode", college.CollegeCode);
                SqlParameter collegeName = new SqlParameter("@CollegeName", college.CollegeName);
                SqlParameter collegeWebsite = new SqlParameter("@CollegeWebsite", college.CollegeWebsite);
                collegeDBContext.Database.ExecuteSqlCommand("College_Insert @CollegeCode, @CollegeName, @CollegeWebsite", collegeCode, collegeName, collegeWebsite);
                //collegeDBContext.Colleges.Add(college);
                //collegeDBContext.SaveChanges();
            }
        }

        //
        //Summary:
        //  This method is to get College using code from database
        //Return:
        //  Returns College object
        public College GetCollegeByCode(string code)
        {
            using (CollegeDBContext collegeDBContext = new CollegeDBContext())
            {
                return collegeDBContext.Colleges.Find(code);
            }

        }

        //
        //Summary:
        //  This method is to Update college to database
        public void UpdateCollege(College college)
        {
            using (CollegeDBContext collegeDBContext = new CollegeDBContext())
            {
                SqlParameter collegeCode = new SqlParameter("@CollegeCode", college.CollegeCode);
                SqlParameter collegeName = new SqlParameter("@CollegeName", college.CollegeName);
                SqlParameter collegeWebsite = new SqlParameter("@CollegeWebsite", college.CollegeWebsite);
                collegeDBContext.Database.ExecuteSqlCommand("College_Update @CollegeCode, @CollegeName, @CollegeWebsite", collegeCode, collegeName, collegeWebsite);
                //collegeDBContext.Entry(college).State = EntityState.Modified;
                //collegeDBContext.SaveChanges();
            }
        }

        //
        //Summary:
        //  This method is to delete college
        public void DeleteCollege(string code)
        {
            using (CollegeDBContext collegeDBContext = new CollegeDBContext())
            {
                SqlParameter collegeCode = new SqlParameter("@CollegeCode", code);
                collegeDBContext.Database.ExecuteSqlCommand("College_Delete @CollegeCode", collegeCode);
                //College college = GetCollegeByCode(code);
                //collegeDBContext.Colleges.Remove(college);
                //collegeDBContext.SaveChanges();
            }
        }

        //
        //Summary:
        // Check Exists College in Db
        //Return:
        // Returns College Entity 
        public College CheckExistCollege(College college)
        {
            using(CollegeDBContext collegeDBContext = new CollegeDBContext())
            {
                return collegeDBContext.Colleges.Where(c => c.CollegeCode == college.CollegeCode || c.CollegeName == college.CollegeName || c.CollegeWebsite == college.CollegeWebsite).FirstOrDefault();
            }
        }
    }
}
