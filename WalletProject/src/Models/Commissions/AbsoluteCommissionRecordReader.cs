using Wallet.Database.Models.Commissions;

namespace Wallet.Models.Commissions
{
    public class AbsoluteCommissionRecordReader : ICommissionRecordReader<AbsoluteCommission>
    {
        public CommissionType CommissionType => CommissionType.Absolute;

        public AbsoluteCommission ReadFromRecord(CommissionRecord record) =>
            new AbsoluteCommission(record.Id,record.Value, record.MaxValue);
    }
}