using System;
using Wallet.Database.Models.Commissions;

namespace Wallet.Database.Models.Operations
{
    public class OperationRecord
    {
        public int Id { get; set; }
        public OperationType Type { get; set; }
        public double Value { get; set; }
        public double Commission { get; set; }
        public int WalletId { get; set; }
        public int? TransferWalletId { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public WalletRecord Wallet { get; set; }
        public WalletRecord TransferWallet { get; set; }
    }
}