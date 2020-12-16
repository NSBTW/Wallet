using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wallet.Database;
using Wallet.Database.Models.Commissions;
using Wallet.Database.Models.Operations;

namespace Wallet.Services
{
    public class CommissionManager
    {
        private readonly WalletContext _walletContext;

        public CommissionManager(WalletContext walletContext, OperationManager operationManager)
        {
            _walletContext = walletContext;
        }

        public async Task<double> GetMaximalOperationValue(string userId, string currencyId,
            OperationType type) => (await GetCommission(userId, currencyId, type)).MaxValue;

        public async Task<double> CalculateCommission(string userId, string currencyId,
            OperationType type, double value) =>
            CalculateCommission(await GetCommission(userId, currencyId, type), value);

        private async Task<CommissionRecord> GetCommission(string userId, string currencyId,
            OperationType type)
        {
            var records = await _walletContext.Commissions
                .Where(c => c.CurrencyId == currencyId && c.OperationType == type).ToListAsync();
            var userCommission = records.FirstOrDefault(r => r.UserId == userId);
            return userCommission ?? records.FirstOrDefault() ?? throw new Exception();
        }


        public static double CalculateCommission(CommissionRecord record, double value) => record.Type switch
        {
            CommissionType.Absolute => CalculateAbsoluteCommission(record),
            CommissionType.Relative => CalculateRelativeCommission(record, value),
            _ => throw new ArgumentOutOfRangeException()
        };

        private static double CalculateAbsoluteCommission(CommissionRecord record) => record.Value;

        private static double CalculateRelativeCommission(CommissionRecord record, double value)
        {
            var commission = record.Rate * value;
            if (commission > record.MaxCommission)
                return record.MaxCommission;
            return commission < record.MinCommission ? record.MinCommission : commission;
        }
    }
}