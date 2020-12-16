using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Wallet.Database;
using Wallet.Database.Models;
using Wallet.Database.Models.Commissions;
using Wallet.Database.Models.Operations;
using Wallet.Helpers;
using Wallet.Services;
using Wallet.ViewModels;

namespace Wallet.Controllers
{
    [ApiController]
    [Authorize(Roles = "admin")]
    [Route("admin")]
    public class AdminController : ControllerBase
    {
        private readonly AccountsManager _accountsManager;

        public AdminController(AccountsManager accountsManager)
        {
            _accountsManager = accountsManager;
        }

        [HttpPost("changeAccountValue")]
        public async Task ChangeAccountValue([FromQuery] string userName, [FromQuery] string accountName,
            [FromQuery] string currencyName, [FromQuery] double value) =>
            await _accountsManager.TryChangeAccountValue(userName, accountName, currencyName, value);


        [HttpPost("deleteCurrency")]
        public async Task DeleteCurrency([FromQuery] string name,
            [FromServices] CurrencyManager currencyManager) =>
            await currencyManager.TryDeleteCurrency(name);

        // [HttpPost("addCurrency")]
        // public async Task AddCurrency([FromQuery] string name,
            // [FromServices] CurrencyManager currencyManager) => await currencyManager.CreateCurrency(name,
            // CommissionCreator.CreateRelativeCommission(0.01),
            // CommissionCreator.CreateRelativeCommission(0.01),
            // CommissionCreator.CreateRelativeCommission(0.01));


        [HttpPost("confirmOperation")]
        public async Task ConfirmOperation([FromQuery] string operationId,
            [FromServices] OperationManager operationManager) => await operationManager.ConfirmOperationAsync(operationId);

        [HttpPost("currencyCommission")]
        public async Task ChangeCurrencyCommission([FromQuery] string currencyName,
            [FromQuery] CommissionRequest model, [FromServices] WalletContext context)
        {
            var currency = await context.Currencies
                .Where(c => c.Name == currencyName)
                .Include(c => c.Commissions)
                .FirstOrDefaultAsync();
            if (currency == null)
                return;
            var commission =
                currency.Commissions.FirstOrDefault(c => c.OperationType == model.OperationType && c.UserId != null);
            if (commission == null)
                throw new Exception();
            CopyCommissionViewToRecord(model, commission);
            await context.SaveChangesAsync();
        }

        private static void CopyCommissionViewToRecord(CommissionRequest model, CommissionRecord commission)
        {
            commission.Rate = model.Rate;
            commission.Type = model.Type;
            commission.Value = model.Value;
            commission.MaxCommission = model.MaximalValue;
            commission.MinCommission = model.MinimalValue;
        }
    }
}