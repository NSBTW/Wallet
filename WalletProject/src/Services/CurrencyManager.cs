using System;
using System.Collections.Generic;
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
        private readonly WalletDbContext _context;

        public CurrencyManager(WalletDbContext context)
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
    }
}