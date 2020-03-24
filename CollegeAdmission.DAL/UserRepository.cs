using CollegeAdmission.Entity;
using System.Linq;

namespace CollegeAdmission.DAL
{
    //
    //Summary:
    //  Interface for User opertions
    public interface IUserRepository
    {
        void SignUp(User user);
        User Login(string emailId, string password);
        User CheckExistUser(User user);
    }

    //
    //Summary:
    //  This Class provides methods for User
    public class UserRepository : IUserRepository
    {
        //
        //Summary:
        //  This method is used register user details to the database
        public void SignUp(User user)
        {
            using (CollegeDBContext collegeDBContext = new CollegeDBContext())
            {
                collegeDBContext.User.Add(user);
                collegeDBContext.SaveChanges();
            }              
        }

        //
        //Summary:
        //  This method is used to check Login details
        public User Login(string emailId,string password)
        {
            using (CollegeDBContext collegeDBContext = new CollegeDBContext())
            {
                return collegeDBContext.User.Where(m => m.EmailId == emailId && m.Password == password).FirstOrDefault();
            }              
        }

        //
        //Summary:
        //  Check User is already Exists or not.
        //Return:
        //  Return User Entity
        public User CheckExistUser(User user)
        {
            using(CollegeDBContext collegeDBContext = new CollegeDBContext())
            {
                return collegeDBContext.User.Where(m => m.EmailId == user.EmailId).FirstOrDefault();
            }
        }
    }
}
