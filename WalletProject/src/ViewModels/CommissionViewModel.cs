using Wallet.Database.Models.Commissions;
using Wallet.Database.Models.Operations;

namespace Wallet.ViewModels
{
    public class CommissionViewModel
    {
        public CommissionType Type { get; set; }
        public OperationType OperationType { get; set; }
        public double Value { get; set; }
        public double Rate { get; set; }
        public double MaximalValue { get; set; }
        public double MinimalValue { get; set; }
        
    }
}