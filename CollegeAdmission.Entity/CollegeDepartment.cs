using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeAdmission.Entity
{//
    //Summary:
    //  Intermediate class for College and Department
    public class CollegeDepartment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int DeptId { get; set; }
        public Department Department { get; set; }

        [Required]
        public string CollegeCode { get; set; }
        public College College { get; set; }

        [Required]
        [Range(0,1000,ErrorMessage ="")]
        public int AvailableSeats { get; set; }       
    
        public CollegeDepartment()
        {

        }
    }
}
