using Wallet.Database.Models.Commissions;

namespace Wallet.Database.Models.Operations
{
    public class OperationRecord
    {
        public string Id { get; set; }
        public WalletRecord WalletRecord { get; set; }
        public string WalletRecordId { get; set; }
        public WalletRecord TargetWalletRecord { get; set; }
        public string TargetWalletRecordId { get; set; }

        public OperationType Type { get; set; }

        public double Value { get; set; }
        public double Commission { get; set; }
    }
}