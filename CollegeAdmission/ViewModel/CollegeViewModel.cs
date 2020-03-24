using CollegeAdmission.Entity;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CollegeAdmission.ViewModel
{
    //
    //Summary:
    //  model class for College
    public class CollegeViewModel
    {
        [DisplayName("College Code")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName ="CodeRequired")]
        [StringLength(8, MinimumLength = 8, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "InvalidCode")]
        public string CollegeCode { get; set; }

        [DisplayName("College Name")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "CollegeNameRequired")]
        [StringLength(100, MinimumLength = 3, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "InvalidCollegeName")]
        public string CollegeName { get; set; }

        [DisplayName("College Website")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "WebsiteRequired")]
        [StringLength(50, MinimumLength = 5, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "InvalidWebsite")]
        public string CollegeWebsite { get; set; }
        public ICollection<CollegeDepartment> CollegeDepartments { get; set; }

        public CollegeViewModel()
        {

        }
    }
}