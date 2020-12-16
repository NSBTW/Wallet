using Wallet.Database.Models.Commissions;

namespace Wallet.Models.Commissions
{
    public class AbsoluteCommission : ICommission, IRecordableCommission
    {
        private readonly string _id;
        private readonly double _value;
        public double MaxOperationValue { get; }


        public AbsoluteCommission(string id, double value, double maxValue)
        {
            _id = id;
            _value = value;
            MaxOperationValue = maxValue;
        }

        public double Calculate(double value) => _value;

        public CommissionRecord ToRecord() =>
            new CommissionRecord {Type = CommissionType.Absolute, Value = _value, Id = _id, MaxValue = MaxOperationValue};
    }
}