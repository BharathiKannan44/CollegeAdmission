using CollegeAdmission.DAL;
using CollegeAdmission.Entity;

namespace CollegeAdmission.BL
{
    public class UserBL
    {
        UserRepository userRepository;
        public UserBL()
        {
            userRepository = new UserRepository();
        }
        public void SignUp(User user)
        {
            userRepository.SignUp(user);
        }
        public User Login(string emailId,string password)
        {
            return userRepository.Login(emailId, password);
        }

    }
}
