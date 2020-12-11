using Wallet.Database.Models.Commissions;

namespace Wallet.Models.Commissions
{
    public class RelativeCommission : ICommission, IRecordableCommission
    {
        private readonly double _minimum;
        private readonly double _maximum;
        private readonly string _id;
        private readonly double _rate;

        public RelativeCommission(string id,double rate)
        {
            _id = id;
            _rate = rate;
        }

        public RelativeCommission(string id, double rate, double minimum, double maximum) : this(id, rate)
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
                {Type = CommissionType.Relative, Rate = _rate, MaxValue = _maximum, MinValue = _minimum, Id = _id};
    }
}