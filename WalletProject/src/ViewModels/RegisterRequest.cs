using System.ComponentModel.DataAnnotations;

namespace Wallet.ViewModels
{
    public class RegisterRequest
    {
        [Required] [Display(Name = "Login")] public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm")]
        public string PasswordConfirm { get; set; }
    }
}