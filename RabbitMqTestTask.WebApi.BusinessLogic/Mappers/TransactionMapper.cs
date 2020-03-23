using RabbitMqTestTask.Common.Enums;
using RabbitMqTestTask.Common.Models.Transaction;
using RabbitMqTestTask.WebApi.BusinessLogic.Enums;
using RabbitMqTestTask.WebApi.BusinessLogic.Models.Transaction;
using System.Linq;

namespace RabbitMqTestTask.WebApi.BusinessLogic.Mappers
{
    public static class TransactionMapper
    {
        public static TransactionModel ToModel(this TransactionMqModel transactionMqModel)
        {
            if (transactionMqModel is null)
            {
                return null;
            }

            var transactionModel = new TransactionModel()
            {
                Id = transactionMqModel.Id,
                ClientId = transactionMqModel.ClientId,
                DepartmentAddress = transactionMqModel.DepartmentAddress,
                Amount = transactionMqModel.Amount,
                Currency = (CurrencyModel)(int)transactionMqModel.Currency,
                Status = (TransactionStatusModel)(int)transactionMqModel.Status,
            };

            return transactionModel;
        }

        public static TransactionAddMqRequest ToMqModel(this TransactionAddRequest transactionAddRequest)
        {
            var transactionAddMqRequest = new TransactionAddMqRequest()
            {
                ClientId = transactionAddRequest.ClientId,
                Amount = transactionAddRequest.Amount,
                Currency = (CurrencyMqModel)(int)transactionAddRequest.Currency,
            };

            return transactionAddMqRequest;
        }

        public static TransactionGetByIdMqRequest ToMqModel(this TransactionGetByIdRequest transactionGetByIdRequest)
        {
            var transactionGetByIdMqRequest = new TransactionGetByIdMqRequest()
            {
                Id = transactionGetByIdRequest.Id,
            };

            return transactionGetByIdMqRequest;
        }

        public static TransactionGetAllByClientMqRequest ToMqModel(this TransactionGetAllByClientRequest transactionGetByClientRequest)
        {
            var transactionGetByClientMqRequest = new TransactionGetAllByClientMqRequest()
            {
                ClientId = transactionGetByClientRequest.ClientId,
                DepartmentAddress = transactionGetByClientRequest.DepartmentAddress,
            };

            return transactionGetByClientMqRequest;
        }

        public static TransactionAddResponse ToModel(this TransactionAddMqResponse transactionAddMqResponse)
        {
            var transactionAddResponse = new TransactionAddResponse()
            {
                Id = transactionAddMqResponse.Id,
            };

            return transactionAddResponse;
        }

        public static TransactionGetResponse ToModel(this TransactionGetMqResponse transactionGetMqResponse)
        {
            var transactionGetResponse = new TransactionGetResponse()
            {
                Transaction = transactionGetMqResponse.Transaction.ToModel(),
            };

            return transactionGetResponse;
        }

        public static TransactionGetAllResponse ToModel(this TransactionGetAllMqResponse transactionGetAllMqResponse)
        {
            var transactionGetAllResponse = new TransactionGetAllResponse()
            {
                Transactions = transactionGetAllMqResponse.Transactions.Select(transactionProperty => transactionProperty.ToModel()).ToList(),
            };

            return transactionGetAllResponse;
        }
    }
}
