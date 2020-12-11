using Wallet.Database.Models.Commissions;

namespace Wallet.Models.Commissions
{
    public class RelativeCommissionRecordReader : ICommissionRecordReader<RelativeCommission>
    {
        public CommissionType CommissionType => CommissionType.Relative;

        public RelativeCommission ReadFromRecord(CommissionRecord record) =>
            new RelativeCommission(record.Id,record.Rate, record.MinValue, record.MaxValue);
    }
}