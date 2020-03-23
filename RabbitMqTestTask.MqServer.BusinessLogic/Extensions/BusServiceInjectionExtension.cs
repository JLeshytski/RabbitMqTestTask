using EasyNetQ;
using RabbitMqTestTask.Common.Models.Transaction;
using RabbitMqTestTask.MqServer.BusinessLogic.Services.Interfaces;

namespace RabbitMqTestTask.MqServer.BusinessLogic.Extensions
{
    public static class BusServiceInjectionExtension
    {
        public static void AddTransactionService(this IBus bus, ITransactionService transactionService)
        {
            bus.Respond<TransactionAddMqRequest, TransactionAddMqResponse>(transactionAddMessageRequest =>
            {
                TransactionAddMqResponse transactionAddMessageResponse = transactionService.Add(transactionAddMessageRequest);

                return transactionAddMessageResponse;
            });

            bus.Respond<TransactionGetByIdMqRequest, TransactionGetMqResponse>(transactionGetByIdMessageRequest =>
            {
                TransactionGetMqResponse transactionGetMessageResponse = transactionService.GetById(transactionGetByIdMessageRequest);

                return transactionGetMessageResponse;
            });

            bus.Respond<TransactionGetAllByClientMqRequest, TransactionGetAllMqResponse>(transactionGetByClientMessageRequest =>
            {
                TransactionGetAllMqResponse transactionGetMessageResponse = transactionService.GetAllByClient(transactionGetByClientMessageRequest);

                return transactionGetMessageResponse;
            });
        }
    }
}
