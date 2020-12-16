using Wallet.Database.Models.Commissions;

namespace Wallet.Models.Commissions
{
    public class RelativeCommission : ICommission, IRecordableCommission
    {
        private readonly double _minimum;
        private readonly double _maximum;
        private readonly string _id;
        private readonly double _rate;
        public double MaxOperationValue { get; }


        public RelativeCommission(string id, double rate, double maxValue)
        {
            _id = id;
            _rate = rate;
            MaxOperationValue = maxValue;
        }

        public RelativeCommission(string id, double rate, double minimum, double maximum, double maxValue) : this(id,
            rate, maxValue)
        {
            _maximum = maximum;
            _minimum = minimum;
        }

        public double Calculate(double value)
        {
            var commission = value * _rate;
            if (commission < _minimum)
                commission = _minimum;
            if (commission > _maximum)
                commission = _maximum;
            return commission;
        }

        public CommissionRecord ToRecord() =>
            new CommissionRecord
            {
                Type = CommissionType.Relative, Rate = _rate, MaxCommission = _maximum, MinCommission = _minimum,
                Id = _id, MaxValue = MaxOperationValue
            };
    }
}