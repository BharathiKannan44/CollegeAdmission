using CollegeAdmission.Entity;
using System.Data.Entity;

namespace CollegeAdmission.DAL
{ 
    public class CollegeDBContext : DbContext
    {
        public CollegeDBContext() : base("Online_College_Admission")
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<College> Colleges { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<CollegeDepartment> CollegeDepartments { get; set; }
        public DbSet<UserApplication> UserApplications { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<College>().MapToStoredProcedures();
            modelBuilder.Entity<CollegeDepartment>().MapToStoredProcedures();
        }
    }
}
