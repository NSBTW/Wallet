namespace Wallet.Database.Models.Operations
{
    public class TransferOperation : Operation
    {
        public Wallet TargetWallet { get; set; }
        public override bool TryDoOperation() => Wallet.TryTransferTo(TargetWallet, Value);
    }
}