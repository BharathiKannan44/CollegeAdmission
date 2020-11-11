using CollegeAdmission.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CollegeAdmission.DAL
{
    public interface IApplicationRepository
    {
        IEnumerable<UserApplication> GetApplications();
        void AddApplication(UserApplication application);
        IEnumerable<UserApplication> GetApplicationsByCollege(string collegeCode,string status);
        UserApplication GetApplication(int applicationNumber);
        void UpdateApplication(UserApplication application);
        IEnumerable<UserApplication> GetApplicationsByUser(User user);
    }
    public class ApplicationRepository : IApplicationRepository
    {
        public IEnumerable<UserApplication> GetApplications()
        {
            using (CollegeDBContext collegeDBContext = new CollegeDBContext())
            {
                return collegeDBContext.UserApplications.Include("College").Include("Department").Include("User").ToList();
            }
        }
        public void AddApplication(UserApplication application)
        {
            using (CollegeDBContext collegeDBContext = new CollegeDBContext())
            {
                collegeDBContext.UserApplications.Add(application);
                collegeDBContext.SaveChanges();
            }   
        }
        public IEnumerable<UserApplication> GetApplicationsByCollege(string collegeCode,string status)
        {
            using (CollegeDBContext collegeDBContext = new CollegeDBContext())
            {
                if(collegeCode != null && status != null)
                    return collegeDBContext.UserApplications.Include("College").Include("Department").Include("User").Where(m => m.CollegeCode == collegeCode && m.Status == status).ToList();
                else if(collegeCode != null)
                    return collegeDBContext.UserApplications.Include("College").Include("Department").Include("User").Where(m => m.CollegeCode == collegeCode).ToList();
                else
                    return collegeDBContext.UserApplications.Include("College").Include("Department").Include("User").Where(m => m.Status == status).ToList();
            }
        }
        public UserApplication GetApplication(int applicationNumber)
        {
            using (CollegeDBContext collegeDBContext = new CollegeDBContext())
            {
                return collegeDBContext.UserApplications.Include("College").Include("Department").Include("User").Where(m => m.ApplicationNumber == applicationNumber).FirstOrDefault();
            }
        }
        public void UpdateApplication(UserApplication application)
        {
            using (CollegeDBContext collegeDBContext = new CollegeDBContext())
            {

                collegeDBContext.Entry(application).State = EntityState.Modified;
                collegeDBContext.SaveChanges();
            }
        }
        public IEnumerable<UserApplication> GetApplicationsByUser(User user)
        {
            using (CollegeDBContext collegeDBContext = new CollegeDBContext())
            {
                return collegeDBContext.UserApplications.Include("College").Include("Department").Include("User").Where(m => m.UserId == user.UserId).ToList();
            }
        }
    }
}
