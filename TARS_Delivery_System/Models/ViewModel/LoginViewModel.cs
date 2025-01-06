using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TARS_Delivery_System.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public String Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        [DisplayName("Remember Me")]
        public bool RememberMe { get; set; }
     }
}
