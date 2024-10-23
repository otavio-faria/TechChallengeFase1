using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace ContactZone.Tests.Api
{
    public class ContactControllerValidationTestPost
    {
        private List<ValidationResult> ValidateModel(object model)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, context, results, true);
            return results;
        }

        [Fact]
        public void PostContactAndPersonalDataDto_Name_IsRequired()
        {
            // Arrange
            var dto = new PostContactAndPersonalDataDto { Name = null }; // Nome não fornecido

            // Act
            var validationResults = ValidateModel(dto);

            // Assert
            Assert.Contains(validationResults, v => v.ErrorMessage.Contains("Name is required."));
        }

        [Fact]
        public void PostContactAndPersonalDataDto_DDD_MustBeValid()
        {
            // Arrange
            var dto = new PostContactAndPersonalDataDto { DDD = "100" }; // DDD inválido (acima de 99)

            // Act
            var validationResults = ValidateModel(dto);

            // Assert
            Assert.Contains(validationResults, v => v.ErrorMessage.Contains("DDD must be a valid Brazilian DDD between 11 and 99."));
        }

        [Fact]
        public void PostContactAndPersonalDataDto_Phone_MustHaveValidFormat()
        {
            // Arrange
            var dto = new PostContactAndPersonalDataDto { Phone = "12345" }; // Telefone inválido (curto demais)

            // Act
            var validationResults = ValidateModel(dto);

            // Assert
            Assert.Contains(validationResults, v => v.ErrorMessage.Contains("Phone must be 8 or 9 digits long."));
        }

        [Fact]
        public void PostContactAndPersonalDataDto_Email_MustBeValid()
        {
            // Arrange
            var dto = new PostContactAndPersonalDataDto { Email = "invalid-email" }; // Email inválido

            // Act
            var validationResults = ValidateModel(dto);

            // Assert
            Assert.Contains(validationResults, v => v.ErrorMessage.Contains("Invalid Email Address."));
        }
    }
}
