using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public AccountController(WalletDbContext walletDbContext)
        {
            _walletDbContext = walletDbContext;
        }

        // [HttpGet("{accountName}")]
        // public async Task<Account> Get(string accountName)
        // {
        //     // var account = await _walletDbContext.Accounts
        //         // .Where(a => a.Name == accountName && a.User.UserId == 1)
        //         // .Include(a => a.Wallets)
        //         // .ThenInclude(w => w.Currency)
        //         // .ThenInclude(c => c.Commission)
        //         // .FirstOrDefaultAsync();
        //     // var wallets =
        //         // account.Wallets.Select(wallet => new Wallet {Currency = wallet.Currency, Value = wallet.Value})
        //             // .ToList();
        //     // return new Account {Name = account.Name, Wallets = wallets};
        // }
        //
        // [HttpGet]
        // public async Task<Account> Get()
        // {
        //     var account = await _walletDbContext.Accounts
        //         .Where(a => a.User.UserId == 1)
        //         .Include(a => a.Wallets)
        //         .ThenInclude(w => w.Currency)
        //         .ThenInclude(c => c.Commission)
        //         .FirstOrDefaultAsync();
        //     var wallets =
        //         account.Wallets.Select(wallet => new Wallet {Currency = wallet.Currency, Value = wallet.Value})
        //             .ToList();
        //     return new Account {Name = account.Name, Wallets = wallets};
        // }
    }
}