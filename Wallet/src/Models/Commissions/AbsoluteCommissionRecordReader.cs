using Wallet.Database.Models.Commissions;

namespace Wallet.Models.Commissions
{
    public class AbsoluteCommissionRecordReader : ICommissionRecordReader
    {
        public CommissionType CommissionType => CommissionType.Absolute;

        public ICommission TryReadFromRecord(CommissionRecord record) =>
            new AbsoluteCommission(record.Value);
    }
}