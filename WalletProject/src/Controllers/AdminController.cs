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
using Wallet.Helpers;
using Wallet.Services;
using Wallet.ViewModels;

namespace Wallet.Controllers
{
    [ApiController]
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

        [Authorize(Roles = "admin")]
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

        // //Need refactor
        // [HttpPost("CurrencyDepositCommission")]
        // public async Task<IActionResult> ChangeCurrencyDepositCommission([FromQuery] string currencyId,
        //     [FromQuery] Commission commission, [FromQuery] CommissionArea area)
        // {
        //     var query = _walletDbContext.Currencies
        //         .Where(c => c.Id == currencyId)
        //         .Include(c => c.CommissionsStack);
        //     var secondQuery = area switch
        //     {
        //         CommissionArea.Transfer => query.ThenInclude(c => c.TransferCommission),
        //         CommissionArea.Deposit => query.ThenInclude(c => c.DepositCommission),
        //         CommissionArea.Out => query.ThenInclude(c => c.OutCommission),
        //         _ => throw new ArgumentOutOfRangeException(nameof(area), area, null)
        //     };
        //     var currency = await secondQuery.FirstOrDefaultAsync();
        //     if (currency == null)
        //         return BadRequest();
        //
        //     commission.Id = Guid.NewGuid().ToString();
        //     ChangeCommissionOnArea(area, currency.CommissionsStack, commission);
        //
        //     await _walletDbContext.SaveChangesAsync();
        //     return Ok();
        // }
        //
        //
        // //Need refactor
        // [HttpPost("UserOutCommission")]
        // public async Task<IActionResult> ChangeUserOutCommission([FromQuery] string userId,
        //     [FromQuery] string currencyId, [FromQuery] Commission commission, [FromQuery] CommissionArea area)
        // {
        //     var query = _walletDbContext.PersonalCommissions
        //         .Where(c => c.User.Id == userId && c.Currency.Id == currencyId)
        //         .Include(c => c.CommissionsStack);
        //     var secondQuery = area switch
        //     {
        //         CommissionArea.Transfer => query.ThenInclude(c => c.TransferCommission),
        //         CommissionArea.Deposit => query.ThenInclude(c => c.DepositCommission),
        //         CommissionArea.Out => query.ThenInclude(c => c.OutCommission),
        //         _ => throw new ArgumentOutOfRangeException(nameof(area), area, null)
        //     };
        //     var personalCommission = await secondQuery.FirstOrDefaultAsync();
        //     if (personalCommission == null)
        //         return BadRequest();
        //     
        //     commission.Id = Guid.NewGuid().ToString();
        //     ChangeCommissionOnArea(area, personalCommission.CommissionsStack, commission);
        //
        //     await _walletDbContext.SaveChangesAsync();
        //     return Ok();
        // }
        
    }
}