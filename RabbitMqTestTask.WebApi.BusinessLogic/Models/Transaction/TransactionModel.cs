using RabbitMqTestTask.WebApi.BusinessLogic.Enums;

namespace RabbitMqTestTask.WebApi.BusinessLogic.Models.Transaction
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string DepartmentAddress { get; set; }
        public decimal Amount { get; set; }
        public CurrencyModel Currency { get; set; }
        public TransactionStatusModel Status { get; set; }
    }
}
