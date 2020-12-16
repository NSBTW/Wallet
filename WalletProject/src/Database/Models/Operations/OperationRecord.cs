using System;
using Wallet.Database.Models.Commissions;

namespace Wallet.Database.Models.Operations
{
    public class OperationRecord
    {
        public string Id { get; set; }
        public OperationType Type { get; set; }
        public double Value { get; set; }
        public double Commission { get; set; }
        public string WalletId { get; set; }
        public string TargetWalletId { get; set; }
        
        public WalletRecord Wallet { get; set; }
        public WalletRecord TargetWallet { get; set; }
    }
}