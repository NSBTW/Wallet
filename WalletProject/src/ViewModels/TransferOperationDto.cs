using System.ComponentModel.DataAnnotations;

namespace Wallet.ViewModels
{
    public class TransferOperationDto : OperationDto
    {
        [Required] public string UserName { get; set; }
        [Required] public string ToAccountName { get; set; }
    }
}