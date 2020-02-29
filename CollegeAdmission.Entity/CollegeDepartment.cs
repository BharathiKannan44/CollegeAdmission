using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeAdmission.Entity
{
    public class CollegeDepartment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("Department")]
        public int DeptId { get; set; }
        public Department Department { get; set; }

        [ForeignKey("College")]
        public string CollegeCode { get; set; }
        public College College { get; set; }
        
        [Required(ErrorMessage = "Please Enter Fees")]
        public double AdvanceFee { get; set; }

        
    }
}
