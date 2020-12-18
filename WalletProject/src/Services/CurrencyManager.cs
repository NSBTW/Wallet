using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wallet.Database;
using Wallet.Database.Models;
using Wallet.Database.Models.Operations;
using Wallet.ViewModels;

namespace Wallet.Services
{
    public class CurrencyManager
    {
        private readonly WalletContext _context;
        private readonly CommissionManager _commissionManager;

        public CurrencyManager(WalletContext context, CommissionManager commissionManager)
        {
            _context = context;
            _commissionManager = commissionManager;
        }

        public async Task CreateCurrency(string name, CommissionDto dto)
        {
            var currency = new CurrencyRecord {Name = name};
            await _context.Currencies.AddAsync(currency);
            await _context.SaveChangesAsync();

            var deposit = CommissionManager.CreateCommission(currency.Id, dto, OperationType.Deposit);
            var transfer = CommissionManager.CreateCommission(currency.Id, dto, OperationType.Transfer);
            var withdrawal = CommissionManager.CreateCommission(currency.Id, dto, OperationType.Withdrawal);

            await _context.Commissions.AddRangeAsync(deposit, transfer, withdrawal);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCurrencyAsync(string name)
        {
            var currency = await _context.Currencies
                .Where(c => c.Name == name)
                .FirstOrDefaultAsync();
            if (currency == null)
                return;
            _context.Currencies.Remove(currency);
            await _context.SaveChangesAsync();
        }
    }
}