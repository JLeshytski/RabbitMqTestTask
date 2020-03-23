using RabbitMqTestTask.MqServer.DataAccess.Enums;

namespace RabbitMqTestTask.MqServer.DataAccess.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string DepartmentAddress { get; set; }
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }
        public TransactionStatus Status { get; set; }
    }
}
