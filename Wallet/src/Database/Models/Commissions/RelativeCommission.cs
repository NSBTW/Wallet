using System;

namespace Wallet.Database.Models.Commissions
{
    public class RelativeCommission : Commission
    {
        public double Rate { get; set; }
        public double MinimalCommission { get; set; }
        public double MaximalCommission { get; set; }

        public RelativeCommission(double rate, double minimalCommission, double maximalCommission)
        {
            Rate = rate;
            MinimalCommission = minimalCommission;
            MaximalCommission = maximalCommission;
        }

        public override double CalculateCommission(double value)
        {
            var commission = value * Rate;
            if (commission < MinimalCommission)
                return MinimalCommission;
            return commission > MaximalCommission ? MaximalCommission : commission;
        }

        public override Commission Clone() => new RelativeCommission(Rate, MinimalCommission, MaximalCommission)
            {Id = Guid.NewGuid().ToString()};
    }
}