using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wallet.Database;
using Wallet.Database.Models;
using Wallet.Database.Models.Commissions;
using Wallet.Database.Models.Operations;
using Wallet.Models.Commissions;

namespace Wallet.Services
{
    public class CurrencyManager
    {
        private readonly WalletContext _context;

        public CurrencyManager(WalletContext context)
        {
            _context = context;
        }

        public async Task CreateCurrency(string name, IRecordableCommission depositCommission,
            IRecordableCommission transferCommission,
            IRecordableCommission withdrawalCommission)
        {
            if (await _context.Currencies.FirstOrDefaultAsync(c => c.Name == name) != null)
                return;
            var deposit = depositCommission.ToRecord();
            var transfer = transferCommission.ToRecord();
            var withdrawal = withdrawalCommission.ToRecord();
            deposit.OperationType = OperationType.Deposit;
            transfer.OperationType = OperationType.Transfer;
            withdrawal.OperationType = OperationType.Withdrawal;

            await _context.Currencies.AddAsync(new CurrencyRecord
            {
                Id = Guid.NewGuid().ToString(), Name = name, Commissions = new List<CommissionRecord>
                {
                    deposit, transfer, withdrawal
                }
            });
            await _context.SaveChangesAsync();
        }

        public async Task<bool> TryDeleteCurrency(string name)
        {
            var currency = await _context.Currencies
                .Where(c => c.Name == name)
                .FirstOrDefaultAsync();
            if (currency == null)
                return false;
            _context.Currencies.Remove(currency);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}