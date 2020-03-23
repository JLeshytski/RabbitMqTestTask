using RabbitMqTestTask.Common.Enums;

namespace RabbitMqTestTask.Common.Models.Transaction
{
    public class TransactionAddMqRequest
    {
        public int ClientId { get; set; }
        public string DepartmentAddress { get; set; }
        public decimal Amount { get; set; }
        public CurrencyMqModel Currency { get; set; }
    }
}
