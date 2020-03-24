using CollegeAdmission.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CollegeAdmission.ViewModel
{
    //
    //Summary:
    //  model class for department 
    public class DepartmentViewModel
    {
        public int ID { get; set; }

        [DisplayName("Department")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "SelectDepartment")]
        public string DeptId { get; set; }
        public Department department { get; set; }

        [DisplayName("College")]
        public string CollegeCode { get; set; }

        [DisplayName("Available seats")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "SeatsRequired")]
        [Range(10,500, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "SeatsRange")]
        public int AvailableSeats { get; set; }

        public DepartmentViewModel()
        {

        }
    }
}