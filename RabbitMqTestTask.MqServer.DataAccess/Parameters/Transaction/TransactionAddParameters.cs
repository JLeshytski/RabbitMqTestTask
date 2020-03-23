using RabbitMqTestTask.MqServer.DataAccess.Enums;

namespace RabbitMqTestTask.MqServer.DataAccess.Parameters.Transaction
{
    public class TransactionAddParameters
    {
        public int ClientId { get; set; }
        public string DepartmentAddress { get; set; }
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }
    }
}
