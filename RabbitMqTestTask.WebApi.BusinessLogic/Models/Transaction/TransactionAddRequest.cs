using RabbitMqTestTask.WebApi.BusinessLogic.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace RabbitMqTestTask.WebApi.BusinessLogic.Models.Transaction
{
    public class TransactionAddRequest
    {
        [Required]
        public int ClientId { get; set; }
        [Required, Range(0.0, double.MaxValue)]
        public decimal Amount { get; set; }
        [EnumDataType(typeof(CurrencyModel))]
        public CurrencyModel Currency { get; set; }
    }
}
