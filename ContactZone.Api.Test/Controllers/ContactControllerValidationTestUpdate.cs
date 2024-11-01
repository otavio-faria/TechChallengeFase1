using ContactZone.Api.Controllers;
using ContactZone.Api.Dtos;
using ContactZone.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ContactZone.Api.Test.Controllers
{
    public class ContactControllerValidationTestUpdate
    {
        private readonly ContactController _controller;
        private readonly Mock<IContactService> _contactServiceMock;

        public ContactControllerValidationTestUpdate()
        {
            _contactServiceMock = new Mock<IContactService>();
            _controller = new ContactController(_contactServiceMock.Object);
        }

        [Fact]
        public async Task Update_ContactDtoIsNull_ReturnsBadRequest()
        {
            // Arrange
            int validId = 1; // ID válido

            // Act
            var result = await _controller.Update(validId, null);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Invalid contact data.", badRequestResult.Value); // Verifica a mensagem de erro
        }

        [Fact]
        public async Task Update_IdIsLessThanOrEqualToZero_ReturnsBadRequest()
        {
            // Arrange
            int invalidId = 0; // Testando com um ID inválido (0)
            var validDto = new PostContactDto { Name = "John Doe" };

            // Act
            var result = await _controller.Update(invalidId, validDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Invalid contact data.", badRequestResult.Value); // Verifica a mensagem de erro
        }
    }
}
