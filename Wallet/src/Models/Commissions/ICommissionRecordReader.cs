using System;
using Wallet.Database.Models.Commissions;

namespace Wallet.Models.Commissions
{
    public interface ICommissionRecordReader
    {
        public CommissionType CommissionType { get; }
        public ICommission TryReadFromRecord(CommissionRecord record);
    }
}