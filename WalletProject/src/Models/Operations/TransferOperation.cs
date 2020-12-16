using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wallet.Database;

namespace Wallet.Models.Operations
{
    public class TransferOperation : IOperation
    {
        private readonly string _walletId;
        private readonly string _targetWalletId;
        private readonly double _commission;
        private readonly double _value;

        public TransferOperation(double value, double commission, string walletId, string targetWalletId)
        {
            _value = value;
            _commission = commission;
            _walletId = walletId;
            _targetWalletId = targetWalletId;
        }

        public async Task<bool> TryDoOperationAsync(WalletContext context)
        {
            var wallet = await context.Wallets
                .FirstOrDefaultAsync(w => w.Id == _walletId);
            var targetWallet = await context.Wallets
                .FirstOrDefaultAsync(w => w.Id == _targetWalletId);
            if(wallet.Value < _commission + _value)
                return false;

            wallet.Value -= _commission + _value;
            targetWallet.Value += _value;
            return true;
        }
    }
}