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
using Wallet.Models;
using Wallet.Services;

namespace Wallet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<UserRecord> _userManager;
        private readonly AccountsManager _accountsManager;
        private readonly OperationManager _operationManager;

        public AccountController(UserManager<UserRecord> userManager, AccountsManager accountsManager,
            OperationManager operationManager)
        {
            _userManager = userManager;
            _accountsManager = accountsManager;
            _operationManager = operationManager;
        }

        [Authorize]
        public async Task<List<Account>> Get() =>
            await _accountsManager.Accounts(_userManager.GetUserId(User));

        [Authorize]
        [HttpPost("Create")]
        public async Task CreateAccount([FromQuery] string name) =>
            await _accountsManager.TryAddAccountAsync(await _userManager.GetUserAsync(User), name);

        [Authorize]
        [HttpGet("{accountName}")]
        public async Task<List<Models.Wallet>> Get([FromRoute] string accountName,
            [FromServices] WalletContext context)
        {
            var account = await _accountsManager.GetAccount(_userManager.GetUserId(User), accountName);
            if (account == null)
                throw new ArgumentException();
            return await account.Wallets(context);
        }

        [Authorize]
        [HttpPost("Deposit")]
        public async Task<IActionResult> Deposit([FromQuery] double value, [FromQuery] string accountName,
            [FromQuery] string currencyName, [FromServices] WalletContext context)
        {
            var currency = await context.Currencies
                .FirstOrDefaultAsync(c => c.Name == currencyName);
            if (currency == null)
                return BadRequest();

            var account = await _accountsManager.GetAccount(_userManager.GetUserId(User), accountName);
            if (account == null)
                return BadRequest();

            if (await _operationManager.TryDeposit(currency.Id, account.Id, value))
                return Ok();
            return BadRequest();
        }


        //refactor
        [Authorize]
        [HttpPost("Withdraw")]
        public async Task<IActionResult> Withdraw([FromQuery] double value, [FromQuery] string accountName,
            [FromQuery] string currencyName, [FromServices] WalletContext context)
        {
            var currency = await context.Currencies
                .FirstOrDefaultAsync(c => c.Name == currencyName);
            if (currency == null)
                return BadRequest();

            var account = await _accountsManager.GetAccount(_userManager.GetUserId(User), accountName);
            if (account == null)
                return BadRequest();

            if (await _operationManager.TryWithdraw(currency.Id, account.Id, value))
                return Ok();
            return BadRequest();
        }

        //refactor
        [Authorize]
        [HttpPost("Transfer")]
        public async Task<IActionResult> Transfer([FromQuery] double value, [FromQuery] string userName,
            [FromQuery] string accountName, [FromQuery] string fromAccountName, [FromQuery] string currencyName,
            [FromServices] WalletContext context)
        {
            var currency = await context.Currencies
                .FirstOrDefaultAsync(c => c.Name == currencyName);
            if (currency == null)
                return BadRequest();

            var account = await _accountsManager.GetAccount(_userManager.GetUserId(User), fromAccountName);
            if (account == null)
                return BadRequest();

            var targetAccount = await _accountsManager.GetAccount(
                (await _userManager.Users.Where(u => u.UserName == userName).FirstOrDefaultAsync()).Id, accountName);
            if (targetAccount == null)
                return BadRequest();

            if (await _operationManager.TryTransfer(currency.Id, account.Id, targetAccount.Id, value))
                return Ok();
            return BadRequest();
        }
    }
}