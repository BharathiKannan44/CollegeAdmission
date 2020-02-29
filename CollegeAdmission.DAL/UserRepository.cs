using CollegeAdmission.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeAdmission.DAL
{
    public class UserRepository
    {
        public void SignUp(User user)
        {
            CollegeDBContext collegeDBContext = new CollegeDBContext();
            collegeDBContext.User.Add(user);
            collegeDBContext.SaveChanges();
        }

        public void Login()
        {
            CollegeDBContext collegeDBContext = new CollegeDBContext();
            
        }
    }
}
