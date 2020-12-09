using Wallet.Database.Models.Commissions;

namespace Wallet.Models.Commissions
{
    public class RelativeCommission : ICommission, IRecordableCommission
    {
        private readonly double _minimum;
        private readonly double _maximum;
        private readonly double _rate;

        public RelativeCommission(double rate)
        {
            _rate = rate;
        }

        public RelativeCommission(double rate, double minimum, double maximum)
        {
            _rate = rate;
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
                {Type = CommissionType.Relative, Rate = _rate, MaxValue = _maximum, MinValue = _maximum};
    }
}