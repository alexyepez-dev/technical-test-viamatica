using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using VMT.TechnicalTest.Domain.Errors;

namespace VMT.TechnicalTest.Domain.ValueObjects.Dni
{
    public class DniValidatorAttributeValueObject : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var dni = value as string;

            if (string.IsNullOrEmpty(dni)) return new ValidationResult(DomainErrors.DniRequired);

            if (!Regex.IsMatch(dni, @"^\d{10}$")) return new ValidationResult(DomainErrors.DniDigitsLength);

            if (Regex.IsMatch(dni, @"(\d)\1\1\1")) return new ValidationResult(DomainErrors.DniRepeatedDigits);

            return ValidationResult.Success;
        }
    }
}