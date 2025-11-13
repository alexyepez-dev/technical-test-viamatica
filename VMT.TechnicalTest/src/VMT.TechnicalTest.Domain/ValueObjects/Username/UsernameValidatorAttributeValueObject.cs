using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using VMT.TechnicalTest.Domain.Errors;

namespace VMT.TechnicalTest.Domain.ValueObjects.Username
{
    public class UsernameValidatorAttributeValueObject : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var username = value as string;

            if (string.IsNullOrEmpty(username)) return new ValidationResult(DomainErrors.UsernameRequired);

            if (username.Length > 20) return new ValidationResult(DomainErrors.UsernameMaxLegth);

            if (username.Length < 8) return new ValidationResult(DomainErrors.UsernameMinLegth);

            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9]+$")) return new ValidationResult(DomainErrors.UsernameInvalidCharacters);

            if (!Regex.IsMatch(username, @"[A-Z]")) return new ValidationResult(DomainErrors.UsernameMustContainUppercase);

            if (!Regex.IsMatch(username, @"\d")) return new ValidationResult(DomainErrors.UsernameMustContainNumber);

            return ValidationResult.Success;
        }
    }
}