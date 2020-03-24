using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CollegeAdmission.ViewModel
{
    //
    //Summary:
    //  This class is used for Login model
    public class LoginViewModel
    {
        [DisplayName("Email Id")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "EmailRequired")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(40)]
        public string EmailId { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "PasswordRequired")]
        [StringLength(20, MinimumLength = 8, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "PasswordLength")]
        public string Password { get; set; }

    }
}