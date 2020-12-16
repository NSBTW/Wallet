using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wallet.Database;

namespace Wallet.Models.Operations
{
    public class WithdrawOperation : IOperation

    {
        private readonly string _walletId;
        private readonly double _commission;
        private readonly double _value;

        public WithdrawOperation(double value, double commission, string walletId)
        {
            _value = value;
            _commission = commission;
            _walletId = walletId;
        }

        public async Task<bool> TryDoOperation(WalletContext context)
        {
            var wallet = await context.Wallets
                .FirstOrDefaultAsync(w => w.Id == _walletId);

            if (wallet.Value < _value + _commission)
                return false;
            wallet.Value -= _value + _commission;
            return true;
        }
    }
}