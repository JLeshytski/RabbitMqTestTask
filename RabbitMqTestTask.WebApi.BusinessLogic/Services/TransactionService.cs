using EasyNetQ;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using RabbitMqTestTask.Common.Models.Transaction;
using RabbitMqTestTask.Common.Options;
using RabbitMqTestTask.WebApi.BusinessLogic.Mappers;
using RabbitMqTestTask.WebApi.BusinessLogic.Models.Transaction;
using RabbitMqTestTask.WebApi.BusinessLogic.Services.Interfaces;
using System.Threading.Tasks;

namespace RabbitMqTestTask.WebApi.BusinessLogic.Services
{
    public class TransactionService : ITransactionService
    {
        private IHttpContextAccessor _httpContextAccessor { get; set; }
        private RabbitMqOptions _rabbitMqOptions { get; set; }

        public TransactionService(IHttpContextAccessor httpContextAccessor, IOptions<RabbitMqOptions> rabbitMqOptions)
        {
            _httpContextAccessor = httpContextAccessor;
            _rabbitMqOptions = rabbitMqOptions.Value;
        }

        private IBus CreateBus()
        {
            return RabbitHutch.CreateBus(_rabbitMqOptions.ConnectionString);
        }

        public async Task<TransactionAddResponse> AddAsync(TransactionAddRequest transactionAddRequest)
        {
            TransactionAddMqRequest transactionAddMqRequest = transactionAddRequest.ToMqModel();

            transactionAddMqRequest.DepartmentAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

            using var bus = CreateBus();

            TransactionAddMqResponse transactionAddMqResponse = await bus.RequestAsync<TransactionAddMqRequest, TransactionAddMqResponse>(transactionAddMqRequest);

            return transactionAddMqResponse.ToModel();
        }

        public async Task<TransactionGetResponse> GetByIdAsync(TransactionGetByIdRequest transactionGetByIdRequest)
        {
            using var bus = CreateBus();

            TransactionGetMqResponse transactionGetMqResponse = await bus.RequestAsync<TransactionGetByIdMqRequest, TransactionGetMqResponse>(transactionGetByIdRequest.ToMqModel());

            return transactionGetMqResponse.ToModel();
        }

        public async Task<TransactionGetAllResponse> GetAllByClientAsync(TransactionGetAllByClientRequest transactionGetByClientRequest)
        {
            using var bus = CreateBus();

            TransactionGetAllMqResponse transactionGetAllMqResponse = await bus.RequestAsync<TransactionGetAllByClientMqRequest, TransactionGetAllMqResponse>(transactionGetByClientRequest.ToMqModel());

            return transactionGetAllMqResponse.ToModel();
        }
    }
}
