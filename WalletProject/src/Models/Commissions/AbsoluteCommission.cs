using Wallet.Database.Models.Commissions;

namespace Wallet.Models.Commissions
{
    public class AbsoluteCommission : ICommission, IRecordableCommission
    {
        private readonly string _id;
        private readonly double _value;

        public AbsoluteCommission(string id, double value)
        {
            _id = id;
            _value = value;
        }

        public double Calculate(double value) => _value;

        public CommissionRecord ToRecord() => 
            new CommissionRecord {Type = CommissionType.Absolute, Value = _value, Id = _id};
    }
}