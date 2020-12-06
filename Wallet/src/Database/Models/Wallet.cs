namespace Wallet
{
    public class Wallet
    {
        public int WalletId { get; set; }
        public Account Account { get; set; }
        
        public Currency Currency { get; set; }
        public double Value { get; set; }
    }
}