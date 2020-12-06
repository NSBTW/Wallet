using System;
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
        [HttpGet]
        public async Task<List<User>> Get()
        {
            return await _walletDbContext.Users.ToListAsync();
        }
    }
}
