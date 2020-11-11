using CollegeAdmission.DAL;
using CollegeAdmission.Entity;

namespace CollegeAdmission.BL
{
    public interface IUserBL
    {
        bool SignUp(User user);
        User Login(string emailId, string password);
        User GetUser(string emailId);
    }
    //
    //Summary:
    // Business Class for Users
    public class UserBL : IUserBL
    {
        IUserRepository userRepository;
        public UserBL()
        {
            userRepository = new UserRepository();
        }

        //
        //Summary:
        //  This Method Check the User Already Exists and then Add to the Db.
        //Return:
        //  Returns User Entity
        public bool SignUp(User user)
        {
            if(userRepository.CheckExistUser(user) == null) 
            {
                userRepository.SignUp(user);
                return true;
            }
            return false;            
        }

        public User Login(string emailId,string password)
        {
            return userRepository.Login(emailId, password);
        }

        public User GetUser(string emailId)
        {
            return userRepository.GetUser(emailId);
        }
    }
}
