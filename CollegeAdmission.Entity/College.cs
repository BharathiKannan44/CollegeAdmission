using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeAdmission.Entity
{
    public class College
    {
        [DisplayName("College Code")]
        [Required(ErrorMessage = "College code is required")]
        [Key]
        public string CollegeCode { get; set; }

        [DisplayName("College Name")]
        [Required(ErrorMessage = "College Name is required")]
        public string CollegeName { get; set; }

        [DisplayName("College Website")]
        [Required(ErrorMessage = "College Website is required")]
        public string CollegeWebsite { get; set; }
        
        public List<CollegeDepartment> CollegeDepartments { get; set; }

    }
}
