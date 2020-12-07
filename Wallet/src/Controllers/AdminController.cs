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
using Wallet.ViewModels;

namespace Wallet.Controllers
{
    [ApiController]
    [Authorize(Roles = "admin")]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly WalletDbContext _walletDbContext;
        private readonly UserManager<User> _userManager;

        public AdminController(WalletDbContext walletDbContext, UserManager<User> userManager)
        {
            _walletDbContext = walletDbContext;
            _userManager = userManager;
        }

        [HttpPost("ChangeAccountValue")]
        public async Task<IActionResult> ChangeAccountValue([FromQuery] string accountId, [FromQuery] string currencyId,
            [FromQuery] double value)
        {
            var wallet = await _walletDbContext.Wallets
                .Where(w => w.Account.Id == accountId && w.Currency.Id == currencyId)
                .FirstOrDefaultAsync();
            if (wallet == null)
                return BadRequest();
            wallet.Value = value;
            await _walletDbContext.SaveChangesAsync();
            return Ok();
        }

        // what about the accounts?
        [HttpPost("DeleteCurrency")]
        public async Task<IActionResult> DeleteCurrency([FromQuery] string currencyId)
        {
            var currency = await _walletDbContext.Currencies
                .Where(c => c.Id == currencyId)
                .FirstOrDefaultAsync();
            if (currency == null)
                return BadRequest();
            _walletDbContext.Currencies.Remove(currency);
            await _walletDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("AddCurrency")]
        public async Task<IActionResult> AddCurrency([FromQuery] string name, [FromQuery] Commission commission)
        {
            if (await _walletDbContext.Currencies.Where(c => c.Name == name).FirstOrDefaultAsync() != null)
                return BadRequest();
            var currency = new Currency {CommissionsStack = new CommissionsStack(commission), Name = name};
            await _walletDbContext.Currencies.AddAsync(currency);
            await _walletDbContext.SaveChangesAsync();
            return Ok();
        }

        //Need refactor
        [HttpPost("CurrencyDepositCommission")]
        public async Task<IActionResult> ChangeCurrencyDepositCommission([FromQuery] string currencyId,
            [FromQuery] Commission commission, [FromQuery] CommissionArea area)
        {
            var query = _walletDbContext.Currencies
                .Where(c => c.Id == currencyId)
                .Include(c => c.CommissionsStack);
            var secondQuery = area switch
            {
                CommissionArea.Transfer => query.ThenInclude(c => c.TransferCommission),
                CommissionArea.Deposit => query.ThenInclude(c => c.DepositCommission),
                CommissionArea.Out => query.ThenInclude(c => c.OutCommission),
                _ => throw new ArgumentOutOfRangeException(nameof(area), area, null)
            };
            var currency = await secondQuery.FirstOrDefaultAsync();
            if (currency == null)
                return BadRequest();

            ChangeCommissionOnArea(area, currency.CommissionsStack, commission);

            await _walletDbContext.SaveChangesAsync();
            return Ok();
        }


        //Need refactor
        [HttpPost("UserOutCommission")]
        public async Task<IActionResult> ChangeUserOutCommission([FromQuery] string userId,
            [FromQuery] string currencyId, [FromQuery] Commission commission, [FromQuery] CommissionArea area)
        {
            var query = _walletDbContext.PersonalCommissions
                .Where(c => c.User.Id == userId && c.Currency.Id == currencyId)
                .Include(c => c.CommissionsStack);
            var secondQuery = area switch
            {
                CommissionArea.Transfer => query.ThenInclude(c => c.TransferCommission),
                CommissionArea.Deposit => query.ThenInclude(c => c.DepositCommission),
                CommissionArea.Out => query.ThenInclude(c => c.OutCommission),
                _ => throw new ArgumentOutOfRangeException(nameof(area), area, null)
            };
            var personalCommission = await secondQuery.FirstOrDefaultAsync();
            if (personalCommission == null)
                return BadRequest();

            ChangeCommissionOnArea(area, personalCommission.CommissionsStack, commission);

            await _walletDbContext.SaveChangesAsync();
            return Ok();
        }

        //need refactor
        private static void ChangeCommissionOnArea(CommissionArea area, CommissionsStack stack, Commission commission)
        {
            switch (area)
            {
                case CommissionArea.Transfer:
                    stack.TransferCommission = commission;
                    break;
                case CommissionArea.Deposit:
                    stack.DepositCommission = commission;
                    break;
                case CommissionArea.Out:
                    stack.OutCommission = commission;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(area), area, null);
            }
        }
    }
}