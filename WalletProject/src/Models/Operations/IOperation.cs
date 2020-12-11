using System.Threading.Tasks;
using Wallet.Database;

namespace Wallet.Models.Operations
{
    public interface IOperation
    {
        public Task<bool> TryDoOperation(WalletDbContext context);
    }
}