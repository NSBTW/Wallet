using System.ComponentModel.DataAnnotations;

namespace Wallet.ViewModels
{
    public class LoginRequest
    {
        [Required] [Display(Name = "Login")] public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember Me?")] public bool RememberMe { get; set; }
    }
}