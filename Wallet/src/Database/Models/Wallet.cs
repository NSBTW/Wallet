namespace Wallet
{
    public class Wallet
    {
        public string Id { get; set; }
        public Account Account { get; set; }
        
        public Currency Currency { get; set; }
        public double Value { get; set; }
    }
}