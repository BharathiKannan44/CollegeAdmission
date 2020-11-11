using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CollegeAdmission.Entity
{
    public class UserApplication
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicationNumber { get; set; }

        [Required]
        public int UserId { get; set; }
        public User user{get;set;}

        [Required]
        public string CollegeCode { get; set; }
        public College college { get; set; }

        [Required]
        public int DeptID { get; set; }
        public  Department department { get; set; }

        [Required]
        [MaxLength(25)]
        public string City { get; set; }

        [Required]
        public double TenthMark {get; set;}

        [Required]
        public double TwelthMark { get; set; }

        [Required]
        [MaxLength(10)]
        public string Status { get; set; }
    }
}
