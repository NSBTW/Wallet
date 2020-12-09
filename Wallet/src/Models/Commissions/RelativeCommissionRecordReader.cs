using Wallet.Database.Models.Commissions;

namespace Wallet.Models.Commissions
{
    public class RelativeCommissionRecordReader : ICommissionRecordReader
    {
        public CommissionType CommissionType => CommissionType.Relative;

        public ICommission TryReadFromRecord(CommissionRecord record) =>
            new RelativeCommission(record.Rate, record.MinValue, record.MaxValue);
    }
}