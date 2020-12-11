using System;
using Wallet.Database.Models.Commissions;

namespace Wallet.Models.Commissions
{
    public interface ICommissionRecordReader<out TCommission> where TCommission : ICommission
    {
        public CommissionType CommissionType { get; }
        public TCommission ReadFromRecord(CommissionRecord record);
    }
}