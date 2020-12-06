using Microsoft.EntityFrameworkCore;

namespace Wallet
{
    public class AbsoluteCommission:Commission
    {
        public double Commission { get; set; }

        public AbsoluteCommission(double commission)
        {
            Commission = commission;
        }

        public override double CalculateCommission(double value) => Commission;
    }
}