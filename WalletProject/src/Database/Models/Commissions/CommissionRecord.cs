using Wallet.Database.Models.Operations;

namespace Wallet.Database.Models.Commissions
{
    public class CommissionRecord
    {
        public string Id { get; set; }
        public CurrencyRecord CurrencyRecord { get; set; }
        public string CurrencyRecordId { get; set; }
        public UserRecord UserRecord { get; set; }
        public string UserRecordId { get; set; }
        
        public bool IsUserCommission { get; set; }
        public CommissionType Type { get; set; }
        public OperationType OperationType { get; set; }
        
        public double Value { get; set; }
        public double Rate { get; set; }
        public double MaxValue { get; set; }
        public double MinValue { get; set; }
        
        
    }
}