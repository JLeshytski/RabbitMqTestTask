using RabbitMqTestTask.MqServer.DataAccess.Entities;
using RabbitMqTestTask.MqServer.DataAccess.Parameters.Transaction;
using System.Collections.Generic;

namespace RabbitMqTestTask.MqServer.DataAccess.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        int Add(TransactionAddParameters transactionAddParameters);
        Transaction GetById(TransactionGetByIdParameters transactionGetByIdParameters);
        List<Transaction> GetAllByClient(TransactionGetAllByClientParameters transactionGetAllByClientParameters);
    }
}
