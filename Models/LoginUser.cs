using System.ComponentModel.DataAnnotations;

namespace BlackcofferAssigment.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Please Enter Your Username !")]
        [Display(Name = "Email : ")]
        public string Uemail { get; set; }
        [Required(ErrorMessage = "Please Enter Your Username !")]
        [Display(Name = "Password: ")]
        [DataType(DataType.Password)]
        public string Pwd { get; set; }
        public bool KeepLoggedIn { get; set; }

    }
}
