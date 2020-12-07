namespace Wallet.Database.Models.Commissions
{
    //need refactor. Dictionary<enum, Comission> ? 
    public class CommissionsStack
    {
        public string Id { get; set; }

        public Commission TransferCommission { get; set; }
        public Commission DepositCommission { get; set; }
        public Commission OutCommission { get; set; }

        public CommissionsStack()
        {
        }

        public CommissionsStack(Commission commission)
        {
            TransferCommission = commission.Clone();
            DepositCommission = commission.Clone();
            OutCommission = commission.Clone();
        }
    }
}