namespace Wallet.Models.Commissions
{
    public interface ICommission
    {
        public double Calculate(double value);
        public double MaxOperationValue { get; }
    }
}