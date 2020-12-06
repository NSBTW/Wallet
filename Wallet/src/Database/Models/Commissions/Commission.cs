using Microsoft.EntityFrameworkCore;

namespace Wallet
{
    public abstract class Commission : ICommission
    {
        public string Id { get; set; }
        
        public abstract double CalculateCommission(double value);
    }
}