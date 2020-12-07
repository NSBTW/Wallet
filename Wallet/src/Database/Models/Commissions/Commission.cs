namespace Wallet.Database.Models.Commissions
{
    public abstract class Commission : ICommission
    {
        public string Id { get; set; }
        
        public abstract double CalculateCommission(double value);
        public abstract Commission Clone();
    }
}