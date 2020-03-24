using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace CollegeAdmission.ViewModel
{
    public enum Role
    {
        User, Admin //Role for User
    }

    //
    //Summary:
    //  This is the model class for User
    public class UserViewModel
    {
        public int UserId { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "NameRequired")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "InvalidName")]
        [MaxLength(40)]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "NameRequired")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "InvalidName")]
        [MaxLength(40)]
        public string LastName { get; set; }

        [DisplayName("Gender")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "GenderRequired")]
        public string Gender { get; set; }

        [DisplayName("Date Of Birth")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "DOBRequired")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [DisplayName("Email Id")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "EmailRequired")]
        [EmailAddress(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "InvalidEmail")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        public string EmailId { get; set; }

        [DisplayName("Mobile Number")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "PhoneNumberRequired")]
        [RegularExpression(@"^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}", ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "InvalidPhoneNumber")]
        [DataType(DataType.PhoneNumber)]
        public long PhoneNumber { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "PasswordRequired")]
        [RegularExpression("^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?!.*s).*$", ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "PasswordConstraint")]
        [StringLength(20, MinimumLength = 8, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "PasswordLength")]
        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [Compare("Password", ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "ReEnterPassword")]
        [Required(ErrorMessage = "please enter Password")]
        [RegularExpression("^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?!.*s).*$", ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "PasswordConstraint")]
        [StringLength(20, MinimumLength = 8, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "PasswordLength")]
        public string ConfirmPassword { get; set; }
        public UserViewModel()
        {

        }
    }
}