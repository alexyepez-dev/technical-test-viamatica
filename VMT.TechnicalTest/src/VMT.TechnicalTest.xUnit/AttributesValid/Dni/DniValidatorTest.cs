using System.ComponentModel.DataAnnotations;
using VMT.TechnicalTest.Domain.Entities.Person;

namespace VMT.TechnicalTest.xUnit.AttributesValid.Dni
{
    public class DniValidatorTest
    {
        [Theory]
        [InlineData("0958095697", true)]
        [InlineData("095t095697", true)]
        public void DniValidationWork(string dni, bool expectedValid)
        {
            // Arrange:
            var model = new PersonEntity
            {
                Dni = dni
            };

            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(model, context, results, validateAllProperties: true);

            // Assert
            Assert.Equal(expectedValid, isValid);
        }
    }
}