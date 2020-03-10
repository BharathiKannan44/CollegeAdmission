using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeAdmission.Entity
{
    public class College
    {
        [Key]
        public string CollegeCode { get; set; }

        public string CollegeName { get; set; }

        public string CollegeWebsite { get; set; }
        public ICollection<CollegeDepartment> CollegeDepartments{ get; set; }
        public ICollection<Department> Departments { get; set; }
        public College()
        {
        }

    }
}
