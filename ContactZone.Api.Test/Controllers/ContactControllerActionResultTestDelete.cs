using ContactZone.Api.Controllers;
using ContactZone.Application.Services;
using ContactZone.Domain.Domains;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ContactZone.Tests.Api
{
    public class ContactControllerActionResultTestDelete
    {
        private readonly ContactController _controller;
        private readonly Mock<IContactService> _contactServiceMock;

        public ContactControllerActionResultTestDelete()
        {
            _contactServiceMock = new Mock<IContactService>();
            _controller = new ContactController(_contactServiceMock.Object);
        }

        [Fact]
        public async Task Delete_ValidId_DeletesContact_ReturnsNoContent()
        {
            // Arrange
            int validId = 1; // ID válido
            var existingContact = new ContactDomain { Id = validId, Name = "John Doe" };

            _contactServiceMock.Setup(s => s.GetByIdAsync(validId))
                .ReturnsAsync(existingContact); // Simula que o contato existe

            // Act
            var result = await _controller.Delete(validId);

            // Assert
            Assert.IsType<NoContentResult>(result); // Verifica se o resultado é NoContent
            _contactServiceMock.Verify(s => s.RemoveAsync(existingContact), Times.Once); // Verifica se o método RemoveAsync foi chamado uma vez
        }
    }
}
