using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wallet.Database;
using Wallet.Models.Commissions;

namespace Wallet.Models.Operations
{
    public class DepositOperation : IOperation
    {
        private readonly string _walletId;
        private readonly double _commission;
        private readonly double _value;

        public DepositOperation(double value, double commission, string walletId)
        {
            _value = value;
            _commission = commission;
            _walletId = walletId;
        }

        public async Task<bool> TryDoOperation(WalletDbContext context)
        {
            var wallet = await context.Wallets
                .FirstOrDefaultAsync(w => w.Id == _walletId);

            wallet.Value += _value - _commission;
            return true;
        }
    }
}