using CollegeAdmission.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace CollegeAdmission.DAL
{
    //
    //Summary:
    // Interface for connect User interface and database
    public interface IDepartmentRepository
    {
        CollegeDepartment GetDepartment(int id);
        IEnumerable<CollegeDepartment> GetDepartmentByCollege(string collegeCode);
        void AddDepartmentByCollege(CollegeDepartment collegeDepartment);
        IEnumerable<Department> GetDepartmentList();
        void EditDepartment(CollegeDepartment collegeDepartment);
        void DeleteDepartment(int id);
        CollegeDepartment CheckExistsDepartment(int deptId, string collegeCode);
    }

    //
    //Summary:
    // This class provides method for Department CRUD opertions
    public class DepartmentRepository : IDepartmentRepository
    {
        CollegeDBContext collegeDBContext;
        //
        //Summary:
        //  create instance for DbContext
        public DepartmentRepository()
        {
            collegeDBContext = new CollegeDBContext();
        }
        //
        //Summary:
        //  This method is to get Department from database
        //Return:
        //  Returns Department object
        public CollegeDepartment GetDepartment(int id)
        {
            using (CollegeDBContext collegeDBContext = new CollegeDBContext())
            {
                return collegeDBContext.CollegeDepartments.Include("Department").Where(m => m.ID == id).FirstOrDefault();
            }
        }

        //
        //Summary:
        //  This method is to Department by using College code from database
        //Return:
        //  Returns List of CollegDepartment object
        public IEnumerable<CollegeDepartment> GetDepartmentByCollege(string collegeCode)
        {
            using (CollegeDBContext collegeDBContext = new CollegeDBContext())
            {
                return collegeDBContext.CollegeDepartments.Include("Department").Where(m => m.CollegeCode == collegeCode).ToList();
            }
        }
        //
        //Summary:
        //  This method is to Add Department to database
        public void AddDepartmentByCollege(CollegeDepartment collegeDepartment)
        {
            using (CollegeDBContext collegeDBContext = new CollegeDBContext())
            {
                SqlParameter DeptId = new SqlParameter("@DeptId", collegeDepartment.DeptId);
                SqlParameter collegeCode = new SqlParameter("@CollegeCode", collegeDepartment.CollegeCode);
                SqlParameter AvailableSeats = new SqlParameter("@AvailableSeats", collegeDepartment.AvailableSeats);
                collegeDBContext.Database.ExecuteSqlCommand("CollegeDepartment_Insert @DeptId, @CollegeCode, @AvailableSeats", DeptId, collegeCode, AvailableSeats);
                //collegeDBContext.CollegeDepartments.Add(collegeDepartment);
                //collegeDBContext.SaveChanges();
            }
        }

        //
        //Summary:
        //  This method is used to get All Departments in Database
        //Return:
        //  return List of Department
        public IEnumerable<Department> GetDepartmentList()
        {
            using (CollegeDBContext collegeDBContext = new CollegeDBContext())
            {
                return collegeDBContext.Departments.ToList();
            }
        }

        //
        //Summary:
        //  This method is to Update Department to database
        public void EditDepartment(CollegeDepartment collegeDepartment)
        {
            using (CollegeDBContext collegeDBContext = new CollegeDBContext())
            {
                SqlParameter Id = new SqlParameter("@ID", collegeDepartment.ID);
                SqlParameter DeptId = new SqlParameter("@DeptId", collegeDepartment.DeptId);
                SqlParameter collegeCode = new SqlParameter("@CollegeCode", collegeDepartment.CollegeCode);
                SqlParameter AvailableSeats = new SqlParameter("@AvailableSeats", collegeDepartment.AvailableSeats);
                collegeDBContext.Database.ExecuteSqlCommand("CollegeDepartment_Update @ID, @DeptId, @CollegeCode, @AvailableSeats", Id, DeptId, collegeCode, AvailableSeats);
                //collegeDBContext.Entry(collegeDepartment).State = EntityState.Modified;
                //collegeDBContext.SaveChanges();
            }
        }

        //
        //Summary:
        //  This method is to delete Department
        public void DeleteDepartment(int id)
        {
            using (CollegeDBContext collegeDBContext = new CollegeDBContext())
            {
                SqlParameter Id = new SqlParameter("@ID",id);
                collegeDBContext.Database.ExecuteSqlCommand("CollegeDepartment_Delete @ID", Id);
                //collegeDBContext.CollegeDepartments.Remove(department);
                //collegeDBContext.SaveChanges();
            }
        }

        //
        //Summary:
        //  This method is used to Exists Department
        //Return:
        //  Returns CollegeDepartment
        public CollegeDepartment CheckExistsDepartment(int deptId, string collegeCode)
        {
            using(CollegeDBContext collegeDBContext = new CollegeDBContext())
            {
                return collegeDBContext.CollegeDepartments.Where(m => m.DeptId == deptId && m.CollegeCode == collegeCode).FirstOrDefault();
            }
        }
    }
}
