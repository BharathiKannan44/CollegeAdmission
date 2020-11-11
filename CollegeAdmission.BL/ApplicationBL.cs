using CollegeAdmission.DAL;
using CollegeAdmission.Entity;
using System.Collections.Generic;
using System.Globalization;

namespace CollegeAdmission.BL
{
    public interface IApplicationBL
    {
        IEnumerable<UserApplication> GetApplications();
        IEnumerable<UserApplication> GetApplicationsByCollege(string collegeCode,string status);
        bool AddApplication(UserApplication application);
        UserApplication GetApplication(int applicationNumber);
        void UpdateApplication(int applicationNumber, string status);
        IEnumerable<UserApplication> GetApplicationByUser(string mailId);
    }

    public class ApplicationBL : IApplicationBL
    {
        IApplicationRepository applicationRepository;
        public ApplicationBL()
        {
           applicationRepository = new ApplicationRepository();
        }
        public IEnumerable<UserApplication> GetApplications()
        {
            return applicationRepository.GetApplications();
        }
        public bool AddApplication(UserApplication application)
        {
            DepartmentRepository departmentRepository = new DepartmentRepository();
            CollegeDepartment collegeDepartment = departmentRepository.CheckExistsDepartment(application.DeptID, application.CollegeCode);
            if(collegeDepartment.AvailableSeats > 0)
            {
                collegeDepartment.AvailableSeats = collegeDepartment.AvailableSeats - 1;
                departmentRepository.EditDepartment(collegeDepartment);
                applicationRepository.AddApplication(application);
                return true;
            }
            return false;
        }
        public IEnumerable<UserApplication> GetApplicationsByCollege(string collegeCode,string status)
        {
            return applicationRepository.GetApplicationsByCollege(collegeCode,status);
        }

        public UserApplication GetApplication(int applicationNumber)
        {
            return applicationRepository.GetApplication(applicationNumber);
        }
        public void UpdateApplication(int applicationNumber, string status)
        {
            UserApplication application = applicationRepository.GetApplication(applicationNumber);
            application.Status = status;
            applicationRepository.UpdateApplication(application);
        }
        public IEnumerable<UserApplication> GetApplicationByUser(string mailId)
        {
            IUserBL userBL = new UserBL();
            User user = userBL.GetUser(mailId);
            return applicationRepository.GetApplicationsByUser(user);
        }
    }
}
