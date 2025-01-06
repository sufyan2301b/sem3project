using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TARS_Delivery_System.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        public String Username { get; set; }

        [Required]
        [EmailAddress]
        public String Email { get; set; }

        [Required]
        [DataType(DataType.Password)]   
        public String Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("ConfirmPassword")]
        [Compare("Password", ErrorMessage = "Your Password and Confirm Password doesn't match")]
        public String ConfirmPassword { get; set; }
    }
}
