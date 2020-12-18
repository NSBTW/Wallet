using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wallet.Database;
using Wallet.Database.Models;
using Wallet.Database.Models.Operations;
using Wallet.Models;
using Wallet.Services;

namespace Wallet.Controllers
{
    [ApiController]
    [Route("account")]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<UserRecord> _userManager;
        private readonly AccountManager _accountManager;
        private readonly OperationManager _operationManager;

        public AccountController(UserManager<UserRecord> userManager, AccountManager accountManager,
            OperationManager operationManager)
        {
            _userManager = userManager;
            _accountManager = accountManager;
            _operationManager = operationManager;
        }

        [HttpGet]
        public async Task<List<Account>> Get() =>
            await _accountManager.GetAccountsAsync(_userManager.GetUserId(User));

        [HttpGet("{accountName}")]
        public async Task<List<Models.Wallet>> Get([FromRoute] string accountName)
        {
            var account = await _accountManager.GetAccountAsync(_userManager.GetUserId(User), accountName);
            if (account == null)
                throw new ArgumentException();
            return account.GetWallets().ToList();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] string name) =>
            await _accountManager.TryAddAccountAsync((await _userManager.GetUserAsync(User)).Id, name)
                ? (IActionResult) Ok()
                : Content("This name already exists");

        [HttpPost("deposit")]
        public async Task Deposit([FromBody] double value, [FromBody] string accountName,
            [FromBody] string currencyName, [FromServices] WalletContext context)
        {
            var currency = await context.Currencies
                .FirstOrDefaultAsync(c => c.Name == currencyName);
            if (currency == null)
                return;

            var account = await _accountManager.GetAccountAsync(_userManager.GetUserId(User), accountName);
            if (account == null)
                return;

            if (await _operationManager.TryDoOperationAsync(currency.Id, account.Id, value, OperationType.Deposit))
                return;
        }


        //refactor
        [HttpPost("withdraw")]
        public async Task Withdraw([FromBody] double value, [FromBody] string accountName,
            [FromBody] string currencyName, [FromServices] WalletContext context)
        {
            var currency = await context.Currencies
                .FirstOrDefaultAsync(c => c.Name == currencyName);
            if (currency == null)
                return;

            var account = await _accountManager.GetAccountAsync(_userManager.GetUserId(User), accountName);
            if (account == null)
                return;

            if (await _operationManager.TryDoOperationAsync(currency.Id, account.Id, value, OperationType.Withdrawal))
                return;
        }

        //refactor
        [HttpPost("transfer")]
        public async Task Transfer([FromBody] double value, [FromBody] string userName,
            [FromBody] string accountName, [FromBody] string fromAccountName, [FromBody] string currencyName,
            [FromServices] WalletContext context)
        {
            var currency = await context.Currencies
                .FirstOrDefaultAsync(c => c.Name == currencyName);
            if (currency == null)
                return;

            var account = await _accountManager.GetAccountAsync(_userManager.GetUserId(User), fromAccountName);
            if (account == null)
                return;

            var targetAccount = await _accountManager.GetAccountAsync(
                (await _userManager.Users.Where(u => u.UserName == userName).FirstOrDefaultAsync()).Id, accountName);
            if (targetAccount == null)
                return;

            if (await _operationManager.TryDoOperationAsync(currency.Id, account.Id, value, OperationType.Transfer,
                targetAccount.Id))
                return;
        }
    }
}