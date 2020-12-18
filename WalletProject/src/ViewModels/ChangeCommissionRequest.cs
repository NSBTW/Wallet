using System.ComponentModel.DataAnnotations;
using Wallet.Database.Models.Operations;

namespace Wallet.ViewModels
{
    public class ChangeCommissionRequest
    {
        [Required] public CommissionDto CommissionDto { get; set; }
        [Required] public OperationType Type { get; set; }
        [Required] public string CurrencyName { get; set; }
        public string UserName { get; set; }
    }
}