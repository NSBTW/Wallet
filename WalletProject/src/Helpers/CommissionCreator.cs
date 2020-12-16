using System;
using Wallet.Models.Commissions;

namespace Wallet.Helpers
{
    public static class CommissionCreator
    {
        public static AbsoluteCommission CreateAbsoluteCommission(double value) =>
            new AbsoluteCommission(Guid.NewGuid().ToString(), value, 0);

        public static RelativeCommission CreateRelativeCommission(double rate) =>
            new RelativeCommission(Guid.NewGuid().ToString(), rate, 0, 0, 0);
    }
}