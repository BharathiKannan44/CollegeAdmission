using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CollegeAdmission.Entity
{
    //
    //Summary:
    //  Entity class(College) 
    public class College
    {
        [Key]
        [MaxLength(8)]
        public string CollegeCode { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(100)]
        public string CollegeName { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(50)]
        public string CollegeWebsite { get; set; }

        public ICollection<CollegeDepartment> CollegeDepartments{ get; set; }
        public College()
        {
        }

    }
}
