using System;

namespace Wallet
{
    public class CommissionsStack
    {
        public string Id { get; set; }

        public Commission TransferCommission { get; set; }
        public Commission InCommission { get; set; }
        public Commission OutCommission { get; set; }

        public CommissionsStack()
        {
        }

        public CommissionsStack(Commission commission)
        {
            TransferCommission = commission.Clone();
            InCommission = commission.Clone();
            OutCommission = commission.Clone();
        }
    }
}