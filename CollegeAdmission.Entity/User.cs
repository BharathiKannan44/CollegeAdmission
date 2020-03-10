using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeAdmission.Entity
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required(ErrorMessage = "please enter Your Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "please enter Your LastName")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "please Select Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "please enter Your DOB")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [Required(ErrorMessage = "please enter Your Email Id")]
        public string EmailId { get; set; }

        public long PhoneNumber { get; set; }

        [Required(ErrorMessage = "please enter Password")]
        public string Password { get; set; }

        public string Role { get; set; }
        public User()
        {

        }
    }
}
