using RabbitMqTestTask.WebApi.BusinessLogic.Validators;
using System.ComponentModel.DataAnnotations;

namespace RabbitMqTestTask.WebApi.BusinessLogic.Models.Transaction
{
    public class TransactionGetAllByClientRequest
    {
        [Required]
        public int ClientId { get; set; }
        [Required, IPv4]
        public string DepartmentAddress { get; set; }
    }
}
