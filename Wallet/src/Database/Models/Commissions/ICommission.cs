namespace Wallet.Database.Models.Commissions
{
    public interface ICommission
    {
        public double CalculateCommission(double value);
    }
}