using RabbitMqTestTask.WebApi.BusinessLogic.Models.Transaction;
using System.Threading.Tasks;

namespace RabbitMqTestTask.WebApi.BusinessLogic.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<TransactionAddResponse> AddAsync(TransactionAddRequest transactionAddRequest);
        Task<TransactionGetResponse> GetByIdAsync(TransactionGetByIdRequest transactionGetByIdRequest);
        Task<TransactionGetAllResponse> GetAllByClientAsync(TransactionGetAllByClientRequest transactionGetByClientRequest);
    }
}
