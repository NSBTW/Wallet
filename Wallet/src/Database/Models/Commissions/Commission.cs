using Microsoft.EntityFrameworkCore;

namespace Wallet
{
    public abstract class Commission : ICommission
    {
        public int CommissionId { get; set; }
        
        public abstract double CalculateCommission(double value);
    }
}