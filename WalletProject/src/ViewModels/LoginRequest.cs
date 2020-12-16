using System.ComponentModel.DataAnnotations;

namespace Wallet.ViewModels
{
    public class LoginRequest
    {
        [Required] 
        [Display(Name = "Email")] 
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember Me?")] 
        public bool RememberMe { get; set; }
    }
}