using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CollegeAdmission.ViewModel
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }

        [DisplayName("Department")]
        [Required(ErrorMessage = "please Select Department")]
        public string DeptId { get; set; }

        [DisplayName("College")]
        public string CollegeCode { get; set; }

        [DisplayName("Available seats")]
        [Required(ErrorMessage = "Please Enter Available Saets")]
        [Range(10,500,ErrorMessage ="Seats should between 10 to 500")]
        public int AvailableSeats { get; set; }

        public DepartmentViewModel()
        {

        }
    }
}