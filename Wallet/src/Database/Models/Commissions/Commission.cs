using Microsoft.EntityFrameworkCore;

namespace Wallet
{
    public abstract class Commission : ICommission
    {
        public int CommissionId { get; set; }
        
        public Currency Currency { get; set; }
        public abstract double CalculateCommission(double value);
    }
}