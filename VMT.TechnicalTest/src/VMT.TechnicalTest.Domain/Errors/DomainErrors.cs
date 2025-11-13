namespace VMT.TechnicalTest.Domain.Errors
{
    public static class DomainErrors
    {
        public const string DniRequired = "The Dni is required.";
        public const string DniDigitsLength = "The Dni must have exactly 10 digits.";
        public const string DniRepeatedDigits = "The Dni must have exactly 10 digits.";
        public const string UsernameRequired = "The Username is required.";
        public const string UsernameMaxLegth = "The username cannot have more than 20 characters.";
        public const string UsernameMinLegth = "The username cannot be less than 8 characters.";
        public const string UsernameInvalidCharacters = "The username does not contain valid characters; only letters and numbers are allowed.";
        public const string UsernameMustContainUppercase = "The username must contain at least one capital letter.";
        public const string UsernameMustContainNumber = "The username must contain at least one number.";
    }
}