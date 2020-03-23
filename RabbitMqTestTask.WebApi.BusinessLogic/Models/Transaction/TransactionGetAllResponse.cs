using System.Collections.Generic;

namespace RabbitMqTestTask.WebApi.BusinessLogic.Models.Transaction
{
    public class TransactionGetAllResponse
    {
        public List<TransactionModel> Transactions { get; set; }
    }
}
