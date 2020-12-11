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
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<UserRecord> _userManager;
        private readonly AccountsManager _accountsManager;

        public AdminController(UserManager<UserRecord> userManager, AccountsManager accountsManager)
        {
            _userManager = userManager;
            _accountsManager = accountsManager;
        }

        [HttpPost("ChangeAccountValue")]
        public async Task<IActionResult> ChangeAccountValue([FromQuery] string userName, [FromQuery] string accountName,
            [FromQuery] string currencyName, [FromQuery] double value) =>
            await _accountsManager.TryChangeAccountValue(userName, accountName, currencyName, value)
                ? (IActionResult) Ok()
                : BadRequest();


        [HttpPost("DeleteCurrency")]
        public async Task<IActionResult> DeleteCurrency([FromQuery] string name,
            [FromServices] CurrencyManager currencyManager) =>
            await currencyManager.TryDeleteCurrency(name) ? (IActionResult) Ok() : BadRequest();

        [HttpPost("AddCurrency")]
        public async Task AddCurrency([FromQuery] string name,
            [FromServices] CurrencyManager currencyManager) => await currencyManager.CreateCurrency(name,
            CommissionCreator.CreateRelativeCommission(0.01),
            CommissionCreator.CreateRelativeCommission(0.01),
            CommissionCreator.CreateRelativeCommission(0.01));


        [HttpPost("ConfirmOperation")]
        public async Task ConfirmOperation([FromQuery] string operationId,
            [FromServices] OperationManager operationManager) => await operationManager.ConfirmOperation(operationId);

        [HttpPost("CurrencyCommission")]
        public async Task<IActionResult> ChangeCurrencyCommission([FromQuery] string currencyName,
            [FromQuery] CommissionViewModel model, [FromServices] WalletDbContext context)
        {
            var currency = await context.Currencies
                .Where(c => c.Name == currencyName)
                .Include(c => c.Commissions)
                .FirstOrDefaultAsync();
            if (currency == null)
                return BadRequest();
            var commission =
                currency.Commissions.FirstOrDefault(c => c.OperationType == model.OperationType && !c.IsUserCommission);
            if (commission == null)
                throw new Exception();
            CopyCommissionViewToRecord(model, commission);
            await context.SaveChangesAsync();
            return Ok();
        }

        private static void CopyCommissionViewToRecord(CommissionViewModel model, CommissionRecord commission)
        {
            commission.Rate = model.Rate;
            commission.Type = model.Type;
            commission.Value = model.Value;
            commission.MaxValue = model.MaximalValue;
            commission.MinValue = model.MinimalValue;
        }
    }
}