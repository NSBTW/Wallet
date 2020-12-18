using System.ComponentModel.DataAnnotations;

namespace Wallet.ViewModels
{
    public class TransferOperationRequest : OperationRequest
    {
        [Required] public string UserName { get; set; }
        [Required] public string ToAccountName { get; set; }
    }
}