using System.ComponentModel.DataAnnotations;

namespace Wallet.ViewModels
{
    public class OperationDto
    {
        [Required] public string AccountName { get; set; }
        [Required] public string CurrencyName { get; set; }
        [Required] public double Value { get; set; }
    }
}