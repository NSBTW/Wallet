using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Wallet.Database;

namespace Wallet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly WalletDbContext _walletDbContext;
        private readonly UserManager<User> _userManager;

        public AccountController(WalletDbContext walletDbContext, UserManager<User> userManager)
        {
            _walletDbContext = walletDbContext;
            _userManager = userManager;
        }

        [Authorize]
        [HttpPost("Transfer")]
        public async Task<IActionResult> Transaction([FromQuery] string fromAccountId, [FromQuery] string toAccountId,
            [FromQuery] string currencyId, [FromQuery] double value)
        {
            if (value < 0)
                return BadRequest();
            var wallet = await GetWallet(fromAccountId, currencyId);
            if (wallet == null)
                return BadRequest();

            var targetWallet = await GetWallet(toAccountId, currencyId);
            if (targetWallet == null)
                return BadRequest();

            if (!wallet.TryTransferTo(targetWallet, value)) return BadRequest();
            await _walletDbContext.SaveChangesAsync();
            return Ok();
        }

        [Authorize]
        [HttpPost("Put")]
        public async Task<IActionResult> Put([FromQuery] double value, [FromQuery] string accountId,
            [FromQuery] string currencyId)
        {
            var wallet = await GetWallet(accountId, currencyId);
            if (wallet == null)
                return BadRequest();

            if (!wallet.TryPut(value)) return BadRequest();
            await _walletDbContext.SaveChangesAsync();
            return Ok();
        }

        [Authorize]
        [HttpPost("Take")]
        public async Task<IActionResult> Take([FromQuery] double value, [FromQuery] string accountId,
            [FromQuery] string currencyId)
        {
            var wallet = await GetWallet(accountId, currencyId);
            if (wallet == null)
                return BadRequest();

            if (!wallet.TryGet(value)) return BadRequest();
            await _walletDbContext.SaveChangesAsync();
            return Ok();
        }

        private async Task<Wallet> GetWallet(string accountId, string currencyId)
        {
            var user = await _userManager.GetUserAsync(User);

            await _walletDbContext.PersonalCommissions
                .Where(p => p.Currency.Id == currencyId && p.User.Id == user.Id)
                .LoadAsync();
            return await _walletDbContext.Wallets
                .Where(w => w.Account.Id == accountId && w.Currency.Id == currencyId)
                .Include(w => w.Currency)
                .ThenInclude(c => c.CommissionsStack)
                .Include(w => w.Account)
                .ThenInclude(a => a.User)
                .FirstOrDefaultAsync();
        }

        [Authorize]
        [HttpPost("Create")]
        public async void CreateAccount([FromQuery] string name)
        {
            var user = await _userManager.GetUserAsync(User);
            user.Accounts.Add(new Account {Name = name});
            await _walletDbContext.SaveChangesAsync();
        }

        [Authorize]
        [HttpGet("{accountName}")]
        public async Task<Account> Get(string accountName)
        {
            var account = await _walletDbContext.Accounts
                .Where(a => a.Name == accountName && a.User.Id == _userManager.GetUserId(User))
                .Include(a => a.Wallets)
                .ThenInclude(w => w.Currency)
                .ThenInclude(c => c.CommissionsStack)
                .ThenInclude(s => s.TransferCommission)
                .FirstOrDefaultAsync();
            var wallets =
                account.Wallets.Select(wallet => new Wallet {Currency = wallet.Currency, Value = wallet.Value})
                    .ToList();
            return new Account {Name = account.Name, Wallets = wallets};
        }

        [Authorize]
        public async Task<List<string>> Get()
        {
            var accounts = await _walletDbContext.Accounts
                .Where(a => a.User.Id == _userManager.GetUserId(User)).ToListAsync();

            // DbInitializer.InitializeUser(_walletDbContext, await _userManager.GetUserAsync(User));
            
            return accounts.Select(a => a.Name).ToList();
        }
    }
}