using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TARS_Delivery_System.Models
{
    public class newRegister
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
