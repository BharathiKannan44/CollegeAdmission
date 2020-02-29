using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeAdmission.Entity
{
    public class Department
    {
        [Key]
        [Required(ErrorMessage = "please select Department")]
        public int DeptId { get; set; }

        [DisplayName("Department Name")]
        [Required(ErrorMessage = "Please enter Department Name")]
        public string DeptName { get; set; } 

        public List<College> Colleges { get; set; }
    }
}
