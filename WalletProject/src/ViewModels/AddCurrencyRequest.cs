using System.ComponentModel.DataAnnotations;

namespace Wallet.ViewModels
{
    public class AddCurrencyRequest
    {
        [Required] public CommissionDto CommissionDto { get; set; }
        [Required] public string Name { get; set; }
    }
}