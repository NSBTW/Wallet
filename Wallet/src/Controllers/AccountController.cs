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
using Wallet.Database.Models;
using Wallet.Database.Models.Operations;

namespace Wallet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        //1) include
        //2) cache
        //3) dictionaries
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

            var currency = await _walletDbContext.Currencies.Where(c => c.Id == currencyId).FirstOrDefaultAsync();
            if (value >= currency.MaxTransfer)
            {
                var operation = new TransferOperation
                    {Wallet = wallet, TargetWallet = targetWallet, Value = value, Id = Guid.NewGuid().ToString()};
                await _walletDbContext.Operations.AddAsync(operation);
                await _walletDbContext.SaveChangesAsync();
                return Ok();
            }

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

            var currency = await _walletDbContext.Currencies.Where(c => c.Id == currencyId).FirstOrDefaultAsync();
            if (value >= currency.MaxTransfer)
            {
                var operation = new DepositOperation {Wallet = wallet, Value = value, Id = Guid.NewGuid().ToString()};
                await _walletDbContext.Operations.AddAsync(operation);
                await _walletDbContext.SaveChangesAsync();
                return Ok();
            }

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

            var currency = await _walletDbContext.Currencies.Where(c => c.Id == currencyId).FirstOrDefaultAsync();
            if (value >= currency.MaxTransfer)
            {
                var operation = new OutOperation {Wallet = wallet, Value = value, Id = Guid.NewGuid().ToString()};
                await _walletDbContext.Operations.AddAsync(operation);
                await _walletDbContext.SaveChangesAsync();
                return Ok();
            }

            if (!wallet.TryGet(value)) return BadRequest();
            await _walletDbContext.SaveChangesAsync();
            return Ok();
        }

        //need refactor(q)
        private async Task<Database.Models.Wallet> GetWallet(string accountId, string currencyId)
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
                .Include(w => w.Currency.CommissionsStack.TransferCommission)
                .Include(w => w.Currency.CommissionsStack.DepositCommission)
                .Include(w => w.Currency.CommissionsStack.OutCommission)
                .FirstOrDefaultAsync();
        }

        [Authorize]
        [HttpPost("Create")]
        public async void CreateAccount([FromQuery] string name)
        {
            var user = await _userManager.GetUserAsync(User);
            user.Accounts.Add(new Account {Name = name, Id = Guid.NewGuid().ToString()});
            await _walletDbContext.SaveChangesAsync();
        }

        //Need refactor(q)
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
                .Include(a => a.Wallets)
                .ThenInclude(w => w.Currency)
                .ThenInclude(c => c.CommissionsStack)
                .ThenInclude(s => s.DepositCommission)
                .Include(a => a.Wallets)
                .ThenInclude(w => w.Currency)
                .ThenInclude(c => c.CommissionsStack)
                .ThenInclude(s => s.OutCommission)
                .FirstOrDefaultAsync();
            var wallets =
                account.Wallets.Select(wallet => new Database.Models.Wallet
                        {Currency = wallet.Currency, Value = wallet.Value})
                    .ToList();
            return new Account {Name = account.Name, Wallets = wallets};
        }

        [Authorize]
        public async Task<List<string>> Get()
        {
            var accounts = await _walletDbContext.Accounts
                .Where(a => a.User.Id == _userManager.GetUserId(User)).ToListAsync();

            return accounts.Select(a => a.Name).ToList();
        }
    }
}