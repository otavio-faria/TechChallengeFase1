using ContactZone.Api.Controllers;
using ContactZone.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ContactZone.Tests.Api
{
    public class ContactControllerValidationTestGetById
    {
        private readonly ContactController _controller;
        private readonly Mock<IContactService> _contactServiceMock;

        public ContactControllerValidationTestGetById()
        {
            _contactServiceMock = new Mock<IContactService>();
            _controller = new ContactController(_contactServiceMock.Object);
        }

        [Fact]
        public async Task GetById_IdIsLessThanOrEqualToZero_ReturnsBadRequest()
        {
            // Arrange
            int invalidId = 0; // Testando com um ID inválido (0)

            // Act
            var result = await _controller.GetById(invalidId);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("The id must be a positive value", badRequestResult.Value); // Verifica a mensagem de erro
        }
    }
}
