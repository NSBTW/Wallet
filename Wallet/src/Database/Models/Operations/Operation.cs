namespace Wallet.Database.Models.Operations
{
    public abstract class Operation
    {
        public string Id { get; set; }
        public Wallet Wallet { get; set; }
        public double Value { get; set; }

        public abstract  bool TryDoOperation();
    }
}