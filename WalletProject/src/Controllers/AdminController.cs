using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wallet.Database;
using Wallet.Services;
using Wallet.Services.OperationServices;
using Wallet.ViewModels;

namespace Wallet.Controllers
{
    [ApiController]
    [Authorize(Roles = "admin")]
    [Route("admin")]
    public class AdminController : ControllerBase
    {
        private readonly AccountManager _accountManager;
        private readonly WalletContext _context;

        public AdminController(AccountManager accountManager, WalletContext context)
        {
            _accountManager = accountManager;
            _context = context;
        }

        [HttpPost("edit")]
        public async Task Edit([FromBody] EditAccountRequest request) =>
            await _accountManager.ChangeAccountValueAsync(request.UserName, request.AccountName,
                request.CurrencyName, request.Value);


        [HttpPost("deleteCurrency")]
        public async Task DeleteCurrency([FromBody] string name, [FromServices] CurrencyManager currencyManager) =>
            await currencyManager.DeleteCurrencyAsync(name);

        [HttpPost("addCurrency")]
        public async Task AddCurrency([FromBody] AddCurrencyRequest request,
            [FromServices] CurrencyManager currencyManager) =>
            await currencyManager.CreateCurrency(request.Name, request.CommissionDto);


        [HttpPost("confirmOperation")]
        public async Task<IActionResult> ConfirmOperation([FromBody] int operationId,
            [FromServices] IEnumerable<IOperationService<TransferOperationDto>> operationServices)
        {
            var type = (await _context.Operations.FirstOrDefaultAsync(o => o.Id == operationId)).Type;
            if (!await operationServices.First(o => o.Type == type).TryConfirmOperationAsync(operationId))
                return Content("Operation invalid");
            return Ok();
        }

        [HttpPost("commission")]
        public async Task ChangeOrCreateCommission([FromBody] ChangeCommissionRequest request)
        {
            var currencyId = (await _context.Currencies.FirstOrDefaultAsync(c => c.Name == request.CurrencyName)).Id;

            var userId = request.UserName == null
                ? null
                : (await _context.Users.FirstOrDefaultAsync(c => c.UserName == request.UserName)).Id;

            var commission = await _context.Commissions.FirstOrDefaultAsync(c =>
                c.OperationType == request.Type && c.CurrencyId == currencyId && c.UserId == userId);
            var dto = request.CommissionDto;
            if (commission == null)
            {
                commission =
                    CommissionManager.CreateCommission(currencyId, dto, request.Type, userId);
                await _context.AddAsync(commission);
            }
            else
            {
                commission.Rate = dto.Rate;
                commission.Value = dto.Value;
                commission.MaxCommission = dto.MaximalCommission;
                commission.MinCommission = dto.MinimalCommission;
                commission.Type = dto.Type;
                commission.MaxValue = dto.MaxOperationValue;
            }

            await _context.SaveChangesAsync();
        }
    }
}