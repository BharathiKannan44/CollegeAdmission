using CollegeAdmission.Entity;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CollegeAdmission.ViewModel
{
    public class CollegeViewModel
    {
        [DisplayName("College Code")]
        [Required(ErrorMessage = "College code is Required")]
        [StringLength(25, MinimumLength = 8, ErrorMessage = "code length between 8 to 25")]
        public string CollegeCode { get; set; }

        [DisplayName("College Name")]
        [Required(ErrorMessage = "College Name is Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Invalid Name")]
        public string CollegeName { get; set; }

        [DisplayName("College Website")]
        [Required(ErrorMessage = "College Website is required")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "please enter valid website")]
        public string CollegeWebsite { get; set; }
        public ICollection<CollegeDepartment> CollegeDepartments { get; set; }

        public CollegeViewModel()
        {

        }
    }
}