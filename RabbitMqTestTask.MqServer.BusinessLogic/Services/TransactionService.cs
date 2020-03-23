using RabbitMqTestTask.Common.Models.Transaction;
using RabbitMqTestTask.MqServer.BusinessLogic.Mappers;
using RabbitMqTestTask.MqServer.BusinessLogic.Services.Interfaces;
using RabbitMqTestTask.MqServer.DataAccess.Repositories.Interfaces;
using System.Linq;

namespace RabbitMqTestTask.MqServer.BusinessLogic.Services
{
    public class TransactionService : ITransactionService
    {
        ITransactionRepository _transactionRepository { get; set; }

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public TransactionAddMqResponse Add(TransactionAddMqRequest transactionAddMqRequest)
        {
            var transactionId = _transactionRepository.Add(transactionAddMqRequest.ToParameters());

            var transactionCreateMqResponse = new TransactionAddMqResponse() { Id = transactionId };

            return transactionCreateMqResponse;
        }

        public TransactionGetMqResponse GetById(TransactionGetByIdMqRequest transactionGetByIdMqRequest)
        {
            var transaction = _transactionRepository.GetById(transactionGetByIdMqRequest.ToParameters());

            var transactionGetMessageResponse = new TransactionGetMqResponse()
            {
                Transaction = transaction.ToMqModel(),
            };

            return transactionGetMessageResponse;
        }

        public TransactionGetAllMqResponse GetAllByClient(TransactionGetAllByClientMqRequest transactionGetAllByClientIdMqRequest)
        {
            var transactions = _transactionRepository.GetAllByClient(transactionGetAllByClientIdMqRequest.ToParameters());

            var transactionGetMqResponse = new TransactionGetAllMqResponse()
            {
                Transactions = transactions.Select(transactionProperty => transactionProperty.ToMqModel()).ToList(),
            };

            return transactionGetMqResponse;
        }
    }
}
