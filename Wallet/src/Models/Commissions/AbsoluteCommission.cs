using Wallet.Database.Models.Commissions;

namespace Wallet.Models.Commissions
{
    public class AbsoluteCommission : ICommission, IRecordableCommission
    {
        private readonly double _value;

        public AbsoluteCommission(double value)
        {
            _value = value;
        }

        public double Calculate(double value) => value;

        public CommissionRecord ToRecord() => 
            new CommissionRecord {Type = CommissionType.Absolute, Value = _value};
    }
}