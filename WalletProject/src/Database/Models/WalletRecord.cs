namespace Wallet.Database.Models
{
    public class WalletRecord
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public int AccountId { get; set; }
        public int CurrencyId { get; set; }

        public CurrencyRecord Currency { get; set; }
        public AccountRecord Account { get; set; }
    }
}