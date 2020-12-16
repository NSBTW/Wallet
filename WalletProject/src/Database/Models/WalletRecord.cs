namespace Wallet.Database.Models
{
    public class WalletRecord
    {
        public string Id { get; set; }
        public double Value { get; set; }
        public string AccountId { get; set; }
        public string CurrencyId { get; set; }

        public CurrencyRecord Currency { get; set; }
        public AccountRecord Account { get; set; }
    }
}