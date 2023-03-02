using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BlackcofferAssigment.Models
{
    public class UserRegistration
    {
        [Key]
        public int Userid { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please Enter User Name")]
        public string Username { get; set; }


        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please Enter Email")]
        public string Uemail { get; set; }


        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string Pwd { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Please Enter Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Pwd")]
        public string ConfirmPwd { get; set; }

        [Display(Name = "Martial Status")]
        [Required(ErrorMessage = "Please Select Martial Status")]
        public string MartialStatus { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please Select Gender")]
        public char Gender { get; set; }

    }
}
