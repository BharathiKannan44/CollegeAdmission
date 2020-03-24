using CollegeAdmission.DAL;
using CollegeAdmission.Entity;
using System.Collections.Generic;

namespace CollegeAdmission.BL
{
    //
    //Summmary:
    //  Interface for College Business Layer
    public interface ICollegeBL
    {
        IEnumerable<College> GetColleges();
        bool AddCollege(College college);
        College GetCollegeByCode(string id);
        void UpdateCollege(College college);
        void DeleteCollege(string code);
    }

    //
    //Summary:
    //  This Class provides method for Busines Logic based on Colleges
    public class CollegeBL : ICollegeBL
    {
        ICollegeRepository collegeRepository;

        //
        //summary:
        // Here create Instance for College Repository
        public CollegeBL()
        {
            collegeRepository = new CollegeRepository();
        }

        public IEnumerable<College> GetColleges()
        {
            return collegeRepository.GetColleges();
        }
        //
        //Summary:
        // This Method Check the college is Exists or not and the Add to the Databae.
        public bool AddCollege(College college)
        {
            if(collegeRepository.CheckExistCollege(college) == null)
            {
                collegeRepository.AddCollege(college);
                return true;
            }
            return false;
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
    }
}
