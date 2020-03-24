using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CollegeAdmission.Entity
{
    //
    //Summary:
    //  Entity class for College
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeptId { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(25)]
        public string DeptName { get; set; } 

        public ICollection<CollegeDepartment> CollegeDepartments { get; set; }

        public Department()
        {

        }
    }
}
