using System.ComponentModel.DataAnnotations;

namespace RabbitMqTestTask.WebApi.BusinessLogic.Models.Transaction
{
    public class TransactionGetByIdRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
