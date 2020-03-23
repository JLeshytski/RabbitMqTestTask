using System.Collections.Generic;

namespace RabbitMqTestTask.Common.Models.Transaction
{
    public class TransactionGetAllMqResponse
    {
        public List<TransactionMqModel> Transactions { get; set; }
    }
}
