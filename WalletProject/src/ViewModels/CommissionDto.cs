using System.ComponentModel.DataAnnotations;
using Wallet.Database.Models.Commissions;
using Wallet.Database.Models.Operations;

namespace Wallet.ViewModels
{
    public class CommissionDto
    {
        [Required]
        public CommissionType Type { get; set; }
        public double Value { get; set; }
        public double Rate { get; set; }
        public double MaximalCommission { get; set; }
        public double MinimalCommission { get; set; }
        
        public double MaxOperationValue { get; set; }
    }
}