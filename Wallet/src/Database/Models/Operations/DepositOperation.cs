namespace Wallet.Database.Models.Operations
{
    public class DepositOperation: Operation
    {
        public override bool TryDoOperation() => Wallet.TryPut(Value);
    }
}