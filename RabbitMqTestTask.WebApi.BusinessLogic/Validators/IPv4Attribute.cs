using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace RabbitMqTestTask.WebApi.BusinessLogic.Validators
{
    public class IPv4Attribute : ValidationAttribute
    {
        private const string _ipv4Regex = @"^(?:(?:^|\.)(?:2(?:5[0-5]|[0-4]\d)|1?\d?\d)){4}$";

        public IPv4Attribute()
        {
            ErrorMessage = "IPv4 not valid";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var address = (string)value;

            if (!Regex.IsMatch(address, _ipv4Regex))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
