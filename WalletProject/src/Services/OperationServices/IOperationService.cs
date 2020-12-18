using System.Threading.Tasks;
using Wallet.Database.Models.Operations;
using Wallet.ViewModels;

namespace Wallet.Services.OperationServices
{
    public interface IOperationService<in TRequest> where TRequest : OperationDto
    {
        public OperationType Type { get; }
        public Task<bool> TryDoOperationAsync(string userName, TRequest request);
        public Task<bool> TryConfirmOperationAsync(int operationId);
    }
}