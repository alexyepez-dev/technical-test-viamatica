using System.ComponentModel.DataAnnotations;
using VMT.TechnicalTest.Domain.Entities.User;
using Xunit.Abstractions;

namespace VMT.TechnicalTest.xUnit.AttributesValid.Username
{
    public class UsernameValidatorTest
    (
        ITestOutputHelper _helper
    )
    {
        private readonly ITestOutputHelper helper = _helper;

        [Theory]
        [InlineData("Juan123", true)]       // ❌ menos de 8
        [InlineData("JUANPEREZ1", true)]   // ❌ contiene signo
        [InlineData("JUANPEREZ2", true)]     // ❌ sin número ni mayúscula
        [InlineData("JUANPEREZ3", true)]     // ✅ cumple reglas
        [InlineData("JuanPerez123", true)]   // ✅ cumple reglas
        public void UsernameValidationWork(string username, bool expectedValid)
        {
            // Arrange:
            var model = new UserEntity
            {
                Username = username
            };

            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(model, context, results, validateAllProperties: true);

            // Assert
            Assert.Equal(expectedValid, isValid);

            if (!isValid) results.ForEach(res => helper.WriteLine($"Error: {res.ErrorMessage}"));
        }
    }
}