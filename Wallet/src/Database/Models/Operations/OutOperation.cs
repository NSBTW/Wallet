namespace Wallet.Database.Models.Operations
{
    public class OutOperation: Operation
    {
        public override bool TryDoOperation() => Wallet.TryGet(Value);
    }
}