using RabbitMqTestTask.Common.Enums;

namespace RabbitMqTestTask.Common.Models.Transaction
{
    public class TransactionMqModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string DepartmentAddress { get; set; }
        public decimal Amount { get; set; }
        public CurrencyMqModel Currency { get; set; }
        public TransactionStatusMqModel Status { get; set; }
    }
}