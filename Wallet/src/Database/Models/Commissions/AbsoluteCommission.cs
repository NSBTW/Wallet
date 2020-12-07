using System;

namespace Wallet.Database.Models.Commissions
{
    public class AbsoluteCommission : Commission
    {
        public double Commission { get; set; }

        public AbsoluteCommission(double commission)
        {
            Commission = commission;
        }

        public override double CalculateCommission(double value) => Commission;
        public override Commission Clone() => new AbsoluteCommission(Commission) {Id = Guid.NewGuid().ToString()};
    }
}