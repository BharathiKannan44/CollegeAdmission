using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeAdmission.Entity
{
    public class CollegeDepartment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int DeptId { get; set; }
        public Department Department { get; set; }

        public string CollegeCode { get; set; }
        public College College { get; set; }

        public int AvailableSeats { get; set; }       

        public CollegeDepartment()
        {

        }
    }
}
