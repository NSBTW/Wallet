using System.ComponentModel.DataAnnotations;

namespace Wallet.ViewModels
{
    public class EditAccountRequest
    {
        [Required] public string UserName { get; set; }
        [Required] public string AccountName { get; set; }
        [Required] public string CurrencyName { get; set; }
        [Required] public double Value { get; set; }
    }
}