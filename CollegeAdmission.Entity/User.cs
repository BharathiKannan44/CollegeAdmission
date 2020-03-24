using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeAdmission.Entity
{
    //
    //Summary:
    //  Entity class for User 
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [MaxLength(40)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(40)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(6)]
        public string Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [Index(IsUnique = true)]
        public string EmailId { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public long PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(20)]
        public string Password { get; set; }

        [Required]
        [MaxLength(5)]
        public string Role { get; set; }
        public User()
        {

        }
    }
}
