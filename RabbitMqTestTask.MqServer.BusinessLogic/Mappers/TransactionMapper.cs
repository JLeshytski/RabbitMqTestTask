using RabbitMqTestTask.Common.Enums;
using RabbitMqTestTask.Common.Models.Transaction;
using RabbitMqTestTask.MqServer.DataAccess.Entities;
using RabbitMqTestTask.MqServer.DataAccess.Enums;
using RabbitMqTestTask.MqServer.DataAccess.Parameters.Transaction;

namespace RabbitMqTestTask.MqServer.BusinessLogic.Mappers
{
    public static class TransactionMapper
    {
        public static TransactionMqModel ToMqModel(this Transaction transaction)
        {
            if (transaction is null)
            {
                return null;
            }

            var transactionModel = new TransactionMqModel()
            {
                Id = transaction.Id,
                ClientId = transaction.ClientId,
                DepartmentAddress = transaction.DepartmentAddress,
                Amount = transaction.Amount,
                Currency = (CurrencyMqModel)(int)transaction.Currency,
                Status = (TransactionStatusMqModel)(int)transaction.Status,
            };

            return transactionModel;
        }

        public static TransactionAddParameters ToParameters(this TransactionAddMqRequest transactionCreateMessageRequest)
        {
            var transactionAddParameters = new TransactionAddParameters()
            {
                ClientId = transactionCreateMessageRequest.ClientId,
                DepartmentAddress = transactionCreateMessageRequest.DepartmentAddress,
                Amount = transactionCreateMessageRequest.Amount,
                Currency = (Currency)(int)transactionCreateMessageRequest.Currency,
            };

            return transactionAddParameters;
        }

        public static TransactionGetAllByClientParameters ToParameters(this TransactionGetAllByClientMqRequest transactionGetAllByClientMqRequest)
        {
            var transactionGetAllByClientParameters = new TransactionGetAllByClientParameters()
            {
                ClientId = transactionGetAllByClientMqRequest.ClientId,
                DepartmentAddress = transactionGetAllByClientMqRequest.DepartmentAddress,
            };

            return transactionGetAllByClientParameters;
        }

        public static TransactionGetByIdParameters ToParameters(this TransactionGetByIdMqRequest transactionGetByIdMqRequest)
        {
            var transactionGetByIdParameters = new TransactionGetByIdParameters()
            {
                Id = transactionGetByIdMqRequest.Id,
            };

            return transactionGetByIdParameters;
        }
    }
}
