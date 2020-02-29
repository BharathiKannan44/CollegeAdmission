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
    }
}
