using CollegeAdmission.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CollegeAdmission.ViewModel
{
    public enum Status
    {
        Inprogress, Accepted, Rejected, WaitingList,
    }
    public class UserApplicationModel
    {
        public int ApplicationNumber { get; set; }
        public int UserId { get; set; }
        public User user { get; set; }
        public string CollegeCode { get; set; }
        public College college { get; set; }
        public int DeptId { get; set; }
        public Department department { get; set; }

        [DisplayName("City")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "NameRequired")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "InvalidName")]
        [MaxLength(40)]
        public string City { get; set; }

        [DisplayName("10th Mark")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "TenthMarkRequired")]
        [Range(200, 500, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MarkRange")]
        public double TenthMark { get; set; }

        [DisplayName("12th Mark")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "TwelthMarkRequired")]
        [Range(300, 600, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MarkRange")]
        public double TwelthMark { get; set; }

        public string Status { get; set; }
    }
}