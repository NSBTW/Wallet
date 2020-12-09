using Wallet.Database.Models.Commissions;

namespace Wallet.Models.Commissions
{
    public interface IRecordableCommission
    {
        public CommissionRecord ToRecord();
    }
}