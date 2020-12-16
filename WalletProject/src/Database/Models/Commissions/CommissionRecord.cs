using Wallet.Database.Models.Operations;

namespace Wallet.Database.Models.Commissions
{
    public class CommissionRecord
    {
        public string Id { get; set; }
        public CommissionType Type { get; set; }
        public OperationType OperationType { get; set; }
        public double Value { get; set; }
        public double Rate { get; set; }
        public double MaxCommission { get; set; }
        public double MinCommission { get; set; }
        public double MaxValue { get; set; }
        public string UserId { get; set; }
        public string CurrencyId { get; set; }

        public CurrencyRecord Currency { get; set; }
        public UserRecord User { get; set; }
    }
}