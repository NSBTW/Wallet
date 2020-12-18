namespace Wallet.Models
{
    public class Wallet
    {
        private int Id { get; }
        public double Value { get; }

        public string CurrencyName { get; }

        public Wallet(int id, double value, string currencyName)
        {
            Id = id;
            Value = value;
            CurrencyName = currencyName;
        }
    }
}