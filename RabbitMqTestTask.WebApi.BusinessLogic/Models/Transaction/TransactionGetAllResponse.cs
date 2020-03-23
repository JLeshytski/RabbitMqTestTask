using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMqTestTask.WebApi.BusinessLogic.Models.Transaction
{
    public class TransactionGetAllResponse
    {
        public List<TransactionModel> Transactions { get; set; }
    }
}
