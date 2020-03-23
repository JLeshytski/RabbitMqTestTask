
using RabbitMqTestTask.Common.Models.Transaction;

namespace RabbitMqTestTask.MqServer.BusinessLogic.Services.Interfaces
{
    public interface ITransactionService
    {
        public TransactionAddMqResponse Add(TransactionAddMqRequest transactionAddMessageRequest);
        public TransactionGetMqResponse GetById(TransactionGetByIdMqRequest transactionGetByIdMessageRequest);
        public TransactionGetAllMqResponse GetAllByClient(TransactionGetAllByClientMqRequest transactionGetByClientIdMessageRequest);
    }
}
