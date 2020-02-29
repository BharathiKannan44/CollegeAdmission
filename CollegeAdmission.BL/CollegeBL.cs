using CollegeAdmission.DAL;
using CollegeAdmission.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeAdmission.BL
{
    public class CollegeBL
    {
        CollegeRepository collegeRepository;
        public CollegeBL()
        {
            collegeRepository = new CollegeRepository();
        }
        public void AddCollege(College college)
        {
            collegeRepository.AddCollege(college);
        }
    }
}
