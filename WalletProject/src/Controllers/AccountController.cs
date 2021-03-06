﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wallet.Database.Models;
using Wallet.Models;
using Wallet.Services;
using Wallet.Services.OperationServices;
using Wallet.ViewModels;

namespace Wallet.Controllers
{
    [ApiController]
    [Route("account")]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<UserRecord> _userManager;
        private readonly AccountManager _accountManager;

        public AccountController(UserManager<UserRecord> userManager, AccountManager accountManager)
        {
            _userManager = userManager;
            _accountManager = accountManager;
        }

        [HttpGet]
        public async Task<List<Account>> Get() =>
            await _accountManager.GetAccountsAsync(_userManager.GetUserId(User));

        [HttpGet("{name}")]
        public async Task<List<Models.Wallet>> Get([FromRoute] string name)
        {
            var account = await _accountManager.GetAccountAsync(_userManager.GetUserId(User), name);
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
        public async Task<IActionResult> Deposit([FromBody] OperationDto dto,
            [FromServices] DepositOperationService operationService) =>
            await operationService.TryDoOperationAsync(_userManager.GetUserId(User), dto)
                ? (IActionResult) Ok()
                : Content("Invalid operation");

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] OperationDto dto,
            [FromServices] WithdrawalOperationService operationService) =>
            await operationService.TryDoOperationAsync(_userManager.GetUserId(User), dto)
                ? (IActionResult) Ok()
                : Content("Invalid operation");

        [HttpPost("transfer")]
        public async Task<IActionResult> Transfer([FromBody] TransferOperationDto dto,
            [FromServices] TransferOperationService operationService) =>
            await operationService.TryDoOperationAsync(_userManager.GetUserId(User), dto)
                ? (IActionResult) Ok()
                : Content("Invalid operation");
    }
}