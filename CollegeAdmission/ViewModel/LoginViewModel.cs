using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CollegeAdmission.ViewModel
{
    public class LoginViewModel
    {
        [DisplayName("Email Id")]
        [Required(ErrorMessage = "please enter Your Email Id")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(40)]
        public string EmailId { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "please enter Password")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password should atleast contain 8 characters")]
        public string Password { get; set; }

    }
}